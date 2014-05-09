using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using PrototypeMapEditor.Core;
using PrototypeMapEditor.Core.Enum;
using PrototypeMapEditor.CustomControls.Dialog;
using PrototypeMapEditor.Helper;
using PrototypeMapEditor.IO;
using Point = System.Drawing.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PrototypeMapEditor.EditorForm
{
    public partial class MapEditor : Form
    {
        private const float ScrollScale = 10;

        private AccessMap _accessMap;
        private Point _offset;
        private Point _currentPosition;
        private ObjectMap _lastObjectMapSelected;
        private bool _isMove;
        private bool _controlIsPressed;

        public MapEditor()
        {
            InitializeComponent();
            CenterToScreen();

            KeyPreview = true;

            Application.Idle += delegate { UpdateView(); };
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            _accessMap = new AccessMap();

            var drawingModes = Enum.GetNames(typeof(DrawingMode));
            RadioListBoxDrawingMode.Items.AddRange(drawingModes);
            RadioListBoxDrawingMode.SetSelected(0, true);
        }

        private void MapEditor_KeyDown(object sender, KeyEventArgs e)
        {
            _controlIsPressed = (ModifierKeys & Keys.Control) == Keys.Control;
        }

        private void MapEditor_KeyUp(object sender, KeyEventArgs e)
        {
            _controlIsPressed = false;
        }

        private void ButtonImportMetadata_Click(object sender, EventArgs e)
        {
            var importMetadataMapDialog = new ImportMetadataMapDialog();
            if (importMetadataMapDialog.ShowDialog() == DialogResult.OK)
            {
                var actionLoadMetadataMap = importMetadataMapDialog.ActionLoadMetadataMap;
                LoadMetadataMap(actionLoadMetadataMap.MetadataMap);
            }
        }

        private void ButtonAddLayer_Click(object sender, EventArgs e)
        {
            var layerForm = new LayerForm();
            layerForm.ShowDialog();

            var layer = layerForm.Layer;
            if (layer == null)
                return;

            MapDisplay.Map.AddLayer(layer);
            UpdateListBoxLayer();
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            if (!MapDisplay.Map.Layers.Any())
            {
                MessageBox.Show("Create layers before exporting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!MapDisplay.Map.Layers.Any(l => l.ObjectsInMap.Any()))
            {
                MessageBox.Show("Add objects on the layer before exporting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new ExportMapDialog(MapDisplay.Map).ShowDialog();
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            var importMapDialog = new ImportMapDialog();
            if (importMapDialog.ShowDialog() != DialogResult.OK)
                return;

            var map = importMapDialog.ActionLoadMap.Map;
            LoadMap(map);
        }

        private void ObjectDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            var objectMap = ObjectDisplay.SelectObject(e.X, e.Y);
            if (objectMap == null)
                return;

            var layer = GetSelectedLayer();
            if (!LayerIsSelected(layer))
                return;

            _lastObjectMapSelected = objectMap;
            if (!_controlIsPressed)
            {
                layer.AddObjectMap(objectMap.Clone(), MapDisplay.Position);
                UpdateListBoxObject(layer);
            }
        }

        private void VScrollBarObjectDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollObjectDisplay();
        }

        private void MapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            _currentPosition = CurrentPosition(e);

            switch (MapDisplay.DrawingMode)
            {
                case DrawingMode.SegmentSelection:
                    MapDisplayMouseMoveSegmentSelection();
                    break;
                case DrawingMode.CollisionMap:
                    break;
            }

            UpdateView();
        }

        private void MapDisplayMouseMoveSegmentSelection()
        {
            if (_controlIsPressed)
            {
                if (_lastObjectMapSelected != null && MapDisplay.StampObjectMap == null)
                    MapDisplay.StampObjectMap = _lastObjectMapSelected.Clone();
            }
            else
            {
                MapDisplay.StampObjectMap = null;
            }

            if (MapDisplay.StampObjectMap != null)
            {
                MapDisplay.StampObjectMap.Position = new Vector2(_currentPosition.X, _currentPosition.Y);
            }

            if (_isMove)
            {
                var position = new Vector2(_currentPosition.X - _offset.X, _currentPosition.Y - _offset.Y);
                MapDisplay.ActualObjectMap.Position = position;
            }
        }

        private void MapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _currentPosition = CurrentPosition(e);

            switch (MapDisplay.DrawingMode)
            {
                case DrawingMode.SegmentSelection:
                    MapDisplayMouseDownSegmentSelection();
                    break;
                case DrawingMode.CollisionMap:
                    MapDisplayMouseDownCollisionMap();
                    break;
            }
        }

        private void MapDisplayMouseDownCollisionMap()
        {
            MapDisplay.SetGridState(_currentPosition.X, _currentPosition.Y);
        }

        private void MapDisplayMouseDownSegmentSelection()
        {
            var layer = GetSelectedLayer();
            if (!LayerIsSelected(layer))
                return;

            if (_controlIsPressed)
            {
                var objectMap = MapDisplay.StampObjectMap.Clone();
                layer.AddObjectMap(objectMap, MapDisplay.Position);
                objectMap.Position = new Vector2(_currentPosition.X, _currentPosition.Y);

                UpdateListBoxObject(layer);
                UpdateView();
                return;
            }

            var scale = layer.Scale * MapDisplay.Zoom;
            var mouseSource = new Rectangle(_currentPosition.X, _currentPosition.Y, 1, 1);

            var actualObjectMap = layer.ObjectsInMap
                .OrderByDescending(o => o.DrawOrder)
                .FirstOrDefault(o => o.Scaling(scale)
                .Intersects(mouseSource));

            MapDisplay.ActualObjectMap = actualObjectMap;

            if (MapDisplay.ActualObjectMap == null)
                return;

            ListBoxObject.SelectedItem = MapDisplay.ActualObjectMap;

            _isMove = true;
            _offset = _currentPosition - new Size((int)MapDisplay.ActualObjectMap.Position.X, (int)MapDisplay.ActualObjectMap.Position.Y);
        }

        private void MapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMove)
                _isMove = false;

            UpdateView();
        }

        private void VScrollBarMapDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollMapDisplay();
        }

        private void HScrollBarMapDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollMapDisplay();
        }

        private void ListBoxLayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var layer = ListBoxLayer.SelectedItem as Layer;
            if (layer == null)
                return;

            var layerForm = new LayerForm(layer);
            var result = layerForm.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    UpdateListBoxLayer();
                    ListBoxLayer.SelectedItem = layerForm.Layer;
                    break;
                case DialogResult.No:
                    MapDisplay.Map.Layers.Remove(layerForm.Layer);
                    UpdateListBoxLayer();
                    break;
            }
        }

        private void ListBoxLayer_SelectedValueChanged(object sender, EventArgs e)
        {
            var layer = GetSelectedLayer();
            if (layer == null)
                return;

            UpdateListBoxObject(layer);
        }

        private void ListBoxLayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (MessageBox.Show("Are you sure? This is delete all objects!", "Delete Layer Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var layer = ListBoxLayer.SelectedItem as Layer;
            if (layer == null)
                return;

            MapDisplay.Map.Layers.Remove(layer);
            UpdateListBoxLayer();
        }

        private void ListBoxLayer_DragDrop(object sender, DragEventArgs e)
        {
            UpdateLayerIndex();
        }

        private void ListBoxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var layer = (Layer)ListBoxLayer.SelectedItem;
            MapDisplay.ActualLayer = layer;
            UpdateListBoxObject(layer);
        }

        private void ListBoxObject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (MessageBox.Show("Are you sure this ?", "Delete Object Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var objectMap = ListBoxObject.SelectedItem as ObjectMap;
            if (objectMap == null)
                return;

            var layer = GetSelectedLayer();
            if (layer == null)
                return;

            layer.ObjectsInMap.Remove(objectMap);
            UpdateListBoxObject(layer);
            UpdateObjectIndex();
        }

        private void ListBoxObject_DragDrop(object sender, DragEventArgs e)
        {
            UpdateObjectIndex();
        }

        private void ListBoxObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastObjectMapSelected = (ObjectMap)ListBoxObject.SelectedItem;
        }

        private void RadioListBoxDrawingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapDisplay.DrawingMode = RadioListBoxDrawingMode.SelectedItem.ToString().ToEnum<DrawingMode>();
        }

        private void TextZoom_TextChanged(object sender, EventArgs e)
        {
            MapDisplay.Zoom = MathHelper.Clamp(TextZoom.Text.ToInt32() / 100f, 0.1f, 1f);
        }

        private void LoadMetadataMap(MetadataMap metadataMap)
        {
            ObjectDisplay.MetadataMap = metadataMap;
            MapDisplay.MetadataMap = metadataMap;

            var metadataFileName = ObjectDisplay.MetadataMap.FileName;
            if (!File.Exists(_accessMap.GetBinaryFullPath(metadataFileName)))
                return;

            var name = _accessMap.GetSpecifcFolderWithoutExtension(metadataFileName);
            ObjectDisplay.LoadContent(name);
            VScrollBarObjectDisplay.Maximum = (int)((ObjectDisplay.TotalHeight - ObjectDisplay.Height) / ScrollScale);

            MapDisplay.LoadContent(name);
            MapDisplay.Map.MetadataFileName = metadataMap.FileName;
        }

        private void LoadMap(Map map)
        {
            var actionLoadMetadataMap =
                new ActionLoadMetadataMap(_accessMap.GetFullPathWithoutExtension(map.MetadataFileName + ".bmm"));
            actionLoadMetadataMap.Executar();
            LoadMetadataMap(actionLoadMetadataMap.MetadataMap);

            MapDisplay.Map = map;
            UpdateListBoxLayer();

            TextBoxMapWidth.Text = map.Width.ToString(CultureInfo.InvariantCulture);
            TextBoxMapHeight.Text = map.Height.ToString(CultureInfo.InvariantCulture);
        }

        private void UpdateLayerIndex()
        {
            for (int i = 0; i < ListBoxLayer.Items.Count; i++)
            {
                var layer = MapDisplay.Map.Layers.FirstOrDefault(o => o == (Layer)ListBoxObject.Items[i]);
                layer.Index = i + 1;
            }
            UpdateView();
        }

        private void UpdateObjectIndex()
        {
            var layer = GetSelectedLayer();
            if (!LayerIsSelected(layer))
                return;

            for (int i = 0; i < ListBoxObject.Items.Count; i++)
            {
                var objectMap = layer.ObjectsInMap.FirstOrDefault(o => o == (ObjectMap)ListBoxObject.Items[i]);
                objectMap.DrawOrder = i + 1;
            }
            UpdateView();
        }

        private void UpdateView()
        {
            ObjectDisplay.Invalidate();
            MapDisplay.Invalidate();
        }

        private void UpdateScrollObjectDisplay()
        {
            ObjectDisplay.Position.Y = -VScrollBarObjectDisplay.Value * ScrollScale;
            UpdateView();
        }

        private void UpdateScrollMapDisplay()
        {
            MapDisplay.Position.X = -HScrollBarMapDisplay.Value * ScrollScale;
            MapDisplay.Position.Y = -VScrollBarMapDisplay.Value * ScrollScale;
            UpdateView();
        }

        private void UpdateListBoxObject(Layer layer)
        {
            ListBoxObject.Items.Clear();
            ListBoxObject.Items.AddRange(layer.ObjectsInMap.OrderBy(o => o.DrawOrder).ToArray());
            ListBoxObject.Invalidate();
        }

        private void UpdateListBoxLayer()
        {
            ListBoxLayer.Items.Clear();
            ListBoxLayer.Items.AddRange(MapDisplay.Map.Layers.OrderBy(m => m.Index).ToArray());
            ListBoxLayer.Invalidate();
        }

        private Point CurrentPosition(MouseEventArgs e)
        {
            return new Point((int)(e.Location.X - MapDisplay.Position.X), (int)(e.Location.Y - MapDisplay.Position.Y));
        }

        private Layer GetSelectedLayer()
        {
            var layer = MapDisplay.ActualLayer;
            //var layer = MapDisplay.Map.Layers.FirstOrDefault(l => l == ListBoxLayer.SelectedItem);
            if (layer == null && ListBoxLayer.Items.Count == 1)
                layer = (Layer)(ListBoxLayer.SelectedItem = ListBoxLayer.Items[0]);

            return layer;
        }

        private static bool LayerIsSelected(Layer layer)
        {
            if (layer != null)
                return true;

            MessageBox.Show("Select a layer to add this object!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
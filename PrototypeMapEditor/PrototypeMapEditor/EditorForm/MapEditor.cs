using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using PrototypeMapEditor.Core;
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
        private bool _isMove;

        public MapEditor()
        {
            InitializeComponent();

            Application.Idle += delegate { UpdateView(); };
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            _accessMap = new AccessMap();
        }

        private void ButtonImportMetadata_Click(object sender, EventArgs e)
        {
            var importMetadataMapDialog = new ImportMetadataMapDialog();
            if (importMetadataMapDialog.ShowDialog() == DialogResult.OK)
            {
                var actionLoadMetadataMap = importMetadataMapDialog.ActionLoadMetadataMap;

                ObjectDisplay.MetadataMap = actionLoadMetadataMap.MetadataMap;
                MapDisplay.MetadataMap = actionLoadMetadataMap.MetadataMap;

                var nomeDoArquivo = ObjectDisplay.MetadataMap.FileName;
                if (!File.Exists(_accessMap.GetFullPath(nomeDoArquivo)))
                    return;

                var name = _accessMap.GetSpecifcFolderWithoutExtension(nomeDoArquivo);
                ObjectDisplay.LoadContent(name);
                VScrollBarObjectDisplay.Maximum = (int)((ObjectDisplay.TotalHeight - ObjectDisplay.Height) / ScrollScale);

                MapDisplay.LoadContent(name);
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

        private void ObjectDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            var objetoDoMapa = ObjectDisplay.SelectObject(e.X, e.Y);
            if (objetoDoMapa == null)
                return;

            var layer = GetSelectedLayer();
            if (!LayerIsSelected(layer))
                return;

            layer.AddObjectMap(objetoDoMapa.Clone());
            UpdateListBoxObject(layer);
        }

        private void ObjectDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            var objectMap = ObjectDisplay.SelectObject(e.X, e.Y);
            Cursor = objectMap != null ? Cursors.Hand : Cursors.Default;
        }

        private void ObjectDisplay_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void VScrollBarObjectDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollObjectDisplay();
        }

        private void MapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            var layer = GetSelectedLayer();
            if (LayerIsSelected(layer))
            {
                var scale = layer.Scale;
                var mouseSource = new Rectangle(_currentPosition.X, _currentPosition.Y, 1, 1);

                Cursor = layer.ObjectsInMap
                    .OrderByDescending(o => o.DrawOrder)
                    .Any(o => o.Scaling(scale)
                    .Intersects(mouseSource)) ? Cursors.Hand : Cursors.Default;
            }

            if (!_isMove)
                return;

            _currentPosition = CurrentPosition(e);
            MapDisplay.ActualObjectMap.Position = new Vector2(_currentPosition.X - _offset.X, _currentPosition.Y - _offset.Y);

            UpdateView();
        }

        private void MapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var layer = GetSelectedLayer();
            if (!LayerIsSelected(layer))
                return;

            _currentPosition = CurrentPosition(e);

            var scale = layer.Scale;
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

        private void MapDisplay_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
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
            var layer = MapDisplay.Map.Layers.FirstOrDefault(l => l == ListBoxLayer.SelectedItem);
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
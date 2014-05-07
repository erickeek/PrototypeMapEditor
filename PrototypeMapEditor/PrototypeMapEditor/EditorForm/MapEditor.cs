using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using PrototypeMapEditor.Core;
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

        private void UpdateView()
        {
            ObjectDisplay.Invalidate();
            MapDisplay.Invalidate();
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            _accessMap = new AccessMap();
        }

        private void ButtonImportMetadata_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                AutoUpgradeEnabled = true,
                AddExtension = true,
                Title = "Import metadata map",
                DefaultExt = "bmm",
                Filter = "Bantu Metadata Map (*.bmm)|*.bmm",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var acaoCarregarMetdadosDoMapa = new ActionLoadMetadataMap(dialog.FileName);
                acaoCarregarMetdadosDoMapa.Executar();

                ObjectDisplay.MetadataMap = acaoCarregarMetdadosDoMapa.MetadataMap;
                MapDisplay.MetadataMap = acaoCarregarMetdadosDoMapa.MetadataMap;

                if (!File.Exists(dialog.FileName))
                    return;

                var nomeDoArquivo = ObjectDisplay.MetadataMap.FileName;
                if (!File.Exists(_accessMap.GetFullPath(nomeDoArquivo)))
                    return;

                var name = _accessMap.GetSpecifcFolderWithoutExtension(nomeDoArquivo);
                ObjectDisplay.LoadContent(name);
                VScrollBarObjectDisplay.Maximum = (int)((ObjectDisplay.TotalHeight - ObjectDisplay.Height) / ScrollScale);

                MapDisplay.LoadContent(name);
            }
        }

        private void ObjectDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            var objetoDoMapa = ObjectDisplay.SelectObject(e.X, e.Y);
            if (objetoDoMapa == null)
                return;

            var layer = MapDisplay.Map.Layers.FirstOrDefault(l => l == ListBoxLayer.SelectedItem);
            if (layer == null)
            {
                MessageBox.Show("Select a layer to add this object!", "Warning");
                return;
            }

            layer.AddObjectMap(objetoDoMapa.Clone());
            UpdateListBoxObject(layer);
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

        private void VScrollBarObjectDisplay_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScrollObjectDisplay();
        }

        private void UpdateScrollObjectDisplay()
        {
            ObjectDisplay.Position.Y = -VScrollBarObjectDisplay.Value * ScrollScale;
            UpdateView();
        }

        private void MapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var layer = MapDisplay.Map.Layers.FirstOrDefault(l => l == ListBoxLayer.SelectedItem);
                if (layer == null)
                {
                    MessageBox.Show("Select a layer to add this object!", "Warning");
                    return;
                }

                _currentPosition = CurrentPosition(e);

                var actualObjectMap = layer.ObjectsInMap
                    .FirstOrDefault(o =>
                        new Rectangle((int)o.Position.X, (int)o.Position.Y, o.Source.Width, o.Source.Height)
                            .Intersects(new Rectangle(_currentPosition.X, _currentPosition.Y, 1, 1))
                    );

                MapDisplay.ActualObjectMap = actualObjectMap;

                if (MapDisplay.ActualObjectMap == null)
                    return;

                _isMove = true;
                _offset = _currentPosition - new Size((int)MapDisplay.ActualObjectMap.Position.X, (int)MapDisplay.ActualObjectMap.Position.Y);
            }
        }

        private Point CurrentPosition(MouseEventArgs e)
        {
            return new Point((int)(e.Location.X - MapDisplay.Position.X), (int)(e.Location.Y - MapDisplay.Position.Y));
        }

        private void MapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMove)
                return;

            _currentPosition = CurrentPosition(e);
            MapDisplay.ActualObjectMap.Position = new Vector2(_currentPosition.X - _offset.X, _currentPosition.Y - _offset.Y);

            UpdateView();
        }

        private void MapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMove)
                _isMove = false;

            UpdateView();
        }

        private void ListBoxLayer_SelectedValueChanged(object sender, EventArgs e)
        {
            var layer = MapDisplay.Map.Layers.FirstOrDefault(l => l == ListBoxLayer.SelectedItem);
            if (layer == null)
                return;

            UpdateListBoxObject(layer);
        }

        private void UpdateListBoxObject(Layer layer)
        {
            ListBoxObject.Items.Clear();
            ListBoxObject.Items.AddRange(layer.ObjectsInMap.ToArray());
            ListBoxObject.Invalidate();
        }

        private void UpdateListBoxLayer()
        {
            ListBoxLayer.Items.Clear();
            ListBoxLayer.Items.AddRange(MapDisplay.Map.Layers.OrderBy(m => m.Index).ToArray());
            ListBoxLayer.Invalidate();
        }

        private void ListBoxLayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var layer = ListBoxLayer.SelectedItem as Layer;
            if (layer == null)
                return;

            MapDisplay.Map.Layers.Remove(layer);
            UpdateListBoxLayer();
        }

        private void ListBoxObject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            if (MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var objectMap = ListBoxObject.SelectedItem as ObjectMap;
            if (objectMap == null)
                return;

            var layer = MapDisplay.Map.Layers.FirstOrDefault(l => l == ListBoxLayer.SelectedItem);
            if (layer == null)
                return;

            layer.ObjectsInMap.Remove(objectMap);
            UpdateListBoxObject(layer);
        }
    }
}
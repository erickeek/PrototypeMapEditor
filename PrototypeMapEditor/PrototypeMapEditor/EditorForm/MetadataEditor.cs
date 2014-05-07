using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PrototypeMapEditor.Core;
using PrototypeMapEditor.IO;
using Point = System.Drawing.Point;
using PrototypeMapEditor.Helper;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace PrototypeMapEditor.EditorForm
{
    // Salvar os arquivos .bdm => Bantu Data Map e .bmm Bantu Metadata Map que na verdade são arquivos json
    // Salvar os arquivos .bdc => Bantu Data Char e .bmc Bantu Metadata Char
    // Compactá-los num .bfz Bantu File Zip
    public sealed partial class MetadataEditor : Form
    {
        private const int ScrollScale = 10;

        private AccessMap _accessMap;
        private Point _startPosition;
        private Point _currentPosition;
        private Point _offset;
        private bool _isDrawing;
        private bool _isMove;

        public MetadataEditor()
        {
            InitializeComponent();
            //DoubleBuffered = true;
            //SetStyle(ControlStyles.ResizeRedraw, true);

            KeyPreview = true;

            Application.Idle += delegate { UpdateView(); };
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            _accessMap = new AccessMap();
            ListBoxMaps.Items.AddRange(_accessMap.List());
        }

        private ObjectMap GetObjectMap()
        {
            return new ObjectMap
                {
                    Source = new Rectangle(
                        Math.Min(_startPosition.X, _currentPosition.X),
                        Math.Min(_startPosition.Y, _currentPosition.Y),
                        Math.Abs(_startPosition.X - _currentPosition.X),
                        Math.Abs(_startPosition.Y - _currentPosition.Y)
                    )
                };
        }

        private void MapDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MetadataDisplay.ObjectsInMap.ForEach(c => c.Selected = false);

                _currentPosition = _startPosition = CurrentPosition(e);

                var actualObjectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(o => o.Source.Intersects(new Rectangle(_currentPosition.X, _currentPosition.Y, 1, 1)));
                if (actualObjectMap == null)
                {
                    _isDrawing = true;
                }
                else
                {
                    _isMove = true;

                    MetadataDisplay.ActualObjectMap = actualObjectMap;
                    MetadataDisplay.ActualObjectMap.Selected = true;

                    _offset = _currentPosition - new Size(
                        MetadataDisplay.ActualObjectMap.Source.X,
                        MetadataDisplay.ActualObjectMap.Source.Y
                    );
                }
            }
        }

        private void MapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                var rc = GetObjectMap();
                if (rc.Source.Width > 0 && rc.Source.Height > 0)
                    MetadataDisplay.ObjectsInMap.Add(rc);
            }

            if (_isMove)
            {
                _isMove = false;
            }

            UpdateView();
        }

        private void MapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            _currentPosition = CurrentPosition(e);

            if (_isDrawing)
            {
                MetadataDisplay.ActualObjectMap = GetObjectMap();
            }

            if (_isMove)
            {
                MetadataDisplay.ActualObjectMap.Source.X = _currentPosition.X - _offset.X;
                MetadataDisplay.ActualObjectMap.Source.Y = _currentPosition.Y - _offset.Y;

                MetadataDisplay.Invalidate();
            }

            if (_isDrawing || _isMove)
            {
                UpdateView();
            }
            else
            {
                MetadataDisplay.ActualObjectMap = null;
            }
        }

        private Point CurrentPosition(MouseEventArgs e)
        {
            return new Point((int)(e.Location.X - MetadataDisplay.Position.X), (int)(e.Location.Y - MetadataDisplay.Position.Y));
        }

        private void ButtonLoadMap_Click(object sender, EventArgs e)
        {
            var selectedFile = (string)ListBoxMaps.SelectedItem;

            if (selectedFile == null)
                return;

            var fileName = _accessMap.GetFullPath(selectedFile);
            if (!File.Exists(fileName))
                return;

            MetadataDisplay.LoadContent(_accessMap.GetSpecifcFolderWithoutExtension(selectedFile));

            HScrollBarMetadataDisplay.Maximum = (MetadataDisplay.Texture.Width - MetadataDisplay.Width) / ScrollScale;
            VScrollBarMetadataDisplay.Maximum = (MetadataDisplay.Texture.Height - MetadataDisplay.Height) / ScrollScale;
        }

        private void HScrollBarMetadataEditor_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
        }

        private void VScrollBarMetatadaEditor_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
        }

        private void UpdateScroll()
        {
            MetadataDisplay.Position.X = -HScrollBarMetadataDisplay.Value * ScrollScale;
            MetadataDisplay.Position.Y = -VScrollBarMetadataDisplay.Value * ScrollScale;
            UpdateView();
        }

        private void ListBoxMaps_DoubleClick(object sender, EventArgs e)
        {
            ButtonLoadMap_Click(null, e);
        }

        private void UpdateView()
        {
            MetadataDisplay.Invalidate();

            if (MetadataDisplay.ActualObjectMap != null)
            {
                ButtonRemove.Enabled = TextName.Enabled = TextX.Enabled = TextY.Enabled = TextWidth.Enabled = TextHeight.Enabled = true;

                TextX.Text = MetadataDisplay.ActualObjectMap.Source.X.ToString(CultureInfo.InvariantCulture);
                TextY.Text = MetadataDisplay.ActualObjectMap.Source.Y.ToString(CultureInfo.InvariantCulture);
                TextWidth.Text = MetadataDisplay.ActualObjectMap.Source.Width.ToString(CultureInfo.InvariantCulture);
                TextHeight.Text = MetadataDisplay.ActualObjectMap.Source.Height.ToString(CultureInfo.InvariantCulture);
                TextName.Text = MetadataDisplay.ActualObjectMap.Name;
            }
            else if (MetadataDisplay.ObjectsInMap.All(c => !c.Selected))
            {
                ButtonRemove.Enabled = TextName.Enabled = TextX.Enabled = TextY.Enabled = TextWidth.Enabled = TextHeight.Enabled = false;
            }
        }

        private void TextX_TextChanged(object sender, EventArgs e)
        {
            var objectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(c => c.Selected);
            if (objectMap != null)
                objectMap.Source.X = TextX.Text.ToInt32();
        }

        private void TextY_TextChanged(object sender, EventArgs e)
        {
            var objectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(c => c.Selected);
            if (objectMap != null)
                objectMap.Source.Y = TextY.Text.ToInt32();
        }

        private void TextWidth_TextChanged(object sender, EventArgs e)
        {
            var objectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(c => c.Selected);
            if (objectMap != null)
                objectMap.Source.Width = TextWidth.Text.ToInt32();
        }

        private void TextHeight_TextChanged(object sender, EventArgs e)
        {
            var objectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(c => c.Selected);
            if (objectMap != null)
                objectMap.Source.Height = TextHeight.Text.ToInt32();
        }

        private void TextName_TextChanged(object sender, EventArgs e)
        {
            var objectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(c => c.Selected);
            if (objectMap != null)
                objectMap.Name = TextName.Text;
        }

        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = ((TextBox)sender);

            var valor = textBox.Text.ToInt32();
            if (e.KeyCode == Keys.Up)
            {
                valor = Math.Min(++valor, 1000);
                textBox.Text = valor.ToString(CultureInfo.InvariantCulture);
            }
            else if (e.KeyCode == Keys.Down)
            {
                valor = Math.Max(--valor, 0);
                textBox.Text = valor.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            var objectMap = MetadataDisplay.ObjectsInMap.FirstOrDefault(c => c.Selected);
            if (objectMap != null)
            {
                MetadataDisplay.ObjectsInMap.Remove(objectMap);
                MetadataDisplay.ActualObjectMap = null;
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            var selectedFile = (string)ListBoxMaps.SelectedItem;

            if (selectedFile == null)
                return;

            var fileName = _accessMap.GetFullPath(selectedFile);
            if (!File.Exists(fileName))
                return;

            if (!MetadataDisplay.ObjectsInMap.Any())
            {
                MessageBox.Show("Create objects before exporting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var objetoDoMapa = MetadataDisplay.ObjectsInMap.FirstOrDefault(o => string.IsNullOrWhiteSpace(o.Name));
            if (objetoDoMapa != null)
            {
                MessageBox.Show("Name all the objects before exporting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetadataDisplay.ObjectsInMap.ForEach(c => c.Selected = false);
                objetoDoMapa.Selected = true;
                MetadataDisplay.ActualObjectMap = objetoDoMapa;
                UpdateView();
                return;
            }

            var dialog = new SaveFileDialog
                {
                    AutoUpgradeEnabled = true,
                    AddExtension = true,
                    Title = "Export metadata map",
                    DefaultExt = "bmm",
                    Filter = "Bantu Metadata Map (*.bmm)|*.bmm",
                    FileName = "Untitled"
                };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var action = new ActionSaveMetadataMap(new MetadataMap
                    {
                        ObjectsInMap = MetadataDisplay.ObjectsInMap,
                        FileName = selectedFile
                    }, dialog.FileName);
                action.Executar();
            }
        }

        private void ButtonImport_Click(object sender, EventArgs e)
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

                var metadadoMapa = acaoCarregarMetdadosDoMapa.MetadataMap;

                ListBoxMaps.SelectedItem = metadadoMapa.FileName;
                ButtonLoadMap_Click(null, e);

                MetadataDisplay.ObjectsInMap = metadadoMapa.ObjectsInMap.ToList();
                UpdateView();
            }
        }
    }
}
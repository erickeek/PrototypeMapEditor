using System;
using System.Drawing;
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

        private Point _startPosition;
        private Point _currentPosition;
        private bool _isDrawing;
        private bool _isMove;

        private AcessaMapa _acessaMapa;
        private Point _offset;

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
            _acessaMapa = new AcessaMapa();
            ListBoxMaps.Items.AddRange(_acessaMapa.Listar());
        }

        private ObjetoDoMapa GetObjetosDoMapa()
        {
            return new ObjetoDoMapa
                {
                    Fonte = new Rectangle(
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
                _metadataDisplay.ObjetosDoMapa.ForEach(c => c.Selecionado = false);

                _currentPosition = _startPosition = new Point((int)(e.Location.X - _metadataDisplay.Position.X), (int)(e.Location.Y - _metadataDisplay.Position.Y));

                var objetosDoMapaAtual = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(o => o.Fonte.Intersects(new Rectangle(_currentPosition.X, _currentPosition.Y, 1, 1)));
                if (objetosDoMapaAtual == null)
                {
                    _isDrawing = true;
                }
                else
                {
                    _isMove = true;

                    _metadataDisplay.ObjetosDoMapaAtual = objetosDoMapaAtual;
                    _metadataDisplay.ObjetosDoMapaAtual.Selecionado = true;

                    _offset = _currentPosition - new Size(
                        _metadataDisplay.ObjetosDoMapaAtual.Fonte.X,
                        _metadataDisplay.ObjetosDoMapaAtual.Fonte.Y
                    );
                }
            }
        }

        private void MapDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                var rc = GetObjetosDoMapa();
                if (rc.Fonte.Width > 0 && rc.Fonte.Height > 0)
                    _metadataDisplay.ObjetosDoMapa.Add(rc);
            }

            if (_isMove)
            {
                _isMove = false;
            }

            UpdateView();
        }

        private void MapDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            _currentPosition = new Point((int)(e.Location.X - _metadataDisplay.Position.X), (int)(e.Location.Y - _metadataDisplay.Position.Y));

            if (_isDrawing)
            {
                _metadataDisplay.ObjetosDoMapaAtual = GetObjetosDoMapa();
            }

            if (_isMove)
            {
                _metadataDisplay.ObjetosDoMapaAtual.Fonte.X = _currentPosition.X - _offset.X;
                _metadataDisplay.ObjetosDoMapaAtual.Fonte.Y = _currentPosition.Y - _offset.Y;

                _metadataDisplay.Invalidate();
            }

            if (_isDrawing || _isMove)
            {
                UpdateView();
            }
            else
            {
                _metadataDisplay.ObjetosDoMapaAtual = null;
            }
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            var selectedFile = (string)ListBoxMaps.SelectedItem;

            if (selectedFile == null)
                return;

            var fileName = _acessaMapa.RecuperarCaminhoCompleto(selectedFile);
            if (!File.Exists(fileName))
                return;

            _metadataDisplay.LoadContent(_acessaMapa.RecuperarCaminhoComPastaEspecificaSemExtensao(selectedFile));

            hScrollBar1.Maximum = (_metadataDisplay.Texture.Width - _metadataDisplay.Width) / ScrollScale;
            vScrollBar1.Maximum = (_metadataDisplay.Texture.Height - _metadataDisplay.Height) / ScrollScale;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateScroll();
        }

        private void UpdateScroll()
        {
            _metadataDisplay.Position.X = -hScrollBar1.Value * ScrollScale;
            _metadataDisplay.Position.Y = -vScrollBar1.Value * ScrollScale;
            UpdateView();
        }

        private void listBoxMaps_DoubleClick(object sender, EventArgs e)
        {
            btnLoadMap_Click(null, e);
        }

        private void UpdateView()
        {
            _metadataDisplay.Invalidate();

            if (_metadataDisplay.ObjetosDoMapaAtual != null)
            {
                BtnExcluir.Enabled = TxtName.Enabled = TxtX.Enabled = TxtY.Enabled = TxtWidth.Enabled = TxtHeight.Enabled = true;

                TxtX.Text = _metadataDisplay.ObjetosDoMapaAtual.Fonte.X.ToString();
                TxtY.Text = _metadataDisplay.ObjetosDoMapaAtual.Fonte.Y.ToString();
                TxtWidth.Text = _metadataDisplay.ObjetosDoMapaAtual.Fonte.Width.ToString();
                TxtHeight.Text = _metadataDisplay.ObjetosDoMapaAtual.Fonte.Height.ToString();
                TxtName.Text = _metadataDisplay.ObjetosDoMapaAtual.Nome;
            }
            else if (_metadataDisplay.ObjetosDoMapa.All(c => !c.Selecionado))
            {
                BtnExcluir.Enabled = TxtName.Enabled = TxtX.Enabled = TxtY.Enabled = TxtWidth.Enabled = TxtHeight.Enabled = false;
            }
        }

        private void TxtX_TextChanged(object sender, EventArgs e)
        {
            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(c => c.Selecionado);
            if (objetoDoMapa != null)
                objetoDoMapa.Fonte.X = TxtX.Text.ToInt32();
        }

        private void TxtY_TextChanged(object sender, EventArgs e)
        {
            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(c => c.Selecionado);
            if (objetoDoMapa != null)
                objetoDoMapa.Fonte.Y = TxtY.Text.ToInt32();
        }

        private void TxtWidth_TextChanged(object sender, EventArgs e)
        {
            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(c => c.Selecionado);
            if (objetoDoMapa != null)
                objetoDoMapa.Fonte.Width = TxtWidth.Text.ToInt32();
        }

        private void TxtHeight_TextChanged(object sender, EventArgs e)
        {
            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(c => c.Selecionado);
            if (objetoDoMapa != null)
                objetoDoMapa.Fonte.Height = TxtHeight.Text.ToInt32();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(c => c.Selecionado);
            if (objetoDoMapa != null)
                objetoDoMapa.Nome = TxtName.Text;
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = ((TextBox)sender);

            var valor = textBox.Text.ToInt32();
            if (e.KeyCode == Keys.Up)
            {
                valor = Math.Min(++valor, 1000);
                textBox.Text = valor.ToString();
            }
            else if (e.KeyCode == Keys.Down)
            {
                valor = Math.Max(--valor, 0);
                textBox.Text = valor.ToString();
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(c => c.Selecionado);
            if (objetoDoMapa != null)
            {
                _metadataDisplay.ObjetosDoMapa.Remove(objetoDoMapa);
                _metadataDisplay.ObjetosDoMapaAtual = null;
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            var selectedFile = (string)ListBoxMaps.SelectedItem;

            if (selectedFile == null)
                return;

            var fileName = _acessaMapa.RecuperarCaminhoCompleto(selectedFile);
            if (!File.Exists(fileName))
                return;

            if (!_metadataDisplay.ObjetosDoMapa.Any())
            {
                MessageBox.Show("Crie objetos antes de exportar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var objetoDoMapa = _metadataDisplay.ObjetosDoMapa.FirstOrDefault(o => string.IsNullOrWhiteSpace(o.Nome));
            if (objetoDoMapa != null)
            {
                MessageBox.Show("Nomeie todos os objetos antes de exportar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _metadataDisplay.ObjetosDoMapa.ForEach(c => c.Selecionado = false);
                objetoDoMapa.Selecionado = true;
                _metadataDisplay.ObjetosDoMapaAtual = objetoDoMapa;
                UpdateView();
                return;
            }

            var dialog = new SaveFileDialog
                {
                    AutoUpgradeEnabled = true,
                    AddExtension = true,
                    Title = "Exportar metadado do mapa",
                    DefaultExt = "bmm",
                    Filter = "Bantu Metadata Map (*.bmm)|*.bmm",
                    FileName = "Untitled"
                };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var acaoSalvarMetadadosDoMapa = new AcaoSalvarMetadadosDoMapa(new MetadadoMapa
                    {
                        ObjetoDoMapas = _metadataDisplay.ObjetosDoMapa,
                        NomeDoArquivo = selectedFile
                    }, dialog.FileName);
                acaoSalvarMetadadosDoMapa.Executar();
            }
        }

        private void BtnInportar_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
                {
                    AutoUpgradeEnabled = true,
                    AddExtension = true,
                    Title = "Importar metadado do mapa",
                    DefaultExt = "bmm",
                    Filter = "Bantu Metadata Map (*.bmm)|*.bmm",
                };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var acaoCarregarMetdadosDoMapa = new AcaoCarregarMetdadosDoMapa(dialog.FileName);
                acaoCarregarMetdadosDoMapa.Executar();

                var metadadoMapa = acaoCarregarMetdadosDoMapa.MetadadoMapa;

                ListBoxMaps.SelectedItem = metadadoMapa.NomeDoArquivo;
                btnLoadMap_Click(null, e);

                _metadataDisplay.ObjetosDoMapa = metadadoMapa.ObjetoDoMapas.ToList();
                UpdateView();
            }
        }
    }
}
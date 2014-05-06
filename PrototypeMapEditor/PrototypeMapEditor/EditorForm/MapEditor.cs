using System;
using System.IO;
using System.Windows.Forms;
using PrototypeMapEditor.IO;

namespace PrototypeMapEditor.EditorForm
{
    public partial class MapEditor : Form
    {
        private AcessaMapa _acessaMapa;

        public MapEditor()
        {
            InitializeComponent();

            Application.Idle += delegate { UpdateView(); };
        }

        private void UpdateView()
        {
            objectDisplay.Invalidate();
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            _acessaMapa = new AcessaMapa();
        }

        private void BtnImportarMetadado_Click(object sender, EventArgs e)
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

                objectDisplay.MetadadoMapa = acaoCarregarMetdadosDoMapa.MetadadoMapa;

                if (!File.Exists(dialog.FileName))
                    return;

                if (!File.Exists(_acessaMapa.RecuperarCaminhoCompleto(objectDisplay.MetadadoMapa.NomeDoArquivo)))
                    return;

                objectDisplay.LoadContent(_acessaMapa.RecuperarCaminhoComPastaEspecificaSemExtensao(objectDisplay.MetadadoMapa.NomeDoArquivo));
            }
        }
    }
}

using System.IO;
using Newtonsoft.Json;
using PrototypeMapEditor.Core;

namespace PrototypeMapEditor.IO
{
    public class AcaoCarregarMetdadosDoMapa
    {
        public MetadadoMapa MetadadoMapa { get; private set; }
        private readonly string _caminho;

        public AcaoCarregarMetdadosDoMapa(string caminho)
        {
            _caminho = caminho;
        }

        public void Executar()
        {
            var jsonText = File.ReadAllText(_caminho);
            MetadadoMapa = JsonConvert.DeserializeObject<MetadadoMapa>(jsonText);
        }
    }
}
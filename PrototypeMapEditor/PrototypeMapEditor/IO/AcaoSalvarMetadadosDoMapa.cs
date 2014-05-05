using System.IO;
using Newtonsoft.Json;
using PrototypeMapEditor.Core;

namespace PrototypeMapEditor.IO
{
    public class AcaoSalvarMetadadosDoMapa
    {
        private readonly MetadadoMapa _metadadoMapa;
        private readonly string _caminho;

        public AcaoSalvarMetadadosDoMapa(MetadadoMapa metadadoMapa, string caminho)
        {
            _metadadoMapa = metadadoMapa;
            _caminho = caminho;
        }

        public void Executar()
        {
            var jsonText = JsonConvert.SerializeObject(_metadadoMapa);
            // verificar se é do tipo bmm
            File.WriteAllText(_caminho, jsonText);
        }
    }
}
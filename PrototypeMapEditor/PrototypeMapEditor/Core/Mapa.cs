using System;
using System.Collections.Generic;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class Mapa
    {
        public string Nome { get; set; }
        public string NomeDoArquivo { get; set; }
        public List<Camada> Camadas { get; private set; }
        public int Largura { get; set; }
        public int Altura { get; set; }

        public Mapa()
        {
            Camadas = new List<Camada>();
        }

        public void AdicionarCamadas(Camada camada)
        {
            Camadas.Add(camada);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using PrototypeMapEditor.IO;

namespace PrototypeMapEditor.Core
{
    public class Mapa
    {
        public string Nome { get; set; }
        public string NomeDoArquivo { get; set; }
        public List<Camada> Camadas { get; private set; }

        public Mapa()
        {
            Camadas = new List<Camada>();
        }

        public void AdicionarCamadas(Camada camada)
        {
            Camadas.Add(camada);
        }
    }

    public class Camada
    {
        public int Profundidade { get; set; }
        public Color Cor { get; set; }
        public float Escala { get; set; }
        public List<ObjetoDoMapa> ObjetosDoMapa { get; private set; }

        public Camada()
        {
            ObjetosDoMapa = new List<ObjetoDoMapa>();
        }

        public void AdicionarObjetos(ObjetoDoMapa objeto)
        {
            ObjetosDoMapa.Add(objeto);
        }
    }

    [Serializable]
    public class ObjetoDoMapa
    {
        public string Nome { get; set; }

        [JsonConverter(typeof(RectangleConverter))]
        public Rectangle Fonte;

        [JsonIgnore]
        public bool Selecionado { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class Camada
    {
        // Index
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
}
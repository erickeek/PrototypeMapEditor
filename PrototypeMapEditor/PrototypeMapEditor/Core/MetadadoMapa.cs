using System;
using System.Collections.Generic;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class MetadadoMapa
    {
        public string NomeDoArquivo { get; set; }

        public IEnumerable<ObjetoDoMapa> ObjetoDoMapas { get; set; }
    }
}
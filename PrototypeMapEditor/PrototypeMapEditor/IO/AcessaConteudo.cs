using System.IO;
using System.Linq;

namespace PrototypeMapEditor.IO
{
    public abstract class AcessaConteudo
    {
        private const string DiretorioBase = @"Content";

        protected abstract string PastaEspecifica();

        protected string CaminhoCompleto()
        {
            return Path.Combine(DiretorioBase, PastaEspecifica());
        }

        public string[] Listar()
        {
            return Directory.GetFiles(CaminhoCompleto(), "*.xnb").Select(Path.GetFileNameWithoutExtension).ToArray();
        }

        public string RecuperarCaminhoCompleto(string selectedFile)
        {
            return Path.Combine(CaminhoCompleto(), selectedFile + ".xnb");
        }

        public string RecuperarCaminhoComPastaEspecificaSemExtensao(string selectedFile)
        {
            return Path.Combine(PastaEspecifica(), selectedFile);
        }
    }
}
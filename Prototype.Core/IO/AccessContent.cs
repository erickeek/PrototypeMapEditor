using System.IO;
using System.Linq;

namespace Prototype.Core.IO
{
    public abstract class AccessContent
    {
        private const string BaseDirectory = @"Content";

        protected abstract string GetSpecificFolder();

        private string FullPath()
        {
            return Path.Combine(BaseDirectory, GetSpecificFolder());
        }

        public string[] List()
        {
            return Directory.GetFiles(FullPath(), "*.xnb").Select(Path.GetFileNameWithoutExtension).ToArray();
        }

        public string GetBinaryFullPath(string selectedFile)
        {
            return Path.Combine(FullPath(), selectedFile + ".xnb");
        }

        public string GetFullPathWithoutExtension(string selectedFile)
        {
            return Path.Combine(FullPath(), selectedFile);
        }

        public string GetSpecifcFolderWithoutExtension(string selectedFile)
        {
            return Path.Combine(GetSpecificFolder(), selectedFile);
        }
    }
}
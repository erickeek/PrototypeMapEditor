using System.IO;
using System.Windows.Forms;
using Prototype.Core.IO;

namespace PrototypeMapEditor.CustomControls.Dialog
{
    public class ImportMetadataMapDialog
    {
        private readonly OpenFileDialog _dialog;

        public ActionLoadMetadataMap ActionLoadMetadataMap { get; private set; }

        public ImportMetadataMapDialog()
        {
            _dialog = new OpenFileDialog
               {
                   AutoUpgradeEnabled = true,
                   AddExtension = true,
                   Title = "Import metadata map",
                   DefaultExt = "bmm",
                   Filter = "Bantu Metadata Map (*.bmm)|*.bmm",
               };
        }

        public DialogResult ShowDialog()
        {
            var result = _dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ActionLoadMetadataMap = new ActionLoadMetadataMap(_dialog.FileName);
                ActionLoadMetadataMap.Executar();

                if (!File.Exists(_dialog.FileName))
                    return DialogResult.Cancel;
            }

            return result;
        }
    }
}
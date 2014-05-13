using System.IO;
using System.Windows.Forms;
using Prototype.Core.IO;

namespace PrototypeMapEditor.CustomControls.Dialog
{
    public class ImportMapDialog
    {
        private readonly OpenFileDialog _dialog;

        public ActionLoadMap ActionLoadMap { get; private set; }

        public ImportMapDialog()
        {
            _dialog = new OpenFileDialog
            {
                AutoUpgradeEnabled = true,
                AddExtension = true,
                Title = "Import map",
                DefaultExt = "bdm",
                Filter = "Bantu Data Map (*.bdm)|*.bdm",
            };
        }

        public DialogResult ShowDialog()
        {
            var result = _dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ActionLoadMap = new ActionLoadMap(_dialog.FileName);
                ActionLoadMap.Executar();

                if (!File.Exists(_dialog.FileName))
                    return DialogResult.Cancel;
            }

            return result;
        }
    }
}

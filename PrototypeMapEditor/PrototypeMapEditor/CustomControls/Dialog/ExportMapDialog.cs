using System.Windows.Forms;
using PrototypeMapEditor.Core;
using PrototypeMapEditor.IO;

namespace PrototypeMapEditor.CustomControls.Dialog
{
    public class ExportMapDialog
    {
        private readonly Map _map;
        private readonly SaveFileDialog _dialog;

        public ExportMapDialog(Map map)
        {
            _map = map;

            _dialog = new SaveFileDialog
            {
                AutoUpgradeEnabled = true,
                AddExtension = true,
                Title = "Export map",
                DefaultExt = "bmm",
                Filter = "Bantu Data Map (*.bdm)|*.bdm",
                FileName = "Untitled"
            };
        }

        public DialogResult ShowDialog()
        {
            var result = _dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var action = new ActionSaveMap(_map, _dialog.FileName);
                action.Executar();
            }

            return result;
        }
    }
}

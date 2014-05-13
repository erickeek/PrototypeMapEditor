using System.Collections.Generic;
using System.Windows.Forms;
using Prototype.Core;
using Prototype.Core.IO;

namespace PrototypeMapEditor.CustomControls.Dialog
{
    public class ExportMetadataMapDialog
    {
        private readonly SaveFileDialog _dialog;

        private readonly IEnumerable<ObjectMap> _objectsInMap;
        private readonly string _selectedFile;

        public ExportMetadataMapDialog(IEnumerable<ObjectMap> objectsInMap, string selectedFile)
        {
            _objectsInMap = objectsInMap;
            _selectedFile = selectedFile;
            _dialog = new SaveFileDialog
            {
                AutoUpgradeEnabled = true,
                AddExtension = true,
                Title = "Export metadata map",
                DefaultExt = "bmm",
                Filter = "Bantu Metadata Map (*.bmm)|*.bmm",
                FileName = "Untitled"
            };
        }

        public DialogResult ShowDialog()
        {
            var result = _dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var action = new ActionSaveMetadataMap(new MetadataMap
                {
                    ObjectsInMap = _objectsInMap,
                    FileName = _selectedFile
                }, _dialog.FileName);
                action.Executar();
            }

            return result;
        }
    }
}

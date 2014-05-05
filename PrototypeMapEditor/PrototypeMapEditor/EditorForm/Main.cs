using System;
using System.Windows.Forms;

namespace PrototypeMapEditor.EditorForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnEditorDeMetadados_Click(object sender, EventArgs e)
        {
            new MapEditor().ShowDialog();
        }
    }
}

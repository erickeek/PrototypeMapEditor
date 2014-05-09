using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrototypeMapEditor.EditorForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Location = new Point(10, 10);
        }

        private void ButtonMetadataEditor_Click(object sender, EventArgs e)
        {
            new MetadataEditor().ShowDialog();
        }

        private void ButtonMapEditor_Click(object sender, EventArgs e)
        {
            new MapEditor().ShowDialog();
        }

        private void ButtonCharacterEditor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!");
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using PrototypeMapEditor.Core;

namespace PrototypeMapEditor.EditorForm
{
    public partial class LayerForm : Form
    {
        public LayerForm(Layer layer = null)
        {
            InitializeComponent();
            Layer = layer ?? new Layer();

            FillForm(layer);
        }

        private void FillForm(Layer layer)
        {
            if (layer == null)
            {
                ButtonnAdd.Text = "Add";
                ButtonDelete.Enabled = false;
                return;
            }

            TextName.Text = layer.Name;
            TextIndex.Text = layer.Index.ToString(CultureInfo.InvariantCulture);
            TextColor.BackColor = System.Drawing.Color.FromArgb(layer.Color.A, layer.Color.R, layer.Color.G, layer.Color.B);
            TextScale.Text = layer.Scale.ToString(CultureInfo.InvariantCulture);

            ButtonnAdd.Text = "Update";
            ButtonDelete.Enabled = true;
        }

        public Layer Layer { get; private set; }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Layer = null;
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonnAdd_Click(object sender, EventArgs e)
        {
            Layer.Name = TextName.Text;
            Layer.Index = Convert.ToInt32(TextIndex.Text);
            Layer.Scale = Convert.ToSingle(TextScale.Text);

            var color = TextColor.BackColor;
            Layer.Color = new Color(color.R, color.G, color.B, color.A);

            DialogResult = DialogResult.OK;
        }

        private void TxtCor_Enter(object sender, EventArgs e)
        {
            PickColor();
        }

        private void TxtCor_Click(object sender, EventArgs e)
        {
            PickColor();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void PickColor()
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextColor.BackColor = dialog.Color;
            }
        }
    }
}
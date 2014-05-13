using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Prototype.Core;
using Prototype.Core.Helper;

namespace PrototypeMapEditor.EditorForm
{
    public partial class LayerForm : Form
    {
        private readonly CultureInfo _cultureInfo = new CultureInfo("en-US");

        public Layer Layer { get; private set; }

        public LayerForm(Layer layer = null)
        {
            InitializeComponent();
            CenterToScreen();

            Layer = layer ?? new Layer();
            TextColor.BackColor = System.Drawing.Color.White;

            FillForm(layer);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Layer = null;
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonnAdd_Click(object sender, EventArgs e)
        {
            Layer.Name = TextName.Text;
            Layer.Index = TextIndex.Text.ToInt32();
            Layer.Scale = TextScale.Text.ToSingle();

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

        private void FillForm(Layer layer)
        {
            if (layer == null)
            {
                ButtonnAdd.Text = "Add";
                ButtonDelete.Enabled = false;
                return;
            }

            TextName.Text = layer.Name;
            TextIndex.Text = layer.Index.ToString(_cultureInfo);
            TextColor.BackColor = System.Drawing.Color.FromArgb(layer.Color.A, layer.Color.R, layer.Color.G, layer.Color.B);
            TextScale.Text = layer.Scale.ToString(_cultureInfo);

            ButtonnAdd.Text = "Update";
            ButtonDelete.Enabled = true;
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
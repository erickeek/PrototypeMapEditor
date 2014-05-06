namespace PrototypeMapEditor.EditorForm
{
    partial class MapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnImportarMetadado = new System.Windows.Forms.Button();
            this.objectDisplay = new PrototypeMapEditor.CustomControls.ObjectDisplay();
            this.mapDisplay = new PrototypeMapEditor.CustomControls.MapDisplay();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(13, 505);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(679, 18);
            this.hScrollBar1.TabIndex = 2;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(699, 13);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 485);
            this.vScrollBar1.TabIndex = 3;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(909, 13);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 485);
            this.vScrollBar2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 560);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "100%";
            // 
            // BtnImportarMetadado
            // 
            this.BtnImportarMetadado.Location = new System.Drawing.Point(719, 505);
            this.BtnImportarMetadado.Name = "BtnImportarMetadado";
            this.BtnImportarMetadado.Size = new System.Drawing.Size(204, 23);
            this.BtnImportarMetadado.TabIndex = 6;
            this.BtnImportarMetadado.Text = "Importar metadado";
            this.BtnImportarMetadado.UseVisualStyleBackColor = true;
            this.BtnImportarMetadado.Click += new System.EventHandler(this.BtnImportarMetadado_Click);
            // 
            // objectDisplay
            // 
            this.objectDisplay.Location = new System.Drawing.Point(719, 13);
            this.objectDisplay.MetadadoMapa = null;
            this.objectDisplay.Name = "objectDisplay";
            this.objectDisplay.Size = new System.Drawing.Size(187, 485);
            this.objectDisplay.TabIndex = 1;
            this.objectDisplay.Text = "objectDisplay1";
            this.objectDisplay.Texture = null;
            // 
            // mapDisplay
            // 
            this.mapDisplay.Location = new System.Drawing.Point(13, 13);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Size = new System.Drawing.Size(679, 485);
            this.mapDisplay.TabIndex = 0;
            this.mapDisplay.Text = "mapDisplay1";
            this.mapDisplay.Texture = null;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 592);
            this.Controls.Add(this.BtnImportarMetadado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.objectDisplay);
            this.Controls.Add(this.mapDisplay);
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.MapDisplay mapDisplay;
        private CustomControls.ObjectDisplay objectDisplay;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnImportarMetadado;
    }
}
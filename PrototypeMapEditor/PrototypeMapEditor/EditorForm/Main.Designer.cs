namespace PrototypeMapEditor.EditorForm
{
    partial class Main
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
            this.BtnEditorDeMetadados = new System.Windows.Forms.Button();
            this.BtnEditorDeMapas = new System.Windows.Forms.Button();
            this.BtnEditorDePersonagem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEditorDeMetadados
            // 
            this.BtnEditorDeMetadados.Location = new System.Drawing.Point(12, 12);
            this.BtnEditorDeMetadados.Name = "BtnEditorDeMetadados";
            this.BtnEditorDeMetadados.Size = new System.Drawing.Size(152, 23);
            this.BtnEditorDeMetadados.TabIndex = 0;
            this.BtnEditorDeMetadados.Text = "Editor de metadados";
            this.BtnEditorDeMetadados.UseVisualStyleBackColor = true;
            this.BtnEditorDeMetadados.Click += new System.EventHandler(this.BtnEditorDeMetadados_Click);
            // 
            // BtnEditorDeMapas
            // 
            this.BtnEditorDeMapas.Location = new System.Drawing.Point(12, 42);
            this.BtnEditorDeMapas.Name = "BtnEditorDeMapas";
            this.BtnEditorDeMapas.Size = new System.Drawing.Size(152, 23);
            this.BtnEditorDeMapas.TabIndex = 1;
            this.BtnEditorDeMapas.Text = "Editor de Mapas";
            this.BtnEditorDeMapas.UseVisualStyleBackColor = true;
            // 
            // BtnEditorDePersonagem
            // 
            this.BtnEditorDePersonagem.Location = new System.Drawing.Point(13, 72);
            this.BtnEditorDePersonagem.Name = "BtnEditorDePersonagem";
            this.BtnEditorDePersonagem.Size = new System.Drawing.Size(151, 23);
            this.BtnEditorDePersonagem.TabIndex = 2;
            this.BtnEditorDePersonagem.Text = "Editor de personsagem";
            this.BtnEditorDePersonagem.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 109);
            this.Controls.Add(this.BtnEditorDePersonagem);
            this.Controls.Add(this.BtnEditorDeMapas);
            this.Controls.Add(this.BtnEditorDeMetadados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Protótipo de Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEditorDeMetadados;
        private System.Windows.Forms.Button BtnEditorDeMapas;
        private System.Windows.Forms.Button BtnEditorDePersonagem;
    }
}
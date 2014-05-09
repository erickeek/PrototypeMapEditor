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
            this.ButtonMetadataEditor = new System.Windows.Forms.Button();
            this.ButtonMapEditor = new System.Windows.Forms.Button();
            this.ButtonCharacterEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonMetadataEditor
            // 
            this.ButtonMetadataEditor.Location = new System.Drawing.Point(12, 12);
            this.ButtonMetadataEditor.Name = "ButtonMetadataEditor";
            this.ButtonMetadataEditor.Size = new System.Drawing.Size(152, 23);
            this.ButtonMetadataEditor.TabIndex = 0;
            this.ButtonMetadataEditor.Text = "Metadata Editor";
            this.ButtonMetadataEditor.UseVisualStyleBackColor = true;
            this.ButtonMetadataEditor.Click += new System.EventHandler(this.ButtonMetadataEditor_Click);
            // 
            // ButtonMapEditor
            // 
            this.ButtonMapEditor.Location = new System.Drawing.Point(12, 42);
            this.ButtonMapEditor.Name = "ButtonMapEditor";
            this.ButtonMapEditor.Size = new System.Drawing.Size(152, 23);
            this.ButtonMapEditor.TabIndex = 1;
            this.ButtonMapEditor.Text = "Map Editor";
            this.ButtonMapEditor.UseVisualStyleBackColor = true;
            this.ButtonMapEditor.Click += new System.EventHandler(this.ButtonMapEditor_Click);
            // 
            // ButtonCharacterEditor
            // 
            this.ButtonCharacterEditor.Location = new System.Drawing.Point(13, 72);
            this.ButtonCharacterEditor.Name = "ButtonCharacterEditor";
            this.ButtonCharacterEditor.Size = new System.Drawing.Size(151, 23);
            this.ButtonCharacterEditor.TabIndex = 2;
            this.ButtonCharacterEditor.Text = "Character Editor";
            this.ButtonCharacterEditor.UseVisualStyleBackColor = true;
            this.ButtonCharacterEditor.Click += new System.EventHandler(this.ButtonCharacterEditor_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 109);
            this.Controls.Add(this.ButtonCharacterEditor);
            this.Controls.Add(this.ButtonMapEditor);
            this.Controls.Add(this.ButtonMetadataEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(192, 148);
            this.MinimumSize = new System.Drawing.Size(192, 148);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Prototype Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonMetadataEditor;
        private System.Windows.Forms.Button ButtonMapEditor;
        private System.Windows.Forms.Button ButtonCharacterEditor;
    }
}
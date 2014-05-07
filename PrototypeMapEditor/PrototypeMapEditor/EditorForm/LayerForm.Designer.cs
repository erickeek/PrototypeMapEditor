namespace PrototypeMapEditor.EditorForm
{
    partial class LayerForm
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
            this.LabelName = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.LabelIndex = new System.Windows.Forms.Label();
            this.TextIndex = new System.Windows.Forms.TextBox();
            this.LabelColor = new System.Windows.Forms.Label();
            this.TextColor = new System.Windows.Forms.TextBox();
            this.LabelScale = new System.Windows.Forms.Label();
            this.TextScale = new System.Windows.Forms.TextBox();
            this.ButtonnAdd = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(14, 19);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Name";
            // 
            // TextName
            // 
            this.TextName.Location = new System.Drawing.Point(115, 16);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(100, 20);
            this.TextName.TabIndex = 1;
            // 
            // LabelIndex
            // 
            this.LabelIndex.AutoSize = true;
            this.LabelIndex.Location = new System.Drawing.Point(14, 45);
            this.LabelIndex.Name = "LabelIndex";
            this.LabelIndex.Size = new System.Drawing.Size(33, 13);
            this.LabelIndex.TabIndex = 3;
            this.LabelIndex.Text = "Index";
            // 
            // TextIndex
            // 
            this.TextIndex.Location = new System.Drawing.Point(115, 42);
            this.TextIndex.Name = "TextIndex";
            this.TextIndex.Size = new System.Drawing.Size(100, 20);
            this.TextIndex.TabIndex = 2;
            // 
            // LabelColor
            // 
            this.LabelColor.AutoSize = true;
            this.LabelColor.Location = new System.Drawing.Point(14, 71);
            this.LabelColor.Name = "LabelColor";
            this.LabelColor.Size = new System.Drawing.Size(31, 13);
            this.LabelColor.TabIndex = 4;
            this.LabelColor.Text = "Color";
            // 
            // TextColor
            // 
            this.TextColor.Location = new System.Drawing.Point(115, 68);
            this.TextColor.Name = "TextColor";
            this.TextColor.ReadOnly = true;
            this.TextColor.Size = new System.Drawing.Size(100, 20);
            this.TextColor.TabIndex = 5;
            this.TextColor.Click += new System.EventHandler(this.TxtCor_Click);
            this.TextColor.Enter += new System.EventHandler(this.TxtCor_Enter);
            // 
            // LabelScale
            // 
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(14, 97);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(34, 13);
            this.LabelScale.TabIndex = 6;
            this.LabelScale.Text = "Scale";
            // 
            // TextScale
            // 
            this.TextScale.Location = new System.Drawing.Point(115, 94);
            this.TextScale.Name = "TextScale";
            this.TextScale.Size = new System.Drawing.Size(100, 20);
            this.TextScale.TabIndex = 7;
            // 
            // ButtonnAdd
            // 
            this.ButtonnAdd.Location = new System.Drawing.Point(153, 122);
            this.ButtonnAdd.Name = "ButtonnAdd";
            this.ButtonnAdd.Size = new System.Drawing.Size(62, 23);
            this.ButtonnAdd.TabIndex = 8;
            this.ButtonnAdd.Text = "Add";
            this.ButtonnAdd.UseVisualStyleBackColor = true;
            this.ButtonnAdd.Click += new System.EventHandler(this.ButtonnAdd_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(85, 122);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(62, 23);
            this.ButtonCancel.TabIndex = 9;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(17, 122);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(62, 23);
            this.ButtonDelete.TabIndex = 10;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // LayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 158);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonnAdd);
            this.Controls.Add(this.TextScale);
            this.Controls.Add(this.LabelScale);
            this.Controls.Add(this.TextColor);
            this.Controls.Add(this.LabelColor);
            this.Controls.Add(this.LabelIndex);
            this.Controls.Add(this.TextIndex);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.LabelName);
            this.Name = "LayerForm";
            this.Text = "Layer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.Label LabelIndex;
        private System.Windows.Forms.TextBox TextIndex;
        private System.Windows.Forms.Label LabelColor;
        private System.Windows.Forms.TextBox TextColor;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.TextBox TextScale;
        private System.Windows.Forms.Button ButtonnAdd;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonDelete;
    }
}
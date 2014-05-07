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
            this.HScrollBarMapDisplay = new System.Windows.Forms.HScrollBar();
            this.VScrollBarMapDisplay = new System.Windows.Forms.VScrollBar();
            this.VScrollBarObjectDisplay = new System.Windows.Forms.VScrollBar();
            this.TextScale = new System.Windows.Forms.TextBox();
            this.ButtonImportMetadata = new System.Windows.Forms.Button();
            this.GroupBoxLayer = new System.Windows.Forms.GroupBox();
            this.ButtonAddLayer = new System.Windows.Forms.Button();
            this.ListBoxLayer = new System.Windows.Forms.ListBox();
            this.GroupBoxObject = new System.Windows.Forms.GroupBox();
            this.ListBoxObject = new System.Windows.Forms.ListBox();
            this.ObjectDisplay = new PrototypeMapEditor.CustomControls.ObjectDisplay();
            this.MapDisplay = new PrototypeMapEditor.CustomControls.MapDisplay();
            this.GroupBoxLayer.SuspendLayout();
            this.GroupBoxObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // HScrollBarMapDisplay
            // 
            this.HScrollBarMapDisplay.Location = new System.Drawing.Point(13, 505);
            this.HScrollBarMapDisplay.Name = "HScrollBarMapDisplay";
            this.HScrollBarMapDisplay.Size = new System.Drawing.Size(679, 18);
            this.HScrollBarMapDisplay.TabIndex = 2;
            // 
            // VScrollBarMapDisplay
            // 
            this.VScrollBarMapDisplay.Location = new System.Drawing.Point(699, 13);
            this.VScrollBarMapDisplay.Name = "VScrollBarMapDisplay";
            this.VScrollBarMapDisplay.Size = new System.Drawing.Size(17, 485);
            this.VScrollBarMapDisplay.TabIndex = 3;
            // 
            // VScrollBarObjectDisplay
            // 
            this.VScrollBarObjectDisplay.Location = new System.Drawing.Point(912, 13);
            this.VScrollBarObjectDisplay.Name = "VScrollBarObjectDisplay";
            this.VScrollBarObjectDisplay.Size = new System.Drawing.Size(17, 485);
            this.VScrollBarObjectDisplay.TabIndex = 4;
            this.VScrollBarObjectDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarObjectDisplay_Scroll);
            // 
            // TextScale
            // 
            this.TextScale.Location = new System.Drawing.Point(13, 560);
            this.TextScale.Name = "TextScale";
            this.TextScale.Size = new System.Drawing.Size(35, 20);
            this.TextScale.TabIndex = 5;
            this.TextScale.Text = "100%";
            // 
            // ButtonImportMetadata
            // 
            this.ButtonImportMetadata.Location = new System.Drawing.Point(719, 505);
            this.ButtonImportMetadata.Name = "ButtonImportMetadata";
            this.ButtonImportMetadata.Size = new System.Drawing.Size(204, 23);
            this.ButtonImportMetadata.TabIndex = 6;
            this.ButtonImportMetadata.Text = "Import metadata";
            this.ButtonImportMetadata.UseVisualStyleBackColor = true;
            this.ButtonImportMetadata.Click += new System.EventHandler(this.ButtonImportMetadata_Click);
            // 
            // GroupBoxLayer
            // 
            this.GroupBoxLayer.Controls.Add(this.ButtonAddLayer);
            this.GroupBoxLayer.Controls.Add(this.ListBoxLayer);
            this.GroupBoxLayer.Location = new System.Drawing.Point(932, 13);
            this.GroupBoxLayer.Name = "GroupBoxLayer";
            this.GroupBoxLayer.Size = new System.Drawing.Size(184, 154);
            this.GroupBoxLayer.TabIndex = 7;
            this.GroupBoxLayer.TabStop = false;
            this.GroupBoxLayer.Text = "Layers";
            // 
            // ButtonAddLayer
            // 
            this.ButtonAddLayer.Location = new System.Drawing.Point(7, 122);
            this.ButtonAddLayer.Name = "ButtonAddLayer";
            this.ButtonAddLayer.Size = new System.Drawing.Size(171, 23);
            this.ButtonAddLayer.TabIndex = 1;
            this.ButtonAddLayer.Text = "Add";
            this.ButtonAddLayer.UseVisualStyleBackColor = true;
            this.ButtonAddLayer.Click += new System.EventHandler(this.ButtonAddLayer_Click);
            // 
            // ListBoxLayer
            // 
            this.ListBoxLayer.DisplayMember = "Name";
            this.ListBoxLayer.FormattingEnabled = true;
            this.ListBoxLayer.Location = new System.Drawing.Point(7, 20);
            this.ListBoxLayer.Name = "ListBoxLayer";
            this.ListBoxLayer.Size = new System.Drawing.Size(171, 95);
            this.ListBoxLayer.TabIndex = 0;
            this.ListBoxLayer.ValueMember = "Name";
            this.ListBoxLayer.SelectedValueChanged += new System.EventHandler(this.ListBoxLayer_SelectedValueChanged);
            this.ListBoxLayer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListBoxLayer_KeyUp);
            this.ListBoxLayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxLayer_MouseDoubleClick);
            // 
            // GroupBoxObject
            // 
            this.GroupBoxObject.Controls.Add(this.ListBoxObject);
            this.GroupBoxObject.Location = new System.Drawing.Point(932, 174);
            this.GroupBoxObject.Name = "GroupBoxObject";
            this.GroupBoxObject.Size = new System.Drawing.Size(184, 216);
            this.GroupBoxObject.TabIndex = 8;
            this.GroupBoxObject.TabStop = false;
            this.GroupBoxObject.Text = "Objects";
            // 
            // ListBoxObject
            // 
            this.ListBoxObject.DisplayMember = "Name";
            this.ListBoxObject.FormattingEnabled = true;
            this.ListBoxObject.Location = new System.Drawing.Point(7, 20);
            this.ListBoxObject.Name = "ListBoxObject";
            this.ListBoxObject.Size = new System.Drawing.Size(171, 186);
            this.ListBoxObject.TabIndex = 0;
            this.ListBoxObject.ValueMember = "Name";
            this.ListBoxObject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListBoxObject_KeyUp);
            // 
            // ObjectDisplay
            // 
            this.ObjectDisplay.Location = new System.Drawing.Point(719, 13);
            this.ObjectDisplay.MetadataMap = null;
            this.ObjectDisplay.Name = "ObjectDisplay";
            this.ObjectDisplay.Size = new System.Drawing.Size(187, 485);
            this.ObjectDisplay.TabIndex = 1;
            this.ObjectDisplay.Text = "ObjectDisplay";
            this.ObjectDisplay.Texture = null;
            this.ObjectDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ObjectDisplay_MouseDown);
            // 
            // MapDisplay
            // 
            this.MapDisplay.ActualObjectMap = null;
            this.MapDisplay.Location = new System.Drawing.Point(13, 13);
            this.MapDisplay.Map = null;
            this.MapDisplay.MetadataMap = null;
            this.MapDisplay.Name = "MapDisplay";
            this.MapDisplay.Size = new System.Drawing.Size(679, 485);
            this.MapDisplay.TabIndex = 0;
            this.MapDisplay.Text = "mapDisplay1";
            this.MapDisplay.Texture = null;
            this.MapDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseDown);
            this.MapDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseMove);
            this.MapDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseUp);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 592);
            this.Controls.Add(this.GroupBoxObject);
            this.Controls.Add(this.GroupBoxLayer);
            this.Controls.Add(this.ButtonImportMetadata);
            this.Controls.Add(this.TextScale);
            this.Controls.Add(this.VScrollBarObjectDisplay);
            this.Controls.Add(this.VScrollBarMapDisplay);
            this.Controls.Add(this.HScrollBarMapDisplay);
            this.Controls.Add(this.ObjectDisplay);
            this.Controls.Add(this.MapDisplay);
            this.Name = "MapEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.GroupBoxLayer.ResumeLayout(false);
            this.GroupBoxObject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.MapDisplay MapDisplay;
        private CustomControls.ObjectDisplay ObjectDisplay;
        private System.Windows.Forms.HScrollBar HScrollBarMapDisplay;
        private System.Windows.Forms.VScrollBar VScrollBarMapDisplay;
        private System.Windows.Forms.VScrollBar VScrollBarObjectDisplay;
        private System.Windows.Forms.TextBox TextScale;
        private System.Windows.Forms.Button ButtonImportMetadata;
        private System.Windows.Forms.GroupBox GroupBoxLayer;
        private System.Windows.Forms.Button ButtonAddLayer;
        private System.Windows.Forms.ListBox ListBoxLayer;
        private System.Windows.Forms.GroupBox GroupBoxObject;
        private System.Windows.Forms.ListBox ListBoxObject;
    }
}
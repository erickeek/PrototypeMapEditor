namespace PrototypeMapEditor.EditorForm
{
    sealed partial class MetadataEditor
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
            this.HScrollBarMetadataDisplay = new System.Windows.Forms.HScrollBar();
            this.VScrollBarMetadataDisplay = new System.Windows.Forms.VScrollBar();
            this.PanelMetadataDisplay = new System.Windows.Forms.Panel();
            this.MetadataDisplay = new PrototypeMapEditor.CustomControls.MetadataDisplay();
            this.ListBoxMaps = new System.Windows.Forms.ListBox();
            this.ButtonLoadMap = new System.Windows.Forms.Button();
            this.PanelProperties = new System.Windows.Forms.Panel();
            this.LabelHeight = new System.Windows.Forms.Label();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.LabelY = new System.Windows.Forms.Label();
            this.LabelX = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.TextHeight = new System.Windows.Forms.TextBox();
            this.TextWidth = new System.Windows.Forms.TextBox();
            this.TextY = new System.Windows.Forms.TextBox();
            this.TextX = new System.Windows.Forms.TextBox();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.ButtonImport = new System.Windows.Forms.Button();
            this.PanelMetadataDisplay.SuspendLayout();
            this.PanelProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // HScrollBarMetadataDisplay
            // 
            this.HScrollBarMetadataDisplay.Location = new System.Drawing.Point(13, 528);
            this.HScrollBarMetadataDisplay.Name = "HScrollBarMetadataDisplay";
            this.HScrollBarMetadataDisplay.Size = new System.Drawing.Size(679, 17);
            this.HScrollBarMetadataDisplay.TabIndex = 1;
            this.HScrollBarMetadataDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarMetadataEditor_Scroll);
            // 
            // VScrollBarMetadataDisplay
            // 
            this.VScrollBarMetadataDisplay.Location = new System.Drawing.Point(695, 13);
            this.VScrollBarMetadataDisplay.Name = "VScrollBarMetadataDisplay";
            this.VScrollBarMetadataDisplay.Size = new System.Drawing.Size(17, 512);
            this.VScrollBarMetadataDisplay.TabIndex = 2;
            this.VScrollBarMetadataDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarMetatadaEditor_Scroll);
            // 
            // PanelMetadataDisplay
            // 
            this.PanelMetadataDisplay.AutoScroll = true;
            this.PanelMetadataDisplay.Controls.Add(this.MetadataDisplay);
            this.PanelMetadataDisplay.Location = new System.Drawing.Point(13, 13);
            this.PanelMetadataDisplay.Name = "PanelMetadataDisplay";
            this.PanelMetadataDisplay.Size = new System.Drawing.Size(679, 512);
            this.PanelMetadataDisplay.TabIndex = 3;
            // 
            // MetadataDisplay
            // 
            this.MetadataDisplay.ActualObjectMap = null;
            this.MetadataDisplay.Location = new System.Drawing.Point(0, 0);
            this.MetadataDisplay.Name = "MetadataDisplay";
            this.MetadataDisplay.ObjectsInMap = null;
            this.MetadataDisplay.Size = new System.Drawing.Size(679, 512);
            this.MetadataDisplay.TabIndex = 0;
            this.MetadataDisplay.Text = "mapDisplay";
            this.MetadataDisplay.Texture = null;
            this.MetadataDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseDown);
            this.MetadataDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseMove);
            this.MetadataDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseUp);
            // 
            // ListBoxMaps
            // 
            this.ListBoxMaps.FormattingEnabled = true;
            this.ListBoxMaps.Location = new System.Drawing.Point(715, 12);
            this.ListBoxMaps.Name = "ListBoxMaps";
            this.ListBoxMaps.Size = new System.Drawing.Size(185, 199);
            this.ListBoxMaps.TabIndex = 4;
            this.ListBoxMaps.DoubleClick += new System.EventHandler(this.ListBoxMaps_DoubleClick);
            // 
            // ButtonLoadMap
            // 
            this.ButtonLoadMap.Location = new System.Drawing.Point(715, 217);
            this.ButtonLoadMap.Name = "ButtonLoadMap";
            this.ButtonLoadMap.Size = new System.Drawing.Size(185, 23);
            this.ButtonLoadMap.TabIndex = 5;
            this.ButtonLoadMap.Text = "Load";
            this.ButtonLoadMap.UseVisualStyleBackColor = true;
            this.ButtonLoadMap.Click += new System.EventHandler(this.ButtonLoadMap_Click);
            // 
            // PanelProperties
            // 
            this.PanelProperties.Controls.Add(this.LabelHeight);
            this.PanelProperties.Controls.Add(this.LabelWidth);
            this.PanelProperties.Controls.Add(this.LabelY);
            this.PanelProperties.Controls.Add(this.LabelX);
            this.PanelProperties.Controls.Add(this.LabelName);
            this.PanelProperties.Controls.Add(this.TextName);
            this.PanelProperties.Controls.Add(this.ButtonRemove);
            this.PanelProperties.Controls.Add(this.TextHeight);
            this.PanelProperties.Controls.Add(this.TextWidth);
            this.PanelProperties.Controls.Add(this.TextY);
            this.PanelProperties.Controls.Add(this.TextX);
            this.PanelProperties.Location = new System.Drawing.Point(716, 327);
            this.PanelProperties.Name = "PanelProperties";
            this.PanelProperties.Size = new System.Drawing.Size(184, 198);
            this.PanelProperties.TabIndex = 6;
            // 
            // LabelHeight
            // 
            this.LabelHeight.AutoSize = true;
            this.LabelHeight.Location = new System.Drawing.Point(7, 111);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(38, 13);
            this.LabelHeight.TabIndex = 10;
            this.LabelHeight.Text = "Height";
            // 
            // LabelWidth
            // 
            this.LabelWidth.AutoSize = true;
            this.LabelWidth.Location = new System.Drawing.Point(7, 85);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(35, 13);
            this.LabelWidth.TabIndex = 9;
            this.LabelWidth.Text = "Width";
            // 
            // LabelY
            // 
            this.LabelY.AutoSize = true;
            this.LabelY.Location = new System.Drawing.Point(7, 59);
            this.LabelY.Name = "LabelY";
            this.LabelY.Size = new System.Drawing.Size(14, 13);
            this.LabelY.TabIndex = 8;
            this.LabelY.Text = "Y";
            // 
            // LabelX
            // 
            this.LabelX.AutoSize = true;
            this.LabelX.Location = new System.Drawing.Point(7, 33);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(14, 13);
            this.LabelX.TabIndex = 7;
            this.LabelX.Text = "X";
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(7, 7);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 6;
            this.LabelName.Text = "Name";
            // 
            // TextName
            // 
            this.TextName.Location = new System.Drawing.Point(81, 4);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(100, 20);
            this.TextName.TabIndex = 5;
            this.TextName.TextChanged += new System.EventHandler(this.TextName_TextChanged);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Location = new System.Drawing.Point(4, 132);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(177, 23);
            this.ButtonRemove.TabIndex = 4;
            this.ButtonRemove.Text = "Remove";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // TextHeight
            // 
            this.TextHeight.Location = new System.Drawing.Point(81, 108);
            this.TextHeight.Name = "TextHeight";
            this.TextHeight.Size = new System.Drawing.Size(100, 20);
            this.TextHeight.TabIndex = 3;
            this.TextHeight.TextChanged += new System.EventHandler(this.TextHeight_TextChanged);
            this.TextHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_KeyDown);
            // 
            // TextWidth
            // 
            this.TextWidth.Location = new System.Drawing.Point(81, 82);
            this.TextWidth.Name = "TextWidth";
            this.TextWidth.Size = new System.Drawing.Size(100, 20);
            this.TextWidth.TabIndex = 2;
            this.TextWidth.TextChanged += new System.EventHandler(this.TextWidth_TextChanged);
            this.TextWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_KeyDown);
            // 
            // TextY
            // 
            this.TextY.Location = new System.Drawing.Point(81, 56);
            this.TextY.Name = "TextY";
            this.TextY.Size = new System.Drawing.Size(100, 20);
            this.TextY.TabIndex = 1;
            this.TextY.TextChanged += new System.EventHandler(this.TextY_TextChanged);
            this.TextY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_KeyDown);
            // 
            // TextX
            // 
            this.TextX.Location = new System.Drawing.Point(81, 30);
            this.TextX.Name = "TextX";
            this.TextX.Size = new System.Drawing.Size(100, 20);
            this.TextX.TabIndex = 0;
            this.TextX.TextChanged += new System.EventHandler(this.TextX_TextChanged);
            this.TextX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Text_KeyDown);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Location = new System.Drawing.Point(715, 246);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(185, 23);
            this.ButtonExport.TabIndex = 7;
            this.ButtonExport.Text = "Export";
            this.ButtonExport.UseVisualStyleBackColor = true;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // ButtonImport
            // 
            this.ButtonImport.Location = new System.Drawing.Point(716, 273);
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.Size = new System.Drawing.Size(184, 23);
            this.ButtonImport.TabIndex = 8;
            this.ButtonImport.Text = "Import";
            this.ButtonImport.UseVisualStyleBackColor = true;
            this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // MetadataEditor
            // 
            this.ClientSize = new System.Drawing.Size(912, 563);
            this.Controls.Add(this.ButtonImport);
            this.Controls.Add(this.ButtonExport);
            this.Controls.Add(this.PanelProperties);
            this.Controls.Add(this.ButtonLoadMap);
            this.Controls.Add(this.ListBoxMaps);
            this.Controls.Add(this.PanelMetadataDisplay);
            this.Controls.Add(this.VScrollBarMetadataDisplay);
            this.Controls.Add(this.HScrollBarMetadataDisplay);
            this.MaximumSize = new System.Drawing.Size(928, 602);
            this.MinimumSize = new System.Drawing.Size(928, 602);
            this.Name = "MetadataEditor";
            this.Text = "Metadata Editor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.PanelMetadataDisplay.ResumeLayout(false);
            this.PanelProperties.ResumeLayout(false);
            this.PanelProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomControls.MetadataDisplay MetadataDisplay;
        private System.Windows.Forms.HScrollBar HScrollBarMetadataDisplay;
        private System.Windows.Forms.VScrollBar VScrollBarMetadataDisplay;
        private System.Windows.Forms.Panel PanelMetadataDisplay;
        private System.Windows.Forms.ListBox ListBoxMaps;
        private System.Windows.Forms.Button ButtonLoadMap;
        private System.Windows.Forms.Panel PanelProperties;
        private System.Windows.Forms.TextBox TextHeight;
        private System.Windows.Forms.TextBox TextWidth;
        private System.Windows.Forms.TextBox TextY;
        private System.Windows.Forms.TextBox TextX;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Button ButtonExport;
        private System.Windows.Forms.Button ButtonImport;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.Label LabelX;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.Label LabelY;
        private System.Windows.Forms.Label LabelHeight;
    }
}
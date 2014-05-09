using PrototypeMapEditor.CustomControls.ListBox;

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
            this.TextZoom = new System.Windows.Forms.TextBox();
            this.ButtonImportMetadata = new System.Windows.Forms.Button();
            this.GroupBoxLayer = new System.Windows.Forms.GroupBox();
            this.ButtonAddLayer = new System.Windows.Forms.Button();
            this.ListBoxLayer = new PrototypeMapEditor.CustomControls.ListBox.DragDropListBox();
            this.GroupBoxObject = new System.Windows.Forms.GroupBox();
            this.ListBoxObject = new PrototypeMapEditor.CustomControls.ListBox.DragDropListBox();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.ButtonImport = new System.Windows.Forms.Button();
            this.GroupBoxDrawingMode = new System.Windows.Forms.GroupBox();
            this.RadioListBoxDrawingMode = new PrototypeMapEditor.CustomControls.Radio.RadioListBox();
            this.GroupBoxMap = new System.Windows.Forms.GroupBox();
            this.LabelPercentZoom = new System.Windows.Forms.Label();
            this.LabelZoom = new System.Windows.Forms.Label();
            this.TextBoxMapHeight = new System.Windows.Forms.TextBox();
            this.TextBoxMapWidth = new System.Windows.Forms.TextBox();
            this.LabelMapHeight = new System.Windows.Forms.Label();
            this.LabelMapWidth = new System.Windows.Forms.Label();
            this.ObjectDisplay = new PrototypeMapEditor.CustomControls.ObjectDisplay();
            this.MapDisplay = new PrototypeMapEditor.CustomControls.MapDisplay();
            this.GroupBoxLayer.SuspendLayout();
            this.GroupBoxObject.SuspendLayout();
            this.GroupBoxDrawingMode.SuspendLayout();
            this.GroupBoxMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // HScrollBarMapDisplay
            // 
            this.HScrollBarMapDisplay.Location = new System.Drawing.Point(13, 505);
            this.HScrollBarMapDisplay.Name = "HScrollBarMapDisplay";
            this.HScrollBarMapDisplay.Size = new System.Drawing.Size(679, 18);
            this.HScrollBarMapDisplay.TabIndex = 2;
            this.HScrollBarMapDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBarMapDisplay_Scroll);
            // 
            // VScrollBarMapDisplay
            // 
            this.VScrollBarMapDisplay.Location = new System.Drawing.Point(699, 13);
            this.VScrollBarMapDisplay.Name = "VScrollBarMapDisplay";
            this.VScrollBarMapDisplay.Size = new System.Drawing.Size(17, 485);
            this.VScrollBarMapDisplay.TabIndex = 3;
            this.VScrollBarMapDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarMapDisplay_Scroll);
            // 
            // VScrollBarObjectDisplay
            // 
            this.VScrollBarObjectDisplay.Location = new System.Drawing.Point(912, 13);
            this.VScrollBarObjectDisplay.Name = "VScrollBarObjectDisplay";
            this.VScrollBarObjectDisplay.Size = new System.Drawing.Size(17, 485);
            this.VScrollBarObjectDisplay.TabIndex = 4;
            this.VScrollBarObjectDisplay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarObjectDisplay_Scroll);
            // 
            // TextZoom
            // 
            this.TextZoom.Location = new System.Drawing.Point(344, 19);
            this.TextZoom.Name = "TextZoom";
            this.TextZoom.Size = new System.Drawing.Size(28, 20);
            this.TextZoom.TabIndex = 5;
            this.TextZoom.Text = "100";
            this.TextZoom.TextChanged += new System.EventHandler(this.TextZoom_TextChanged);
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
            this.ListBoxLayer.AllowDrop = true;
            this.ListBoxLayer.DisplayMember = "Name";
            this.ListBoxLayer.FormattingEnabled = true;
            this.ListBoxLayer.Location = new System.Drawing.Point(7, 20);
            this.ListBoxLayer.Name = "ListBoxLayer";
            this.ListBoxLayer.Size = new System.Drawing.Size(171, 95);
            this.ListBoxLayer.TabIndex = 0;
            this.ListBoxLayer.ValueMember = "Name";
            this.ListBoxLayer.SelectedIndexChanged += new System.EventHandler(this.ListBoxLayer_SelectedIndexChanged);
            this.ListBoxLayer.SelectedValueChanged += new System.EventHandler(this.ListBoxLayer_SelectedValueChanged);
            this.ListBoxLayer.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxLayer_DragDrop);
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
            this.ListBoxObject.AllowDrop = true;
            this.ListBoxObject.DisplayMember = "Name";
            this.ListBoxObject.FormattingEnabled = true;
            this.ListBoxObject.Location = new System.Drawing.Point(7, 20);
            this.ListBoxObject.Name = "ListBoxObject";
            this.ListBoxObject.Size = new System.Drawing.Size(171, 186);
            this.ListBoxObject.TabIndex = 0;
            this.ListBoxObject.ValueMember = "Name";
            this.ListBoxObject.SelectedIndexChanged += new System.EventHandler(this.ListBoxObject_SelectedIndexChanged);
            this.ListBoxObject.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxObject_DragDrop);
            this.ListBoxObject.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListBoxObject_KeyUp);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Location = new System.Drawing.Point(719, 535);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(204, 23);
            this.ButtonExport.TabIndex = 9;
            this.ButtonExport.Text = "Export";
            this.ButtonExport.UseVisualStyleBackColor = true;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // ButtonImport
            // 
            this.ButtonImport.Location = new System.Drawing.Point(719, 564);
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.Size = new System.Drawing.Size(204, 23);
            this.ButtonImport.TabIndex = 10;
            this.ButtonImport.Text = "Import";
            this.ButtonImport.UseVisualStyleBackColor = true;
            this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // GroupBoxDrawingMode
            // 
            this.GroupBoxDrawingMode.Controls.Add(this.RadioListBoxDrawingMode);
            this.GroupBoxDrawingMode.Location = new System.Drawing.Point(933, 397);
            this.GroupBoxDrawingMode.Name = "GroupBoxDrawingMode";
            this.GroupBoxDrawingMode.Size = new System.Drawing.Size(183, 101);
            this.GroupBoxDrawingMode.TabIndex = 12;
            this.GroupBoxDrawingMode.TabStop = false;
            this.GroupBoxDrawingMode.Text = "Drawing Mode";
            // 
            // RadioListBoxDrawingMode
            // 
            this.RadioListBoxDrawingMode.BackColor = System.Drawing.SystemColors.Window;
            this.RadioListBoxDrawingMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RadioListBoxDrawingMode.FormattingEnabled = true;
            this.RadioListBoxDrawingMode.Location = new System.Drawing.Point(6, 19);
            this.RadioListBoxDrawingMode.Name = "RadioListBoxDrawingMode";
            this.RadioListBoxDrawingMode.Size = new System.Drawing.Size(171, 69);
            this.RadioListBoxDrawingMode.TabIndex = 11;
            this.RadioListBoxDrawingMode.SelectedIndexChanged += new System.EventHandler(this.RadioListBoxDrawingMode_SelectedIndexChanged);
            // 
            // GroupBoxMap
            // 
            this.GroupBoxMap.Controls.Add(this.TextZoom);
            this.GroupBoxMap.Controls.Add(this.LabelPercentZoom);
            this.GroupBoxMap.Controls.Add(this.LabelZoom);
            this.GroupBoxMap.Controls.Add(this.TextBoxMapHeight);
            this.GroupBoxMap.Controls.Add(this.TextBoxMapWidth);
            this.GroupBoxMap.Controls.Add(this.LabelMapHeight);
            this.GroupBoxMap.Controls.Add(this.LabelMapWidth);
            this.GroupBoxMap.Location = new System.Drawing.Point(13, 535);
            this.GroupBoxMap.Name = "GroupBoxMap";
            this.GroupBoxMap.Size = new System.Drawing.Size(394, 45);
            this.GroupBoxMap.TabIndex = 13;
            this.GroupBoxMap.TabStop = false;
            this.GroupBoxMap.Text = "Map";
            // 
            // LabelPercentZoom
            // 
            this.LabelPercentZoom.AutoSize = true;
            this.LabelPercentZoom.Location = new System.Drawing.Point(372, 22);
            this.LabelPercentZoom.Name = "LabelPercentZoom";
            this.LabelPercentZoom.Size = new System.Drawing.Size(15, 13);
            this.LabelPercentZoom.TabIndex = 6;
            this.LabelPercentZoom.Text = "%";
            // 
            // LabelZoom
            // 
            this.LabelZoom.AutoSize = true;
            this.LabelZoom.Location = new System.Drawing.Point(304, 22);
            this.LabelZoom.Name = "LabelZoom";
            this.LabelZoom.Size = new System.Drawing.Size(34, 13);
            this.LabelZoom.TabIndex = 4;
            this.LabelZoom.Text = "Zoom";
            // 
            // TextBoxMapHeight
            // 
            this.TextBoxMapHeight.Location = new System.Drawing.Point(198, 19);
            this.TextBoxMapHeight.Name = "TextBoxMapHeight";
            this.TextBoxMapHeight.Size = new System.Drawing.Size(100, 20);
            this.TextBoxMapHeight.TabIndex = 3;
            // 
            // TextBoxMapWidth
            // 
            this.TextBoxMapWidth.Location = new System.Drawing.Point(48, 19);
            this.TextBoxMapWidth.Name = "TextBoxMapWidth";
            this.TextBoxMapWidth.Size = new System.Drawing.Size(100, 20);
            this.TextBoxMapWidth.TabIndex = 2;
            // 
            // LabelMapHeight
            // 
            this.LabelMapHeight.AutoSize = true;
            this.LabelMapHeight.Location = new System.Drawing.Point(154, 22);
            this.LabelMapHeight.Name = "LabelMapHeight";
            this.LabelMapHeight.Size = new System.Drawing.Size(38, 13);
            this.LabelMapHeight.TabIndex = 1;
            this.LabelMapHeight.Text = "Height";
            // 
            // LabelMapWidth
            // 
            this.LabelMapWidth.AutoSize = true;
            this.LabelMapWidth.Location = new System.Drawing.Point(6, 22);
            this.LabelMapWidth.Name = "LabelMapWidth";
            this.LabelMapWidth.Size = new System.Drawing.Size(35, 13);
            this.LabelMapWidth.TabIndex = 0;
            this.LabelMapWidth.Text = "Width";
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
            this.MapDisplay.ActualLayer = null;
            this.MapDisplay.ActualObjectMap = null;
            this.MapDisplay.DrawingMode = PrototypeMapEditor.Core.Enum.DrawingMode.SegmentSelection;
            this.MapDisplay.Location = new System.Drawing.Point(13, 13);
            this.MapDisplay.Map = null;
            this.MapDisplay.MetadataMap = null;
            this.MapDisplay.Name = "MapDisplay";
            this.MapDisplay.Size = new System.Drawing.Size(679, 485);
            this.MapDisplay.StampObjectMap = null;
            this.MapDisplay.TabIndex = 0;
            this.MapDisplay.Text = "mapDisplay1";
            this.MapDisplay.Texture = null;
            this.MapDisplay.Zoom = 0;
            this.MapDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseDown);
            this.MapDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseMove);
            this.MapDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseUp);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 592);
            this.Controls.Add(this.GroupBoxMap);
            this.Controls.Add(this.GroupBoxDrawingMode);
            this.Controls.Add(this.ButtonImport);
            this.Controls.Add(this.ButtonExport);
            this.Controls.Add(this.GroupBoxObject);
            this.Controls.Add(this.GroupBoxLayer);
            this.Controls.Add(this.ButtonImportMetadata);
            this.Controls.Add(this.VScrollBarObjectDisplay);
            this.Controls.Add(this.VScrollBarMapDisplay);
            this.Controls.Add(this.HScrollBarMapDisplay);
            this.Controls.Add(this.ObjectDisplay);
            this.Controls.Add(this.MapDisplay);
            this.Name = "MapEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyUp);
            this.GroupBoxLayer.ResumeLayout(false);
            this.GroupBoxObject.ResumeLayout(false);
            this.GroupBoxDrawingMode.ResumeLayout(false);
            this.GroupBoxMap.ResumeLayout(false);
            this.GroupBoxMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.MapDisplay MapDisplay;
        private CustomControls.ObjectDisplay ObjectDisplay;
        private System.Windows.Forms.HScrollBar HScrollBarMapDisplay;
        private System.Windows.Forms.VScrollBar VScrollBarMapDisplay;
        private System.Windows.Forms.VScrollBar VScrollBarObjectDisplay;
        private System.Windows.Forms.TextBox TextZoom;
        private System.Windows.Forms.Button ButtonImportMetadata;
        private System.Windows.Forms.GroupBox GroupBoxLayer;
        private System.Windows.Forms.Button ButtonAddLayer;
        private CustomControls.ListBox.DragDropListBox ListBoxLayer;
        private System.Windows.Forms.GroupBox GroupBoxObject;
        private CustomControls.ListBox.DragDropListBox ListBoxObject;
        private System.Windows.Forms.Button ButtonExport;
        private System.Windows.Forms.Button ButtonImport;
        private CustomControls.Radio.RadioListBox RadioListBoxDrawingMode;
        private System.Windows.Forms.GroupBox GroupBoxDrawingMode;
        private System.Windows.Forms.GroupBox GroupBoxMap;
        private System.Windows.Forms.Label LabelMapWidth;
        private System.Windows.Forms.Label LabelMapHeight;
        private System.Windows.Forms.TextBox TextBoxMapHeight;
        private System.Windows.Forms.TextBox TextBoxMapWidth;
        private System.Windows.Forms.Label LabelZoom;
        private System.Windows.Forms.Label LabelPercentZoom;
    }
}
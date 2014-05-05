namespace PrototypeMapEditor.EditorForm
{
    sealed partial class MapEditor
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.MapDisplay = new PrototypeMapEditor.CustomControls.MapDisplay();
            this.ListBoxMaps = new System.Windows.Forms.ListBox();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.TxtHeight = new System.Windows.Forms.TextBox();
            this.TxtWidth = new System.Windows.Forms.TextBox();
            this.TxtY = new System.Windows.Forms.TextBox();
            this.TxtX = new System.Windows.Forms.TextBox();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnInportar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(13, 528);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(679, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(695, 13);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 512);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.MapDisplay);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 512);
            this.panel2.TabIndex = 3;
            // 
            // MapDisplay
            // 
            this.MapDisplay.Location = new System.Drawing.Point(0, 0);
            this.MapDisplay.Name = "MapDisplay";
            this.MapDisplay.ObjetosDoMapa = null;
            this.MapDisplay.ObjetosDoMapaAtual = null;
            this.MapDisplay.Size = new System.Drawing.Size(679, 512);
            this.MapDisplay.TabIndex = 0;
            this.MapDisplay.Text = "mapDisplay";
            this.MapDisplay.Texture = null;
            this.MapDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseDown);
            this.MapDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseMove);
            this.MapDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapDisplay_MouseUp);
            // 
            // ListBoxMaps
            // 
            this.ListBoxMaps.FormattingEnabled = true;
            this.ListBoxMaps.Location = new System.Drawing.Point(715, 12);
            this.ListBoxMaps.Name = "ListBoxMaps";
            this.ListBoxMaps.Size = new System.Drawing.Size(185, 199);
            this.ListBoxMaps.TabIndex = 4;
            this.ListBoxMaps.DoubleClick += new System.EventHandler(this.listBoxMaps_DoubleClick);
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(715, 217);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(185, 23);
            this.btnLoadMap.TabIndex = 5;
            this.btnLoadMap.Text = "Carregar";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtName);
            this.panel1.Controls.Add(this.BtnExcluir);
            this.panel1.Controls.Add(this.TxtHeight);
            this.panel1.Controls.Add(this.TxtWidth);
            this.panel1.Controls.Add(this.TxtY);
            this.panel1.Controls.Add(this.TxtX);
            this.panel1.Location = new System.Drawing.Point(716, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 198);
            this.panel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(81, 4);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(100, 20);
            this.TxtName.TabIndex = 5;
            this.TxtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(4, 132);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(177, 23);
            this.BtnExcluir.TabIndex = 4;
            this.BtnExcluir.Text = "Remover";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // TxtHeight
            // 
            this.TxtHeight.Location = new System.Drawing.Point(81, 108);
            this.TxtHeight.Name = "TxtHeight";
            this.TxtHeight.Size = new System.Drawing.Size(100, 20);
            this.TxtHeight.TabIndex = 3;
            this.TxtHeight.TextChanged += new System.EventHandler(this.TxtHeight_TextChanged);
            this.TxtHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // TxtWidth
            // 
            this.TxtWidth.Location = new System.Drawing.Point(81, 82);
            this.TxtWidth.Name = "TxtWidth";
            this.TxtWidth.Size = new System.Drawing.Size(100, 20);
            this.TxtWidth.TabIndex = 2;
            this.TxtWidth.TextChanged += new System.EventHandler(this.TxtWidth_TextChanged);
            this.TxtWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // TxtY
            // 
            this.TxtY.Location = new System.Drawing.Point(81, 56);
            this.TxtY.Name = "TxtY";
            this.TxtY.Size = new System.Drawing.Size(100, 20);
            this.TxtY.TabIndex = 1;
            this.TxtY.TextChanged += new System.EventHandler(this.TxtY_TextChanged);
            this.TxtY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // TxtX
            // 
            this.TxtX.Location = new System.Drawing.Point(81, 30);
            this.TxtX.Name = "TxtX";
            this.TxtX.Size = new System.Drawing.Size(100, 20);
            this.TxtX.TabIndex = 0;
            this.TxtX.TextChanged += new System.EventHandler(this.TxtX_TextChanged);
            this.TxtX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Location = new System.Drawing.Point(715, 246);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(185, 23);
            this.BtnExportar.TabIndex = 7;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // BtnInportar
            // 
            this.BtnInportar.Location = new System.Drawing.Point(716, 273);
            this.BtnInportar.Name = "BtnInportar";
            this.BtnInportar.Size = new System.Drawing.Size(184, 23);
            this.BtnInportar.TabIndex = 8;
            this.BtnInportar.Text = "Importar";
            this.BtnInportar.UseVisualStyleBackColor = true;
            this.BtnInportar.Click += new System.EventHandler(this.BtnInportar_Click);
            // 
            // MapEditor
            // 
            this.ClientSize = new System.Drawing.Size(912, 563);
            this.Controls.Add(this.BtnInportar);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.ListBoxMaps);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Name = "MapEditor";
            this.Text = "Editor de metadados";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private CustomControls.MapDisplay MapDisplay;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox ListBoxMaps;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtHeight;
        private System.Windows.Forms.TextBox TxtWidth;
        private System.Windows.Forms.TextBox TxtY;
        private System.Windows.Forms.TextBox TxtX;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Button BtnInportar;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}
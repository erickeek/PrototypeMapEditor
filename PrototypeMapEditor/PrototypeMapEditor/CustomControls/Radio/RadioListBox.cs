using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PrototypeMapEditor.CustomControls.Radio
{
    public sealed class RadioListBox : System.Windows.Forms.ListBox
    {
        private readonly StringFormat _align;
        private bool _isTransparent;
        private Brush _backBrush;

        // Allows the BackColor to be transparent
        public override Color BackColor
        {
            get
            {
                return _isTransparent ? Color.Transparent : base.BackColor;
            }
            set
            {
                if (value == Color.Transparent)
                {
                    _isTransparent = true;
                    base.BackColor = (Parent == null) ? SystemColors.Window : Parent.BackColor;
                }
                else
                {
                    _isTransparent = false;
                    base.BackColor = value;
                }

                if (_backBrush != null)
                    _backBrush.Dispose();
                _backBrush = new SolidBrush(base.BackColor);

                Invalidate();
            }
        }

        [Browsable(false)]
        public override DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawFixed)
                    throw new Exception("Invalid value for DrawMode property");

                base.DrawMode = value;
            }
        }
        [Browsable(false)]
        public override SelectionMode SelectionMode
        {
            get
            {
                return base.SelectionMode;
            }
            set
            {
                if (value != SelectionMode.One)
                    throw new Exception("Invalid value for SelectionMode property");
                base.SelectionMode = value;
            }
        }

        // Public constructor
        public RadioListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            SelectionMode = SelectionMode.One;
            ItemHeight = FontHeight;

            _align = new StringFormat(StringFormat.GenericDefault) { LineAlignment = StringAlignment.Center };

            // Force transparent analisys
            BackColor = BackColor;
        }

        // Main paiting method
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            int maxItem = Items.Count - 1;

            if (e.Index < 0 || e.Index > maxItem)
            {
                // Erase all background if control has no items
                e.Graphics.FillRectangle(_backBrush, ClientRectangle);
                return;
            }

            // Calculate bounds for background, if last item paint up to bottom of control
            var backRect = e.Bounds;
            if (e.Index == maxItem)
                backRect.Height = ClientRectangle.Top + ClientRectangle.Height - e.Bounds.Top;
            e.Graphics.FillRectangle(_backBrush, backRect);

            // Determines text color/brush
            Brush textBrush;
            var isChecked = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            var state = isChecked ? RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
            if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
            {
                textBrush = SystemBrushes.GrayText;
                state = isChecked ? RadioButtonState.CheckedDisabled : RadioButtonState.UncheckedDisabled;
            }
            else if ((e.State & DrawItemState.Grayed) == DrawItemState.Grayed)
            {
                textBrush = SystemBrushes.GrayText;
                state = isChecked ? RadioButtonState.CheckedDisabled : RadioButtonState.UncheckedDisabled;
            }
            else
            {
                textBrush = SystemBrushes.FromSystemColor(ForeColor);
            }

            // Determines bounds for text and radio button
            var glyphSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, state);
            var glyphLocation = e.Bounds.Location;
            glyphLocation.Y += (e.Bounds.Height - glyphSize.Height) / 2;

            var bounds = new Rectangle(e.Bounds.X + glyphSize.Width, e.Bounds.Y, e.Bounds.Width - glyphSize.Width, e.Bounds.Height);

            // Draws the radio button
            RadioButtonRenderer.DrawRadioButton(e.Graphics, glyphLocation, state);

            // Draws the text
            if (!string.IsNullOrEmpty(DisplayMember)) // Bound Datatable? Then show the column written in Displaymember
                e.Graphics.DrawString(((System.Data.DataRowView)Items[e.Index])[DisplayMember].ToString(),
                    e.Font, textBrush, bounds, _align);
            else
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, textBrush, bounds, _align);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        // Prevent background erasing
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == 0x0014)  // WM_ERASEBKGND
            {
                m.Result = (IntPtr)1; // avoid default background erasing
                return;
            }

            base.DefWndProc(ref m);
        }

        // Other event handlers
        protected override void OnHandleCreated(EventArgs e)
        {
            if (FontHeight > ItemHeight)
                ItemHeight = FontHeight;

            base.OnHandleCreated(e);
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            if (FontHeight > ItemHeight)
                ItemHeight = FontHeight;
            Update();
        }
        protected override void OnParentChanged(EventArgs e)
        {
            // Force to change backcolor
            BackColor = BackColor;
        }
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            // Force to change backcolor
            BackColor = BackColor;
        }
    }
}

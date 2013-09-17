using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YLScsDrawing.Forms
{
    public partial class DialogConfig : Form
    {
        public DialogConfig()
        {
            InitializeComponent();
        }

        int w, h;
        Color canvasColor = Color.Transparent;
        bool isBiline = false;

        public int CanvasWidth
        {
            set { w = value; }
            get { return w; }
        }

        public int CanvasHeight
        {
            set { h = value; }
            get { return h; }
        }

        public Color CanvasColor
        {
            set { canvasColor = value; }
            get { return canvasColor; }
        }

        public bool IsBilineInterpolation
        {
            set { isBiline = value; }
            get { return isBiline; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblCanvasColor.BackColor = canvasColor;
            rbInterpo.Checked = isBiline;
            textBoxH.Text = h.ToString();
            textBoxW.Text = w.ToString();
        }

        private void rbInterpo_CheckedChanged(object sender, EventArgs e)
        {
            isBiline = rbInterpo.Checked;
        }

        private void textBoxW_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only digit 0 to 9, backspace  are permitted
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            w = int.Parse(textBoxW.Text);
            h = int.Parse(textBoxH.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblCanvasColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                canvasColor = color.Color;
                lblCanvasColor.BackColor = color.Color;
            }
        }
    }
}
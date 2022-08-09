﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceMaster
{
    public class buttonFormatting : Button
    {
        private static Font _normalFont = new Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private static Color _back = System.Drawing.Color.Gray;
        private static Color _border = System.Drawing.Color.Black;
        private static Color _activeBorder = System.Drawing.Color.Gray;
        private static Color _fore = System.Drawing.Color.White;

        private static Padding _margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        private static Padding _padding = new System.Windows.Forms.Padding(3, 3, 3, 3);

        private static Size _minSize = new System.Drawing.Size(75, 30);

        private bool _active;

        public buttonFormatting() : base()
        {
            base.Font = _normalFont;
            base.BackColor = Color.LightSkyBlue;
            base.ForeColor = _fore;
            base.FlatAppearance.BorderColor = _border;
            base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            base.FlatAppearance.BorderSize = 1;
            base.Margin = _margin;
            base.Padding = _padding;
            base.MinimumSize = _minSize;
        }



        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            UseVisualStyleBackColor = false;
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!_active)
                base.FlatAppearance.BorderColor = _activeBorder;
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!_active)
                base.FlatAppearance.BorderColor = _border;
        }

        public void SetStateActive()
        {
            _active = true;
            base.FlatAppearance.BorderColor = _activeBorder;
        }

        public void SetStateNormal()
        {
            _active = false;
            base.FlatAppearance.BorderColor = _border;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resize_Docked_Panel
{
    class Custome_Panel:Panel
    {

        public Custome_Panel() { }



        protected override void OnPaint(PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
            base.OnPaint(e);
        }
    }
}

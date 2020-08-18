using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resize_Docked_Panel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {

        }

        Point old_Loc;
        bool isResizing = false;




        // Mouse Move
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor.Position.X <= this.PointToScreen(panel1.Location).X + 100) // + 100 so there is not unhook when moving the cursor fast
            {

                // Only Cursor Icon
                if (Cursor.Position.X <= this.PointToScreen(panel1.Location).X + 10)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit;
                }

                if (isResizing == true)
                {
                    panel1.Width = panel1.Width - (old_Loc.X + e.X -10);
                }
            }

           
        }





        // Mouse Down
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
              
            if (Cursor.Position.X <= this.PointToScreen(panel1.Location).X + 10)
            {
                isResizing = true;
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit;
                old_Loc = e.Location;
            }
        }





        // Mouse UP
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }
    }
}

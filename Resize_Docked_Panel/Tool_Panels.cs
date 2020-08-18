using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resize_Docked_Panel
{
    class Tool_Panels
    {


        // Constructor
        public Tool_Panels() 
        {
           
        }


        // RIGHT - Tool - Panel - Variables
        Panel Right_Tool_Panel; //#
        Point Right_Tool_panel_Old_Location;
        bool Right_Tool_panel_Is_Resizing = false;





        //:::::::::::::--RIGHT--TOOL--Panel:::::::::::::::::::START::::::::::::::

        // Get Right Tool Panel
        public Panel Get_Right_Tool_Panel()
        {
            Right_Tool_Panel = new Panel();
            Right_Tool_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Right_Tool_Panel_Mouse_DOWN); // Mouse DOWN
            Right_Tool_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Right_Tool_Panel_Mouse_UP); // Mouse UP
            Right_Tool_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Right_Tool_Panel_Mouse_MOVE); // Mouse MOVE
            Right_Tool_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Right_Tool_Panel_OnPAINT); // Mouse MOVE
            Right_Tool_Panel.Resize += new System.EventHandler(this.Right_Tool_Panel_OnResize); // Mouse MOVE    //# Used For Refreshing the Border so it does not flickers


            // Remove Flickering---------------:::START:::
            typeof(Panel).GetProperty("ResizeRedraw", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Right_Tool_Panel, true, null);

            typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Right_Tool_Panel, true, null);

            // Remove Flickering---------------:::END:::



            return Right_Tool_Panel;
        }




        // Resize - Right Tool Panel
        private void Right_Tool_Panel_OnResize(object sender, EventArgs e)
        {
            if(Right_Tool_Panel.Parent != null)
            {

                Right_Tool_Panel.Parent.Refresh(); // Remove Border Ínproper Show
            }

        }






        // Paint - Right Tool Panel
        private void Right_Tool_Panel_OnPAINT(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, this.Right_Tool_Panel.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Inset); // Draw Border
           
        }



     



        // Mouse Down
        private void Right_Tool_Panel_Mouse_DOWN(object sender, MouseEventArgs e)
        {
            //Point locationOnForm = control.FindForm().PointToClient( control.Parent.PointToScreen(control.Location));
            if (Cursor.Position.X <= Right_Tool_Panel.Parent.PointToScreen(Right_Tool_Panel.Location).X + 10)
            {
                Right_Tool_panel_Is_Resizing = true;
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit;
                Right_Tool_panel_Old_Location = e.Location;
            }
        }  
        
        





        
        // Mouse UP
        private void Right_Tool_Panel_Mouse_UP(object sender, MouseEventArgs e)
        {
            Right_Tool_panel_Is_Resizing = false;
        }








        // Mouse Move
        private void Right_Tool_Panel_Mouse_MOVE(object sender, MouseEventArgs e)
        {
            

            if (Cursor.Position.X <= Right_Tool_Panel.Parent.PointToScreen(Right_Tool_Panel.Location).X + 100) // + 100 so there is not unhook when moving the cursor fast
            {

                // Only Cursor Icon
                if (Cursor.Position.X <= Right_Tool_Panel.Parent.PointToScreen(Right_Tool_Panel.Location).X + 10)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit;
                }

                if (Right_Tool_panel_Is_Resizing == true)
                {
                    Right_Tool_Panel.Width = Right_Tool_Panel.Width - (Right_Tool_panel_Old_Location.X + e.X - 10);
                }
            }

        }


        //:::::::::::::--RIGHT--TOOL--Panel:::::::::::::::::::END::::::::::::::

    }
}

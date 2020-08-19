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
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();

            Tool_Panels a = new Tool_Panels();
            a.Right_Tool_Panel = panel1;
            a.Get_Right_Tool_Panel();
            this.Controls.Add(a.Right_Tool_Panel);



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

        }


    }
}

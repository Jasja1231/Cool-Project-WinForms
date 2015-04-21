using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradedLab3P4
{
    public partial class Field : Button
    {
        bool marked;
        public Field()
        {
            InitializeComponent();
            this.MouseDown += Field_Click;
            //this.MouseEnter += Button_enter;
            //this.MouseLeave += Button_leave;
        }

        
        public void Field_Click(object sender, EventArgs e) {
            MouseEventArgs m = (MouseEventArgs)e;

            if (m.Button == MouseButtons.Right)
            {
                this.BackColor = Color.Black;
                marked = true;
            }
            else
                if (m.Button == MouseButtons.Left)
                {
                    TrackBar track = new TrackBar();
                }
        }

        private void Field_Load(object sender, EventArgs e)
        {

        }
    }
}

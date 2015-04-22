using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GradedLab3P4
{
    public partial class Field : Button
    {
        private bool marked;

        public Field()
        {
           
            InitializeComponent();
            this.MouseDown += Field_Click;
            this.BackColor = Color.Transparent;
            this.Text = "";
            //this.MouseEnter += Button_enter;
            //this.MouseLeave += Button_leave;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
          
        
        public void Field_Click(object sender, EventArgs e) {
            MouseEventArgs m = (MouseEventArgs)e;

            if (m.Button == MouseButtons.Right)
            {
                //this.BackColor = Color.Black;
                marked = true;

                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Reset");
                Button b = (Button)sender;
                b.ContextMenu = cm;

            }
            else
                if (m.Button == MouseButtons.Left)
                {
                   
                }
        }

        private void Field_Load(object sender, EventArgs e)
        {

        }
    }
}

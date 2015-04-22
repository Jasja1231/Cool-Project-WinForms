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
        private int check;  
        private ContextMenu cm;
        private  static int Player = 1;

        public Field()
        {
            InitializeComponent();
            this.MouseDown += Field_Click;
            this.BackColor = Color.Transparent;
            this.Text = "";

            check = 0;
            this.Paint += Circle_Paint;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }


        public void Field_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;

            if (m.Button == MouseButtons.Right)
            {
                check = -1;
                cm = new ContextMenu();
                cm.MenuItems.Add("Reset", cm_func);

                Button b = (Button)sender;

                b.ContextMenu = cm;


            }
            else
                if (m.Button == MouseButtons.Left)
                {
                    if (check == 0)
                    {
                        if (Player == 1) // ying
                        {
                            this.Paint -= Circle_Paint;
                            this.Paint += yingpaint;
                            Player = Player + 1;
                            check = -1;
                        }
                        else if (Player == 2) //yang
                        {
                            this.Paint -= Circle_Paint;
                            this.Paint += yangpaint;
                            Player = Player - 1;
                            check = 1;
                        }

                    }
                }
        }


        private void Field_Load(object sender, EventArgs e)
        {

        }


        //menu strip 
        private void cm_func(object sender, EventArgs e) {
            check = 0;
            MenuItem item = sender as MenuItem;
            ContextMenu menu = item.GetContextMenu();
            Control source = menu.SourceControl;
            Field ying = (Field)source;
       //     if (ying.check == 1)
                ying.Paint -= ying.yingpaint;
       //     if (ying.check == -1)
                ying.Paint -= ying.yangpaint;
            if (ying.check != 0)
                ying.Paint += ying.Circle_Paint;
            ying.check = 0;
            ying.Refresh();

        }

        //Paint Main circle 
        public void Circle_Paint(object sender, PaintEventArgs e){
            GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle newRectangle = this.ClientRectangle;
            buttonPath.AddEllipse(newRectangle);
            this.Region = new Region(buttonPath);
        }

        //Region setter - yion
        public void yingpaint (object sender,  PaintEventArgs e){
            var buttonPath = new GraphicsPath();
            var buttonPath2 = new GraphicsPath();
            var buttonPath3 = new GraphicsPath();
            var buttonPath4 =new GraphicsPath();
            var buttonPath5 =new GraphicsPath();

            var  borderPath =new GraphicsPath();
            var borderPath2 = new GraphicsPath();

            Rectangle newRectangle = this.ClientRectangle; //circleArea whol space
            Rectangle border1 = newRectangle;
            Rectangle border2 = new Rectangle(new Point(this.ClientRectangle.Right * 1 / 100, this.ClientRectangle.Bottom * 1 / 100), new Size(this.Size.Width * 98 / 100, this.Size.Height * 98 / 100));
            Rectangle circle1 = new Rectangle(new Point (this.ClientRectangle.Right * 1/4, this.ClientRectangle.Top), new Size(this.Size.Width/2, this.Size.Height/2));
            Rectangle circle2 = new Rectangle(new Point(this.ClientRectangle.Right * 1/4, this.ClientRectangle.Bottom/2), new Size(this.Size.Width / 2, this.Size.Height / 2));
            Rectangle region = new Rectangle(new Point(this.ClientRectangle.Left, this.ClientRectangle.Top), this.ClientRectangle.Size);
            Rectangle small1 = new Rectangle(new Point(this.ClientRectangle.Right / 2 - this.Size.Height / 20, this.ClientRectangle.Bottom * 3 / 4 - this.Size.Height / 10), new Size(this.Size.Width / 10, this.Size.Height / 10));
            Rectangle small2 = new Rectangle(new Point(this.ClientRectangle.Right / 2 - this.Size.Height / 20, this.ClientRectangle.Bottom * 1 / 4 - this.Size.Height / 10), new Size(this.Size.Width / 10, this.Size.Height / 10));
            
           
            // Create a circle within the new rectangle.
            borderPath.AddEllipse(border1);
            borderPath2.AddEllipse(border2);

            buttonPath.AddPie(newRectangle, 270 ,180);
            buttonPath2.AddEllipse(circle1);
            buttonPath3.AddPie(circle2, 270, 180);
            buttonPath4.AddEllipse(small1);
            buttonPath5.AddEllipse(small2);

            // Set the button's Region property to the newly created  
            // circle region.
            Region b_region = new Region(borderPath);
            b_region.Xor(borderPath2);
            Region r = new Region(buttonPath);
            r.Union(buttonPath2);
            r.Xor(buttonPath3);
            r.Union(buttonPath4);
            r.Xor(buttonPath5);
            r.Union(b_region);
            this.Region = r;
        }


        public void yangpaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var buttonPath = new GraphicsPath();
            var buttonPath2 = new GraphicsPath();
            var buttonPath3 = new GraphicsPath();
            var buttonPath4 = new GraphicsPath();
            var buttonPath5 = new GraphicsPath();

            var borderPath = new GraphicsPath();
            var borderPath2 = new GraphicsPath();

            Rectangle newRectangle = this.ClientRectangle; //circleArea whol space
            Rectangle border1 = newRectangle;
            Rectangle border2 = new Rectangle(new Point(this.ClientRectangle.Right * 1 / 100, this.ClientRectangle.Bottom * 1 / 100), new Size(this.Size.Width * 98 / 100, this.Size.Height * 98 / 100));
            Rectangle circle1 = new Rectangle(new Point(this.ClientRectangle.Right * 1 / 4, this.ClientRectangle.Top), new Size(this.Size.Width / 2, this.Size.Height / 2));
            Rectangle circle2 = new Rectangle(new Point(this.ClientRectangle.Right * 1 / 4, this.ClientRectangle.Bottom / 2), new Size(this.Size.Width / 2, this.Size.Height / 2));
            Rectangle region = new Rectangle(new Point(this.ClientRectangle.Left, this.ClientRectangle.Top), this.ClientRectangle.Size);
            Rectangle small1 = new Rectangle(new Point(this.ClientRectangle.Right / 2 - this.Size.Height / 20, this.ClientRectangle.Bottom * 3 / 4 - this.Size.Height / 10), new Size(this.Size.Width / 10, this.Size.Height / 10));
            Rectangle small2 = new Rectangle(new Point(this.ClientRectangle.Right / 2 - this.Size.Height / 20, this.ClientRectangle.Bottom * 1 / 4 - this.Size.Height / 10), new Size(this.Size.Width / 10, this.Size.Height / 10));
            
          

            // Create a circle within the new rectangle.
            borderPath.AddEllipse(border1);
            borderPath2.AddEllipse(border2);

            buttonPath.AddPie(newRectangle, 90,180);
            buttonPath2.AddEllipse(circle1);
            buttonPath3.AddPie(circle2, 90,180);
            buttonPath4.AddEllipse(small1);
            buttonPath5.AddEllipse(small2);
            // Set the button's Region property to the newly created  
            // circle region.
            Region b_region = new Region(borderPath);
            b_region.Xor(borderPath2);
            Region r = new Region(buttonPath);
            r.Union(buttonPath2);
            r.Xor(buttonPath3);
            r.Union(buttonPath4);
            r.Xor(buttonPath5);
            r.Union(b_region);
            this.Region = r;
         }

    }
}

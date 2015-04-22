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

        
        public void Field_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;

            if (m.Button == MouseButtons.Right)
            {
                //check = -1;
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

            

            MenuItem item = sender as MenuItem;
            ContextMenu menu = item.GetContextMenu();
            Control source = menu.SourceControl;
           
            Field ying = (Field)source;
           if (ying.check == 1)
                ying.Paint -= ying.yingpaint;
           if (ying.check == -1)
                ying.Paint -= ying.yangpaint;
           if (ying.check != 0)
                ying.Paint += ying.Circle_Paint;
            ying.check = 0;
            ying.Refresh();

            check = 0;
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

            var BigCircle = new GraphicsPath();   // path for background border
            var SmallCircle = new GraphicsPath();   // path for working area

            Rectangle BigCircleRect = this.ClientRectangle;
            Rectangle SmallCircleRect = new Rectangle(new Point(this.ClientRectangle.Right * 5 / 100, this.ClientRectangle.Bottom * 5 / 100), new Size(this.Size.Width * 90 / 100, this.Size.Height * 90 / 100));

            BigCircle.AddEllipse(BigCircleRect);
            SmallCircle.AddEllipse(SmallCircleRect);

            //Border added
            Region region = new Region(BigCircle);
            region.Xor(SmallCircle);
            


            Rectangle SmallerCircleRect1 = new Rectangle((new Point((SmallCircleRect.Right - SmallCircleRect.Left) * 1/2 - this.ClientRectangle.Right * 9/10 * 1/ 4 + 4, SmallCircleRect.Top)), new Size(SmallCircleRect.Size.Width * 1 / 2, SmallCircleRect.Size.Height * 1 / 2));
            var SmallerCircle1 = new GraphicsPath();
            SmallerCircle1.AddEllipse(SmallerCircleRect1);
            region.Union(SmallerCircle1);



             Rectangle SmallerCircleRect2 = new Rectangle((new Point((SmallCircleRect.Right - SmallCircleRect.Left) * 1/2 - this.ClientRectangle.Right * 9/10 * 1 / 4 + 4, SmallerCircleRect1.Bottom - 1)), new Size(SmallCircleRect.Size.Width * 1 / 2 + 2, SmallCircleRect.Size.Height * 1 / 2 + 2));
             var SmallerCircle2 = new GraphicsPath();
             SmallerCircle2.AddEllipse(SmallerCircleRect2);
             region.Union(SmallerCircle2);


             var HalfSmallCircle = new GraphicsPath();
             HalfSmallCircle.AddPie(SmallCircleRect, 270, 180);
             region.Union(HalfSmallCircle);


             region.Xor(SmallerCircle2);

             Rectangle MiniCircleRect1 = new Rectangle(new Point(SmallerCircleRect1.Right/2 - SmallerCircleRect1.Size.Width/8 + 15, SmallerCircleRect1.Bottom/2 - SmallerCircleRect1.Size.Width/8), new Size(SmallerCircleRect1.Size.Width * 1/4, SmallerCircleRect1.Size.Height * 1/4));
             var MiniCircle1 = new GraphicsPath();
             MiniCircle1.AddEllipse(MiniCircleRect1);
             region.Xor(MiniCircle1);


             Rectangle MiniCircleRect2 = new Rectangle(new Point(SmallerCircleRect2.Right/2 - SmallerCircleRect2.Size.Width/8 + 15, SmallerCircleRect2.Bottom/2 - SmallerCircleRect2.Size.Width/8 + 30), new Size(SmallerCircleRect2.Size.Width * 1/4, SmallerCircleRect2.Size.Height * 1/4));
             var MiniCircle2 = new GraphicsPath();
             MiniCircle2.AddEllipse(MiniCircleRect2);
             region.Xor(MiniCircle2);
             
             this.Region = region;

        }


        public void yangpaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var BigCircle = new GraphicsPath();   // path for background border
            var SmallCircle = new GraphicsPath();   // path for working area

            Rectangle BigCircleRect = this.ClientRectangle;
            Rectangle SmallCircleRect = new Rectangle(new Point(this.ClientRectangle.Right * 5/100, this.ClientRectangle.Bottom * 5/100), new Size(this.Size.Width * 90/100, this.Size.Height * 90/100));

            BigCircle.AddEllipse(BigCircleRect);
            SmallCircle.AddEllipse(SmallCircleRect);
            //Border added
            Region region = new Region(BigCircle);
            region.Xor(SmallCircle);
           // this.Region = region;


            Rectangle SmallerCircleRect1 = new Rectangle((new Point((SmallCircleRect.Right - SmallCircleRect.Left) * 1/2 - this.ClientRectangle.Right * 9/10 *1/4 +4 , SmallCircleRect.Top)), new Size(SmallCircleRect.Size.Width *1/2,SmallCircleRect.Size.Height * 1/2));
            var SmallerCircle1 = new GraphicsPath();
            SmallerCircle1.AddEllipse(SmallerCircleRect1);
            region.Union(SmallerCircle1);

            //this.Region = region;
            Rectangle SmallerCircleRect2 = new Rectangle((new Point((SmallCircleRect.Right - SmallCircleRect.Left) * 1/2 - this.ClientRectangle.Right * 9/10 * 1/4+4, SmallerCircleRect1.Bottom-1)), new Size(SmallCircleRect.Size.Width * 1/2+2, SmallCircleRect.Size.Height * 1/2+2));
            var SmallerCircle2 = new GraphicsPath();
            SmallerCircle2.AddEllipse(SmallerCircleRect2);
            region.Union(SmallerCircle2);


            var HalfSmallCircle = new GraphicsPath();
            HalfSmallCircle.AddPie(SmallCircleRect , 90 , 180);
            region.Union(HalfSmallCircle);


            region.Xor(SmallerCircle1);

            Rectangle MiniCircleRect1 = new Rectangle(new Point(SmallerCircleRect1.Right/2 - SmallerCircleRect1.Size.Width/8 + 5 , SmallerCircleRect1.Bottom/2 - SmallerCircleRect1.Size.Width/8 ), new Size(SmallerCircleRect1.Size.Width * 1 / 4, SmallerCircleRect1.Size.Height * 1 / 4));
            var MiniCircle1 = new GraphicsPath();
            MiniCircle1.AddEllipse(MiniCircleRect1);
            region.Xor(MiniCircle1);

            
            Rectangle MiniCircleRect2 = new Rectangle(new Point(SmallerCircleRect2.Right/2 - SmallerCircleRect2.Size.Width/8 + 15 , SmallerCircleRect2.Bottom/2 - SmallerCircleRect2.Size.Width / 8 + 30), new Size(SmallerCircleRect2.Size.Width * 1 / 4, SmallerCircleRect2.Size.Height * 1 / 4));
            var MiniCircle2 = new GraphicsPath();
            MiniCircle2.AddEllipse(MiniCircleRect2);
            region.Xor(MiniCircle2);



            this.Region = region;
            
         }

    }
}

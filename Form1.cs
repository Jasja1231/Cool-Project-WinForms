using System;

using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace GradedLab3P4
{
    public partial class Form1 : Form
    {
       
       private Bitmap image1;
       

        public Form1()
        {
            InitializeComponent();
        }


        private Bitmap rotateImage(Bitmap b, float angle) {
            if (b == null)
                    throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            returnBitmap.SetResolution(b.HorizontalResolution, b.VerticalResolution);


            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);

            //move rotation point to center of image
            g.TranslateTransform(b.Width / 2,b.Height / 2);

            //rotate
            g.RotateTransform(angle);

            //move image back
            g.TranslateTransform(-b.Width / 2, -b.Height / 2);

            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
         }
          

         private void Form1_Load(object sender, EventArgs e)
        {
           image1 = (Bitmap)Image.FromFile("C:\\Users\\Home\\Documents\\GitHub\\Cool-Project-WinForms\\bin\\YinYangRedSmal.JPG", true);
           BackColor = Color.White; //should be white
           TransparencyKey = Color.White;
        }

        private void RotateTimer_Tick(object sender, EventArgs e)
        {
            image1 = rotateImage(image1, 2);
            BackgroundImage = (Image)image1;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            RotateTimer.Stop();
            CloseTimer.Stop();
        }



    }
}

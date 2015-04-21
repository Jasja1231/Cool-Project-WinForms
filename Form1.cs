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
    public partial class Form1 : Form
    {
        Timer MyTimer = new Timer();
       
        


        public Form1()
        {
            InitializeComponent();

             MyTimer.Interval = (2000); // 2 seconds = 2 * 10^3 = 2000
             MyTimer.Tick += new EventHandler(MyTimer_Tick);
             MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            MyTimer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    }
}

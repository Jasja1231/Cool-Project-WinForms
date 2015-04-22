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
    public partial class GameForm : Form
    {
        Timer MyTimer = new Timer();
        TableLayoutPanel board = new TableLayoutPanel();


        public GameForm()
        {
            InitializeComponent();
            this.Visible = false;
            
            
            MyTimer.Interval = (2202); // 2 seconds = 2 * 10^3 = 2000
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
          
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            this.Visible = true;
            MyTimer.Stop();
        }


        private void GameForm_Load(object sender, EventArgs e)
        {
            CreateGame(3, 3);
        }

        private void CreateGame(int rows, int cols)
        {
            board.Dock = DockStyle.Fill;
            board.ColumnStyles.Clear();
            board.RowStyles.Clear();
            //set number of rows and columns +2 for menubar and tool strip
            board.RowCount = rows;
            board.ColumnCount = cols;


            panelBase.Dock = DockStyle.Fill;
            //set number of rows and columns
            board.RowCount = rows;
            board.ColumnCount = cols;

            for (int i = 1; i <= rows; i++)
            {
                board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60));
            }
            for (int i = 1; i <= cols; i++)
            {
                board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60));
            }

            board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) {
                    //Create a button
                    Field b = new Field();
                    b.Dock = DockStyle.Fill;
                    board.Controls.Add(b, j/*column*/, i); // i - rows , j - colums
                    panelBase.Controls.Add(board);
                }
            }

        }

        
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            CreateGame(trackBar1.Value, trackBar1.Value);
        }
    }
}

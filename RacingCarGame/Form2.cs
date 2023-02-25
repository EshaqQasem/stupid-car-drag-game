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

namespace RacingCarGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         Graphics g=  this.pictureBox1.CreateGraphics();
           g. RotateTransform(45);
            
           
            GraphicsPath p = new GraphicsPath();
        
             Rectangle r=this.pictureBox1.ClientRectangle;
             p.AddRectangle(r);
           
           //  p.AddEllipse(r);
           p.Transform(new Matrix(r, new Point[] { new Point(r.X , r.Y - 20), new Point(r.Right , r.Y - 20), new Point(r.X , r.Y - 20) }));
             this.pictureBox1.Region = new Region(p);
             this.pictureBox1.Invalidate();
          
             this.Refresh();
            //MessageBox.Show(";;");
        }
    }
}

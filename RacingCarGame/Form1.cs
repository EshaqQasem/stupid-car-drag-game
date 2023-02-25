using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RacingCarGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myCar = new Car(this.street1);
            myCar.Image = new Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\car_racing_100px.png");
            myCar.Size = new Size(34, 80);
            myCar.Location = new Point(this.street1.Width / 2 - myCar.Size.Width / 2, this.street1.Height - myCar.Size.Height);
            myCar.Speed = 15;
            this.street1.RacerCar=myCar;

        }
        Car myCar;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.street1.movedCar.ForEach(c => { c.moveBack(); if (c.Y > this.street1.Height) c = null; });
            if (myCar.Crash())
            {
                timer1.Enabled = timer2.Enabled = false;

            }
            this.street1.ScrollLines();
            this.myCar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            switch(e.KeyCode)
            {
                case Keys.Right:
                    this.myCar.moveRight();
                    break;
                case Keys.Left:
                    this.myCar.moveLeft();
                    break;
                case Keys.Up:
                    this.myCar.moveForward();
                    break;
                case Keys.Down:
                    this.myCar.moveBack();
                    break;
                   
            }
            if (myCar.Crash())
            {
               timer1.Enabled = timer2.Enabled = false;
               
            }
        }
        Thread veiwMovement;
        Thread newCars;
        static Image carsImage;
        private void Form1_Load(object sender, EventArgs e)
        {
            carsImage = new Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\car_racing_100px.png");
          //  carsImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            myCar.Show();
          /*   newCars = new Thread(()=>{
                while (true)
                {
                    Random r = new Random();

                    //for (int i = 0; i < carNums; i++)

                    Car c = new Car(this.street1);
                    c.Image = new Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\" + r.Next(1, 4).ToString() + ".png");
                    c.Size = new Size(34, 80);
                    int p = r.Next(0, 3) * this.street1.Width / this.street1.PathNums;
                    c.Location = new Point(p, 0);
                    c.Speed = 4;
                    c.Show();
                    this.street1.movedCar.Add(c);
                    //  this.street1.movedCar.Add(c);
                    Thread.Sleep(1000);
                }
            });
          //  newCars.Start();

             veiwMovement = new Thread(() =>
            {
                while (true)
                {
                    this.street1.movedCar.ForEach(c => c.moveBack());
                    if (myCar.Crash())
                    {
                        timer1.Enabled = timer2.Enabled = false;

                    }
                    this.street1.ScrollLines();
                    Thread.Sleep(10);
                }
            });
             //veiwMovement.Start();
           * */
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
          
            //for (int i = 0; i < carNums; i++)
            {
                Car c = new Car(this.street1);
                c.Image = carsImage;// new Bitmap(System.IO.Directory.GetCurrentDirectory() + "\\" + r.Next(1, 4).ToString() + ".png");
                c.Size = new Size(34, 80);
                int p =(new Random()).Next(21, this.street1.Width - 21);// *this.street1.Width / this.street1.PathNums;
                c.Location = new Point(p,0);
                c.Speed = 4;
                c.Show();
                this.street1.movedCar.Add(c);
              //  this.street1.movedCar.Add(c);
               
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
           // this.street1.movedCar.ForEach(c => c.Hide());
            this.street1.movedCar.Clear();
            myCar.Location = new Point(this.street1.Width / 2 - myCar.Size.Width / 2, this.street1.Height - 2 * myCar.Size.Height);
            this.street1.Size = new Size(this.street1.Width,this.street1.Height);
            this.street1.Invalidate();
            myCar.Show();
            timer1.Enabled = timer2.Enabled = true;
        }

        private void btnRestart_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           // MessageBox.Show(";");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.street1.ScrollSideLines();
        }
    }
}

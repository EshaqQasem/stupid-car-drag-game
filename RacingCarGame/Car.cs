using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RacingCarGame
{
    class Car
    {
        
        Street pStreet;
        public Car(Street pStreet)
        {
            this.pStreet = pStreet;
            Corners = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                Corners[i] = new Point();
            }
            
        }
        int rotate;
        static double t = 0;
        public void Show()
        {
           
           Graphics g= pStreet.CreateGraphics();
         /*  t += 0.1;
           if (rotate > 0)
           {
               this.X += (int)t;
             //  rotate--;
           }
           if (rotate < 0)
           {
               this.X -= 1;
            //   rotate++;
           }
            */
           rotate = 0;
           g.DrawImage(this.Image,new Point[] { new Point(X+ rotate, Y - rotate), new Point(X+this.Size.Width+rotate, Y + rotate), new Point(X-rotate ,Y+this.Size.Height-rotate )},new Rectangle(12,0,30,70),GraphicsUnit.Pixel );

           
        }
        Point[] Corners;
        public void Hide()
        {
           Graphics g = pStreet.CreateGraphics();
           g.FillRectangle(new SolidBrush(pStreet.BackColor), new Rectangle(this.Location, this.Size));
            Bitmap tmp = new Bitmap(this.Size.Width,this.Size.Height);
         
        }
        
        public void moveRight()
        {
           // for (int i = 0; i < speed; i++)
            if (this.X + this.size.Width < pStreet.Width - 21)
            {
                this.rotate+=3;
                this.X += speed;
               
            }
                Graphics g;
            
        }

        public void moveLeft()
        {
           // for(int i=0;i<speed;i++)
                if(this.X>21)
            this.X -= speed;
        }

        public void moveForward()
        {
            this.Y -= speed;
        }
        public void moveBack()
        {
            this.Y += this.Speed;
        }

        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        Point location;

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public int X
        {
            get { return this.location.X; }
            set
            {
                //if (this.X + this.size.Width < pStreet.Width - 21)
                {
                    this.Hide();
                    this.location.X = value;
                    this.Show();
                }
            }
        }


        public int Y
        {
            get { return this.location.Y; }
            set
            {
               
                this.Hide();
                this.location.Y = value;
                this.Show();
            }
        }
        Size size;

        public Size Size
        {
            get { return size; }
            set { size = value; }
        }
        Rectangle getRectangle()
        {
            return new Rectangle(this.Location, this.Size);
        }
        public bool Crash()
        {
           Car tmp= pStreet.movedCar.Find(c => c.getRectangle().IntersectsWith(this.getRectangle()));
            return tmp==null?false:true;
        }
        Image image;

        public Image Image
        {
            get { return image; }
            set {
               
                image = value; }
        }

    }
}

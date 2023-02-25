using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RacingCarGame
{
    class Line
    {
        Point location;

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        

        public int X
        {
            get { return this.location.X; }
            set { this.location.X = value; }
        }
       

        public int Y
        {
            get { return this.location.Y; }
            set { this.location.Y = value; }
        }

        static int width;

        public static int Width
        {
            get { return Line.width; }
            set { Line.width = value; }
        }
         int length;

        public  int Length
        {
            get { return length; }
            set { length = value; }
        }
         Color color;

        public  Color Color
        {
            get { return color; }
            set { color = value; }
        }
        static Graphics graphicsPath;

        public static Graphics GraphicsPath
        {
            get { return Line. graphicsPath; }
            set { Line.graphicsPath = value; }
        }
        public void Draw()
        {
            Line.GraphicsPath.DrawLine(new Pen(Color, Line.Width), this.Location, new Point(this.X, this.Y + this.Length)); 
        }

        public void Erase(Color backColor)
        {
            Line.GraphicsPath.DrawLine(new Pen(backColor, Line.Width), this.Location, new Point(this.X, this.Y + this.Length)); 
       
        }
    }

    class Street:Panel
    {
        int pathNums;

        public int PathNums
        {
            get { return pathNums; }
            set { pathNums = value; }
        }
        int pathWidth;

        public int PathWidth
        {
            get { return pathWidth; }
            set { pathWidth = value; }
        }
        Line[] ScrolledLines;

        internal Line[] ScrolledLines1
        {
            get { return ScrolledLines; }
            set { ScrolledLines = value; }
        }
        int scrolledLineNums;

        public int ScrolledLineNums
        {
            get { return scrolledLineNums; }
            set { scrolledLineNums = value; }
        }
        int scrolledLineLength;

        public int ScrolledLineLength
        {
            get { return scrolledLineLength; }
            set { scrolledLineLength = value; }
        }
        public Street()
        {
           
            this.PathNums = 3;
            scrolledLineNums= 4;
           
          //  Line.Length = (this.Height / (2*scrolledLineNums-1)) ;
            Line.Width = 2;
            Line.GraphicsPath = this.CreateGraphics();
          // scrolledLineNums++;
            this.ScrolledLines = new Line[scrolledLineNums];
           

            for (int i = 0; i < scrolledLineNums; i++)
            {
                this.ScrolledLines[i] = new Line();
                this.ScrolledLines[i].Color = Color.White;
                this.ScrolledLines[i].Length = (this.Height / (2 * scrolledLineNums - 1));
               // this.ScrolledLines[i].Location = new Point(this.Width / this.pathNums, this.Height - (Line.Length) * (i + 1) - (i * 15));
               
            }
            
        }
      // public  List<Car> Cars = new List<Car>();
        Control[] sideLines = new Control[20];
        public List<Car> movedCar = new List<Car>();
        public Car RacerCar;
        public void ScrollLines()
        {
            // Line.GraphicsPath = this.CreateGraphics();
           /* this.sideLines.ForEach(l =>
            {
                l.Erase(this.BackColor);
                l.X = this.Width - 21;
                l.Erase(this.BackColor);
                l.X = 21;

                l.Y += 2;
                if (l.Y > this.Height)
                    l.Y = -l.Length;
                l.Draw();
                l.X = this.Width - 21;
                l.Draw();
                l.X = 21;
            });
           
           */ 
            for (int i = 0; i < scrolledLineNums; i++)
            {
                this.ScrolledLines[i].Erase(this.BackColor);
                  if (this.PathNums == 3)
               {
                   this.ScrolledLines[i].X += this.PathWidth;
                   this.ScrolledLines[i].Erase(this.BackColor);
                   this.ScrolledLines[i].X -= this.PathWidth;
               }
                if (this.ScrolledLines[i].Y >= this.Height)
                {
                    this.ScrolledLines[i].Y = -this.ScrolledLines[i].Length;
                }
                this.ScrolledLines[i].Y+=8;
                 this.ScrolledLines[i].Draw();
                 if (this.PathNums == 3)
                 {
                     this.ScrolledLines[i].X += this.PathWidth;
                     this.ScrolledLines[i].Draw();
                     this.ScrolledLines[i].X -= this.PathWidth;
                 }
            }

           
        }
        public void ScrollSideLines()
        {
         for (int i = 0; i < 20; i++)
            {
                Control l = sideLines[i];
           
              

               l.Top += 5;
               if (l.Top > this.Height)
                   l.Top = -l.Height;
              
           }
        }
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Line.GraphicsPath = this.CreateGraphics();
          //  Line.Length = (this.Height / (2*scrolledLineNums-1)) ;
            PathWidth = (this.Width - 40) / this.pathNums;

            for (int i = 0; i < scrolledLineNums; i++)
            {
                this.ScrolledLines[i].Length = (this.Height / (2 * scrolledLineNums - 1));

                this.ScrolledLines[i].Location = new Point(20 + PathWidth, (this.ScrolledLines[i].Length) * (2 * i));
                
            }
           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < 20; i++)
            {
                Control tmp = new Control();
                tmp.Size =new Size(2, this.Height / 39);
                tmp.Location = new Point(21, 2 * i * tmp.Height);
                tmp.BackColor = Color.Yellow;

                this.Controls.Add(tmp);
               
                this.sideLines[i] = tmp;
            }
            
            
           // Cars.ForEach(c => c.Show()); 
           // this.RacerCar.Show();
            for (int i = 0; i < scrolledLineNums; i++)
            {
               
                this.ScrolledLines[i].Draw();
                if (this.PathNums == 3)
                {
                    this.ScrolledLines[i].X += this.PathWidth;
                    this.ScrolledLines[i].Draw();
                    this.ScrolledLines[i].X -= this.PathWidth;
                }
              
            } 
            
        }
    }
}

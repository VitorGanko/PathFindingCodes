using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingSystem
{
    class PathBlock
    {
        private int line, colunm, widthHeight, G, H;
        private System.Drawing.Rectangle pathRect;
        private System.Drawing.Brush brush;
        private bool pointA = false, pointB = false, wall = false, walkable = false;
        
        public PathBlock(int line, int colunm, int widthHeight)
        {
            this.line = line;
            this.colunm = colunm;
            this.widthHeight = widthHeight;

            this.pathRect = new System.Drawing.Rectangle(widthHeight + (widthHeight * colunm) + ((widthHeight / 20) * colunm), 
                (widthHeight * line) + ((widthHeight/20) * line), widthHeight, widthHeight);
        }

        public void transformInWall(object sender, System.Windows.Forms.MouseEventArgs m)
        {
            if (m.X > this.pathRect.X && m.X < this.pathRect.X + this.widthHeight &&
                m.Y > this.pathRect.Y && m.Y < this.pathRect.Y + this.widthHeight && 
                m.Clicks > 0 && this.walkable)
            {
                this.wall = true;
                this.walkable = false;
            }

        }

        public void draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(brush, pathRect);
        }

        public int F
        {
            get { return this.G + this.H; }
        }

        public int getG
        {
            get { return this.G; }
            set { this.G = value; }
        }

        public int getH
        {
            get { return this.H; }
            set { this.H = value; }
        }

        public int getLine
        {
            get { return this.line; }
            set { this.line = value; }
        }

        public int getColunm
        {
            get { return this.colunm; }
            set { this.colunm = value; }
        }

        public bool isPointA
        {
            get { return this.pointA; }
            set { this.pointA = value; }
        }

        public bool isPointB
        {
            get { return this.pointB; }
            set { this.pointB = value; }
        }

        public bool isWall
        {
            get { return this.wall; }
            set { this.wall = value; }
        }

        public bool isWalkable
        {
            get { return this.walkable; }
            set { this.walkable = value; }
        }

        public System.Drawing.Rectangle getRectInformations
        {
            get { return this.pathRect; }
        }

        public System.Drawing.Brush getColor
        {
            get { return this.brush; }
            set { this.brush = value; }
        }

    }
}

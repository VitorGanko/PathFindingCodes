using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingSystem
{
    class PathBlock
    {
        private int line, colunm, widthHeight, F;
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

        public void draw(System.Drawing.Graphics g)
        {
            g.FillRectangle(brush, pathRect);
        }

        public int getF
        {
            get { return this.F; }
            set { this.F = value; }
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

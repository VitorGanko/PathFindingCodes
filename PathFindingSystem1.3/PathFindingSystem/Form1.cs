using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFindingSystem
{
    public partial class Form1 : Form
    {
        PaintEventHandler paint;
        PathBlock pb, pointA, pointB, nextStep;
        List<PathBlock> pathManager = new List<PathBlock>();
        List<PathBlock> gridWalkable;
        PathBlock[] points;
        int widthHeight = 50, lineA, columA;

        public Form1()
        {
            InitializeComponent();

            setup();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);


            paint += new PaintEventHandler(draw);

            Timer t = new Timer();
            t.Interval = 1000;
            t.Start();
            t.Tick += new EventHandler(update);
        }

        //Paint do Form1
        public void draw(object sender, PaintEventArgs paint)
        { 
            foreach(PathBlock path in pathManager)
            {
                if (path.isPointA) path.getColor = Brushes.Green;
                else if (path.isPointB) path.getColor = Brushes.Red;
                else if (path.isWall) path.getColor = Brushes.Brown;
                else if (path.isWalkable) path.getColor = Brushes.Black;
                else if (!path.isWalkable) path.getColor = Brushes.Gray;
                

                path.draw(paint.Graphics);
            }
        }

        //update
        public void update(object sender, EventArgs e)
        {
            if (pointA.getLine != pointB.getLine || pointA.getColunm != pointB.getColunm)
            {
                moveOn();
            }

            Invalidate();

        }

        //método para pegar os grids próximos ao ponto A
        public void moveOn()
        {
            foreach (PathBlock path in pathManager)
            {
                if (path.isPointA)
                {
                    this.lineA = path.getLine;
                    this.columA = path.getColunm;
                }
            }

            gridWalkable = new List<PathBlock>();

            foreach (PathBlock path in pathManager)
            {
                if (/*path.getLine == (this.lineA - 1) && path.getColunm == (this.columA - 1) && path.isWalkable == true ||*/
                   path.getLine == this.lineA && path.getColunm == (this.columA - 1) && path.isWalkable == true ||//esquerda
                   /*path.getLine == (this.lineA + 1) && path.getColunm == (this.columA - 1) && path.isWalkable == true ||*/
                   path.getLine == (this.lineA - 1) && path.getColunm == this.columA && path.isWalkable == true ||//baixo
                   path.getLine == (this.lineA + 1) && path.getColunm == this.columA && path.isWalkable == true ||//cima
                   /*path.getLine == (this.lineA - 1) && path.getColunm == (this.columA + 1) && path.isWalkable == true ||*/
                   path.getLine == this.lineA && path.getColunm == (this.columA + 1) && path.isWalkable == true /*||//direita
                   path.getLine == (this.lineA + 1) && path.getColunm == (this.columA + 1) && path.isWalkable == true*/)
                {
                    Console.WriteLine("O Path[" + path.getLine + "," + path.getColunm + "] foi capturado para testes...");
                    this.gridWalkable.Add(path);
                }
            }

            calcSection();

        }

        //setup do grid
        private void setup()
        {
            for (int l = 0; l < 8; l++)
            {
                for (int C = 0; C < 8; C++)
                {
                    pb = new PathBlock(l, C, this.widthHeight);

                    if (l == 2 && C == 0)
                    { 
                        pb.isPointA = true;
                        pointA = pb;
                    }

                    else if (l == 3 && C == 7)
                    {
                        pb.isPointB = true;
                        pb.isWalkable = true;
                        pointB = pb;
                    }
                    else if (l == 1 && C == 4 || l == 2 && C == 4 || l == 3 && C == 4 || l == 4 && C == 4 || l == 5 && C == 4) pb.isWall = true;
                    else pb.isWalkable = true;

                    pathManager.Add(pb);

                }
            }
        }

        //cálculo do PathFinding
        private void calcSection()
        {
            points = gridWalkable.ToArray();

            for (int i = 0; i < points.Length; i++)
            {
                int line = (pointB.getLine - points[i].getLine);
                line = line < 0 ? -line : line;

                int column = (pointB.getColunm - points[i].getColunm);
                column = column < 0 ? -column : column;

                int H = (line + column) * 10;

                int G = 10;

                points[i].getF = G + H;

                Console.WriteLine("O Path[" + points[i].getLine + "," + points[i].getColunm + "] tem F = " + points[i].getF);
            }

            for (int i = 0; i < points.Length; i++)
            {

                if (i == 0)
                    nextStep = points[i];

                else
                {
                    if (nextStep.isPointB)
                    {
                        break;
                    }

                    if (points[i].getF <= nextStep.getF)
                        nextStep = points[i];
                }
            }

            pointA.isPointA = false;
            pointA.isWalkable = false;
            nextStep.isPointA = true;
            pointA = nextStep;
        }


    }
}

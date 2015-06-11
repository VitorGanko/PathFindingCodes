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
        int widthHeight = 50, gridSize = 10, lineA, columA, timeToMove = 0, steps = 0;

        public Form1()
        {
            InitializeComponent();

            setup();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);


            paint += new PaintEventHandler(draw);

            Timer t = new Timer();
            t.Interval = 1;
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
            this.medidorPassos.Text = "Quantos passos o Player deu: " + steps;

            if (pointA.getLine != pointB.getLine || pointA.getColunm != pointB.getColunm)
            {
                if (timeToMove++ > 80)
                {
                    moveOn();
                    steps++;
                    timeToMove = 0;
                }
            }

            Invalidate();

        }

        //método para clicar e aparecer a parede
        public void gameClickManager(object sender, MouseEventArgs m)
        {
            foreach (PathBlock path in pathManager)
            {
                path.transformInWall(sender, m);
            }
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
                if (path.getLine == this.lineA && path.getColunm == (this.columA - 1) && path.isWalkable == true ||//esquerda
                    path.getLine == (this.lineA - 1) && path.getColunm == this.columA && path.isWalkable == true ||//baixo
                    path.getLine == (this.lineA + 1) && path.getColunm == this.columA && path.isWalkable == true ||//cima
                    path.getLine == this.lineA && path.getColunm == (this.columA + 1) && path.isWalkable == true) //direita
                {
                    Console.WriteLine("O Path[" + path.getLine + "," + path.getColunm + "] foi capturado para testes...");
                    path.getG = 10;
                    this.gridWalkable.Add(path);
                }

                else if (path.getLine == (this.lineA - 1) && path.getColunm == (this.columA - 1) && path.isWalkable == true ||
                         path.getLine == (this.lineA + 1) && path.getColunm == (this.columA - 1) && path.isWalkable == true ||
                         path.getLine == (this.lineA - 1) && path.getColunm == (this.columA + 1) && path.isWalkable == true ||
                         path.getLine == (this.lineA + 1) && path.getColunm == (this.columA + 1) && path.isWalkable == true)
                {
                    Console.WriteLine("O Path[" + path.getLine + "," + path.getColunm + "] foi capturado para testes...");
                    path.getG = 14;
                    this.gridWalkable.Add(path);
                }
            }

            calcSection();

        }

        //setup do grid
        private void setup()
        {
            //resize da janela
            this.Height = ((this.gridSize + 1) * this.widthHeight) + 50;
            this.Width = ((this.gridSize + 1) * this.widthHeight) + (this.label1.Width + 100);

            this.button1.Location = new Point(((this.gridSize + 1) * this.widthHeight) + this.button1.Width / 2,
                150);

            this.label1.Location = new Point(this.button1.Location.X, 50);

            this.tamanhoDoGrid.Location = new Point(this.button1.Location.X, 100);

            this.tamanhoDoGrid.Width = 200;

            this.medidorPassos.Location = new Point(this.button1.Location.X, 250);

            this.label2.Location = new Point(this.button1.Location.X, 350);

            //randomizando o grid(pontoA, pontoB)
            pathManager = new List<PathBlock>();
            
            Random r = new Random();
            int randomLineA, randomLineB, randomColumn;

            randomLineA = r.Next(0, gridSize);
            randomLineB = r.Next(0, gridSize);
            randomColumn = r.Next(0, gridSize);

            //criar grid
            for (int l = 0; l < gridSize; l++)
            {
                for (int C = 0; C < gridSize; C++)
                {
                    pb = new PathBlock(l, C, this.widthHeight);

                    if (l == randomLineA && C == 0)
                    { 
                        pb.isPointA = true;
                        pointA = pb;
                    }

                    else if (l == randomLineB && C == (gridSize - 1))
                    {
                        pb.isPointB = true;
                        pb.isWalkable = true;
                        pointB = pb;
                    }
                    
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

                points[i].getH = (line + column) * 10;

                Console.WriteLine("O Path[" + points[i].getLine + "," + points[i].getColunm + "] tem F = " + points[i].F);
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

                    if (points[i].F <= nextStep.F)
                        nextStep = points[i];
                }
            }

            pointA.isPointA = false;
            pointA.isWalkable = false;
            nextStep.isPointA = true;
            pointA = nextStep;
        }

        //reiniciar PathFinding
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tamanhoDoGrid.Text.Equals("Digite aqui o tamanho do grid"))
            {
                this.gridSize = 10;
                this.steps = 0;
                setup();
            }

            else
            {
                this.gridSize = int.Parse(this.tamanhoDoGrid.Text);
                this.steps = 0;
                setup();
            }
        }
    }
}

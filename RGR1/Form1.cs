using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RGR1
{
    public partial class Form1 : Form
    {


        private double A = -(double)2 / 3;
        private double B = 6;
        private double epsilon = countEpsilon(3);


        public static double countEpsilon(long degree)
        {
            return 1 / Math.Pow(10, degree);
        }

        public double func(double x)
        {
            return x * x * x + 2 * x * x + x - 1;
        }

        public int normalX(double coordX)
        {
            return (int)((coordX) * 70) + 150;
        }

        public int normalY(double coordY)
        {
            return (int)(coordY * -1) + 400;
        }


        public void initComboBox()
        {
            comboBox1.Items.Add("10^-3");
            comboBox1.Items.Add("10^-6");
            comboBox1.Items.Add("10^-9");
            comboBox1.Items.Add("10^-12");

            comboBox1.SelectedIndex = 0;
        }


        public void initCheckBox()
        {
            checkedListBox1.Items.Add("Равномерный поиск");
            checkedListBox1.Items.Add("Алгоритм деления пополам");
            checkedListBox1.Items.Add("Метод Фибоначчи");
            checkedListBox1.Items.Add("Метод золотого сечения");

            checkedListBox1.SetItemChecked(0, true);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    epsilon = countEpsilon(3);
                    break;
                case 1:
                    epsilon = countEpsilon(6);
                    break;
                case 2:
                    epsilon = countEpsilon(9);
                    break;
                case 3:
                    epsilon = countEpsilon(12);
                    break;
            }
        }


        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedIndex = checkedListBox1.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    uniSearch();
                    break;
                case 1:
                    binarySearch();
                    break;
                case 2:
                    Fib();
                    break;
                case 3:
                    goldSearch();
                    break;
            }

            foreach (int checkboxIndex in checkedListBox1.CheckedIndices)
            {
                if (checkboxIndex != selectedIndex)
                {
                    checkedListBox1.SetItemChecked(checkboxIndex, false);
                }
            }
        }


        private void drawGraphic(double xMin, double yMin)
        {
            Bitmap bmp = new Bitmap(graphicView.Width, graphicView.Height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush myCorp = new SolidBrush(Color.Black);

            Point p1 = new Point(normalX(-1), normalY(0));
            Point p2 = new Point(normalX(B + 1), normalY(0));
            Pen pen = new Pen(myCorp);
            pen.Width = 2;
            g.DrawLine(pen, p1, p2);

            p1 = new Point(normalX(0), normalY(0) + 40);
            p2 = new Point(normalX(0), normalY(func(B)));
            g.DrawLine(pen, p1, p2);

            //x axis
            for(int i = -1; i < B + 1; i++)
            {
                p1 = new Point(normalX(i), normalY(-5));
                p2 = new Point(normalX(i), normalY(5));
                g.DrawLine(pen, p1, p2);

                Font font = new Font("Arial", 11, FontStyle.Regular);

                if(i != 0)
                {
                    g.DrawString(i.ToString(), font, myCorp, new PointF(normalX(i) - 6, normalY(-10)));
                } else
                {
                    g.DrawString(i.ToString(), font, myCorp, new PointF(normalX(i) + 10, normalY(-10)));
                }

                
            }


            for (int i = -40; i < 280; i += 40)
            {
                p1 = new Point(-5 + 150, normalY(i));
                p2 = new Point(5 + 150, normalY(i));
                g.DrawLine(pen, p1, p2);

                Font font = new Font("Arial", 11, FontStyle.Regular);

                if(i != 0)
                {
                    g.DrawString(i.ToString(), font, myCorp, new PointF(-40 + 150, normalY(i) - 10));
                }
            }


            //first arrow
            p1 = new Point(normalX(B + 0.5), normalY(-6));
            p2 = new Point(normalX(B + 1), normalY(0));
            g.DrawLine(pen, p1, p2);

            p1 = new Point(normalX(B + 1), normalY(0));
            p2 = new Point(normalX(B + 0.5), normalY(6));
            g.DrawLine(pen, p1, p2);
                
            //second arrow
            p1 = new Point((-6) + 150, normalY(func(B - 0.25)));
            p2 = new Point(150, normalY(func(B)));
            g.DrawLine(pen, p1, p2);

            p1 = new Point(150, normalY(func(B)));
            p2 = new Point((6) + 150, normalY(func(B - 0.25)));
            g.DrawLine(pen, p1, p2);


            double minY = double.MaxValue;
            double x = A;

            myCorp.Color = Color.Coral;

            while (x <= B)
            {

                double y = func(x);

                g.FillEllipse(myCorp, normalX(x), normalY(y), 4, 4);

                x += 0.00001;

                if (y < minY)
                {
                    minY = y;
                }
            }

            myCorp.Color = Color.Chartreuse;

            g.FillEllipse(myCorp, normalX(xMin) - 3, normalY(yMin) - 3, 10, 10);

            graphicView.Image = bmp;
        }


        public Form1()
        {
            InitializeComponent();

            initCheckBox();
            initComboBox();

            uniSearch();
        }


        public void uniSearch()
        {

            double localA = A;
            double localB = B;
            int iters = 1;

            List<double> yValues = new List<double>();

            double L = 0;


            while (true)
            {

                //first 1
                
                double lx = 0;
                double delta = (double)localB - localA;


                lx = Math.Pow(0.1, iters);

                L = delta / lx;


                //step 2
                double x = localA;
                double minY = double.MaxValue;
                double minX = x;

                while (x < localB)
                {
                    double y = func(x);
                    yValues.Add(y);

                    if (y < minY)
                    {
                        minX = x;
                        minY = y;
                    }

                    x += lx;
                }


                //step 3
                //search new LocalA and LocalB;

                if (minX == localA)
                {
                    localA = minX;
                    localB = minX + lx;
                }
                else if (minX == localB)
                {
                    localA = minX - lx;
                    localB = minX;
                }
                else
                {
                    localA = minX - lx;
                    localB = minX + lx;
                }

                iters++;

                if (Math.Abs(localB - localA) <= epsilon)
                {
                    break;
                }
            }

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters - 1));

            itersView.Text = (iters - 1).ToString();
            x1View.Text    = localA.ToString();
            x2View.Text    = localB.ToString();

            y1View.Text = yValues[yValues.Count - 1].ToString();
            y2View.Text = yValues[yValues.Count - 1].ToString();

            drawGraphic(localA, yValues[yValues.Count - 1]);

            double lx1 = Math.Pow(0.1, 1);

            L = (B - A) / lx1;
            Debug.WriteLine(L);
            double predictIters = Math.Log(epsilon / (B - A), 2 / L);
            Debug.WriteLine(predictIters);

            predictItersView.Text = predictIters.ToString();
        }



        public void binarySearch()
        {
            double localA = A;
            double localB = B;
            double iters = 0;

            double y1 = 0;
            double y2 = 0;

            while (true)
            {

                double x0 = (double)(localB + localA) / 2;

                double x1 = (double)(localB + x0) / 2;
                double x2 = (double)(x0 + localA) / 2;

                y1 = func(x1);
                y2 = func(x2);

                if(y1 < y2)
                {
                    localA = x0;
                } else
                {
                    localB = x0;
                }

                iters++;

                if (Math.Abs(localB - localA) <= epsilon)
                {
                    break;
                }
            }

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters));

            itersView.Text = iters.ToString();
            x1View.Text    = localA.ToString();
            x2View.Text    = localB.ToString();

            y1View.Text    = y1.ToString();
            y2View.Text    = y2.ToString();

            drawGraphic(localA, y1);

            double predictIters = Math.Log((B - A) / epsilon, 2);
            Debug.WriteLine(predictIters);

            predictItersView.Text = predictIters.ToString();
        }

        
        private double getFibValue(long n)
        {
            double phi = (Math.Sqrt(5) - 1) / 2;
            return Math.Round((Math.Pow(1 / phi, n + 1) - Math.Pow(-phi, n + 1)) / Math.Sqrt(5));
        }
        
        private long fibN()
        {
            double phi = (Math.Sqrt(5) - 1) / 2;
            return (long) Math.Round(Math.Log((Math.Sqrt(5) * (B - A)) / epsilon, 1 / phi) - 1);
        }

        public void Fib()
        {

            double localA = A;
            double localB = B;

            long n = fibN();
            long iters = 1;

            double y1 = 0;
            double y2 = 0;

            while (iters < n)
            {
                double x1 = localA + ((double) localB - localA) * ((double) (getFibValue(n - iters - 1) / getFibValue(n - iters + 1)));
                double x2 = localA + ((double) localB - localA) * ((double) (getFibValue(n - iters) / getFibValue(n - iters + 1)));

                y1 = func(x1);
                y2 = func(x2);

                if(y1 < y2)
                {
                    localB = x2;
                } else
                {
                    localA = x1;
                }

                iters++;
            }

            double deltaX = (double) ((localB - localA) / 10);

            double xn     = localA + deltaX;
            double funcXn = func(xn);

            if(funcXn > (y2 - y1) / 2)
            {
                localA = xn;
            } else
            {
                localB = xn;
            }

            itersView.Text = (iters - 1).ToString();
            x1View.Text    = localA.ToString();
            x2View.Text    = localB.ToString();

            y1View.Text    = y1.ToString();
            y2View.Text    = y2.ToString();

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters - 1));

            drawGraphic(localA, y1);
        }


        public void goldSearch()
        {
            double localA = A;
            double localB = B;
            double tetta = (double) (Math.Sqrt(5) - 1) / 2;
            double iters = 0;

            double y1 = 0;
            double y2 = 0;

            while (true)
            {
                double xr1 = localB - (localB - localA) * tetta;
                double xr2 = localA + (localB - localA) * tetta;

                y1 = func(xr1);
                y2 = func(xr2);

                if (y1 < y2)
                {
                    //localA = localA;
                    localB = xr2;
                }
                else
                {
                    localA = xr1;
                }

                iters++;

                if (Math.Abs(localB - localA) <= epsilon)
                {
                    break;
                }
            }

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters));

            itersView.Text = iters.ToString();
            x1View.Text    = localA.ToString();
            x2View.Text    = localB.ToString();

            y1View.Text    = y1.ToString();
            y2View.Text    = y2.ToString();

            drawGraphic(localA, y1);

            double predictIters = Math.Log(epsilon / (B - A), tetta);
            predictItersView.Text = predictIters.ToString();
        }
    }
}

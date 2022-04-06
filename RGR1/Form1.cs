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


        private double A = -(double) 2 / 3;
        private double B = 6;
        private double epsilon = 1 / Math.Pow(10, 3);


        public double func(double x)
        {
            return x * x * x + 2 * x * x + x - 1;
        }


        public Form1()
        {
            InitializeComponent();

            uniSearch();
            binarySearch();
            Fibb();
            goldSearch();

            double x = A;

            Bitmap bmp = new Bitmap(graphicView.Width, graphicView.Height);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush myCorp = new SolidBrush(Color.DarkMagenta);

            double minY = double.MaxValue;
            double minX = A;

            while (x <= B)
            {

                double y = func(x);

                g.FillEllipse(myCorp, (int)(x * 70) + 100, (int)(y * -1) + 500, 2, 2);

                x += 0.00001;

                if (y < minY)
                {
                    minY = y;
                    minX = x;
                }
            }

            Debug.WriteLine(minY);
            Debug.WriteLine(minX);

            graphicView.Image = bmp;
        }


        public void uniSearch()
        {

            double localA = A;
            double localB = B;
            int iters = 1;

            while (true)
            {

                List<double> yValues = new List<double>();

                //first 1
                double L = 0;
                double lx = 0;
                double delta = (double)localB - localA;

                //while (delta % lx != 0)
                //{
                //    lx += Math.Pow(0.05, iters);
                //}

                lx = Math.Pow(0.1, iters);

                L = delta % lx;


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

        }



        public void binarySearch()
        {
            double localA = A;
            double localB = B;
            double iters = 0;

            while (true)
            {

                double x0 = (double)(localB + localA) / 2;

                double x01 = (double)(localB + x0) / 2;
                double x02 = (double)(x0 + localA) / 2;

                double y01 = func(x01);
                double y02 = func(x02);

                if(y01 < y02)
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

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters - 1));
        }

        
        private double getFibbValue(long n)
        {
            double phi = (Math.Sqrt(5) - 1) / 2;
            return Math.Round((Math.Pow(1 / phi, n + 1) - Math.Pow(-phi, n + 1)) / Math.Sqrt(5));
        }

        
        private long fibbN()
        {
            double phi = (Math.Sqrt(5) - 1) / 2;
            return (long) Math.Round(Math.Log((Math.Sqrt(5) * (B - A)) / epsilon, 1 / phi) - 1);
        }

        public void Fibb()
        {

            double localA = A;
            double localB = B;

            long n = fibbN();
            long iters = 1;

            while (iters <= n)
            {
                double x1 = localA + ((double) localB - localA) * ((double) (getFibbValue(n - iters - 1) / getFibbValue(n - iters + 1)));
                double x2 = localA + ((double) localB - localA) * ((double) (getFibbValue(n - iters) / getFibbValue(n - iters + 1)));

                double y1 = func(x1);
                double y2 = func(x2);

                if(y1 < y2)
                {
                    localB = x2;
                } else
                {
                    localA = x1;
                }

                iters++;
            }

            double minX = (localA + localB) / 2;

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters - 1) + " minX: " + minX);

        }


        public void goldSearch()
        {
            double localA = A;
            double localB = B;
            double tetta = (double) (Math.Sqrt(5) - 1) / 2;
            double iters = 0;

            while (true)
            {
                double xr1 = localB - (localB - localA) * tetta;
                double xr2 = localA + (localB - localA) * tetta;

                double y1 = func(xr1);
                double y2 = func(xr2);

                if (y1 < y2)
                {
                    //localA = localA;
                    localB = xr2;
                } else
                {
                    localA = xr1;
                }

                iters++;

                if (Math.Abs(localB - localA) <= epsilon)
                {
                    break;
                }
            }

            Debug.WriteLine("END: " + "A:" + localA + " B:" + localB + " iters:" + (iters - 1));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Progonka
{
    class Running
    {
        public static double[] Run(double[] a, double[] b, double[] c, double[] d, double h, int N)
        {
            double[] V = new double[N];
            double[] U = new double[N];
            double[] Y = new double[N];

            V[0] = -b[0] / a[0];
            U[0] = d[0] / a[0];
            for (int i = 1; i < N - 1; i++)
            {
                V[i] = -(b[i] / (c[i] * V[i - 1] + a[i]));
                U[i] = (d[i] - c[i] * U[i - 1]) / (c[i] * V[i - 1] + a[i]);
            }
            Y[0] = d[0];
            Y[N - 1] = d[N - 1];

            for (int i = N - 2; i > 0; i--)
            {
                Y[i] = V[i] * Y[i + 1] + U[i];
            }

            return Y;
        }
    }
}

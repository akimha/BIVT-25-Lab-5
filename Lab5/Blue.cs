using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here

            answer = new double[matrix.GetLength(0)];

            double sr, s = 0;
            int c, x = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sr = 0;
                c = 0;
                s = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        c++;
                    }
                }

                if (c != 0) sr = s / c;
                else sr = 0;

                answer[x++] = sr;
            }

            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return null;

            int r = matrix.GetLength(0), c = matrix.GetLength(1);

            if (r == 1 && c == 1) return new int[0, 0];

            int m = matrix[0, 0], r_ind = 0, c_ind = 0;

            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    if (matrix[i, j] > m)
                    {
                        m = matrix[i, j];
                        r_ind = i;
                        c_ind = j;
                    }

            answer = new int[r - 1, c - 1];
            int x = 0;

            for (int i = 0; i < r; i++)
            {
                if (i == r_ind) continue;
                int y = 0;
                for (int j = 0; j < c; j++)
                {
                    if (j == c_ind) continue;
                    answer[x, y] = matrix[i, j];
                    y++;
                }
                x++;
            }
            
            // end
            
            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max =  int.MinValue, ind = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        ind = j;
                    }

                int temp = matrix[i, ind];

                for (int j = ind; j < matrix.GetLength(1) - 1; j++) matrix[i, j] = matrix[i, j + 1];
                matrix[i, matrix.GetLength(1) - 1] = temp;
            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < m; j++) if (matrix[i, j] > max) max = matrix[i, j]; 

                for (int j = 0; j < m + 1; j++)
                {
                    if (j < m - 1) answer[i, j] = matrix[i, j];
                    else if (j == m - 1) answer[i, j] = max;
                    else answer[i, j] = matrix[i, m - 1];
                }
            }

            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1), c = 0, x = 0;

            for (int i = 0; i < n; i++) for (int j = 0; j < m; j++) if ((i + j) % 2 == 1) c++;

            answer = new int[c];

            for (int i = 0; i < n; i++) for (int j = 0; j < m; j++) if ((i + j) % 2 == 1) answer[x++] = matrix[i, j];

            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return;

            if (n == 0 || m == 0) return;

            int max = int.MinValue, max_ind = -1;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    max_ind = i;
                }
            }

            int otr = -1;

            if (k >= 0 && k < n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, k] < 0)
                    {
                        otr = i;
                        break;
                    }
                }
            }

            if (max_ind != -1 && otr != -1 && max_ind != otr)
            {
                for (int j = 0; j < n; j++) 
                    (matrix[max_ind, j], matrix[otr, j]) = (matrix[otr, j], matrix[max_ind, j]);
            }
            
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int x = array.Length;

            if (m < 2) return;
            if (m != x) return;

            int max = int.MinValue, max_i = 0;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, n - 2] > max)
                {
                    max_i = i;
                    max = matrix[i, n - 2];
                }
            }

            int c = 0;

            for (int i = 0; i < m; i++)
            {
                matrix[max_i, i] = array[c++];
            }

            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0) return;

            for (int j = 0; j < m; j++)
            {
                int max = int.MinValue;
                int max_i = -1;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        max_i = i;
                    }
                }

                bool f = max_i < n / 2;

                if (f)
                {
                    int sum = 0;
                    for (int i = max_i + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }

            // end

            }
        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0) return;
            
            for (int i = 0; i < n - 1; i += 2)
            {
                int max1 = int.MinValue;
                int max_i1 = -1;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max1)
                    {
                        max1 = matrix[i, j];
                        max_i1 = j;
                    }
                }

                int max2 = int.MinValue;
                int max_i2 = -1;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i + 1, j] > max2)
                    {
                        max2 = matrix[i + 1, j];
                        max_i2 = j;
                    }
                }
                matrix[i, max_i1] = max2;
                matrix[i + 1, max_i2] = max1;
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);

            if (n == 0) return;

            if (matrix.GetLength(1) != n) return;

            int max = int.MinValue, max_i = 0;

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    max_i = i;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j > i && i < max_i)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (n == 0 || m == 0) return;

            int[] m2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                m2[i] = c;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (m2[j] < m2[j + 1])
                    {
                        int temp = m2[j];
                        m2[j] = m2[j + 1];
                        m2[j + 1] = temp;

                        for (int k = 0; k < m; k++)
                        {
                            int elem = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = elem;
                        }
                    }
                }
            }

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            double s = 0;
            int c = 0;

            foreach (var row in array)
            {
                foreach (var elem in row)
                {
                    s += elem;
                    c++;
                }
            }

            double ov_avg;
            if (c == 0) ov_avg = 0; 
            else ov_avg = s / c;

            int keep = 0;
            foreach (var row in array)
            {
                double rsum = 0;
                foreach (var elem in row) rsum += elem;

                double r_avg = rsum / row.Length;
                if (r_avg >= ov_avg) keep++;
            }

            answer = new int[keep][];
            int x = 0;

            foreach (var row in array)
            {
                double rs = 0;
                foreach (var elem in row) rs += elem;
                double row_avg = rs / row.Length;
                if (row_avg >= ov_avg)
                {
                    answer[x] = new int[row.Length];
                    for (int i = 0; i < row.Length; i++) answer[x][i] = row[i];
                    x++;
                }
            }

            // end

            return answer;
        }
    }
}
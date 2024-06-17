namespace Backtracking;

class Program
{
    static void Main(string[] args)
    {
        int n = 5,p = 3;
        int[] sol = new int[n];
        bool[] b = new bool[n];
        //ProdusCartezian(0, n, sol);
        //Permutari(0, n, sol, b);
        //Aranjamente(0, n, p, sol, b);

        sol[0] = 0;
        Combinari(1, n, p, sol);

        Console.ReadKey();
    }

    public static void ProdusCartezian(int k, int n, int[] sol) 
    {
        if (k >= n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(sol[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                sol[k] = i + 1;
                ProdusCartezian(k + 1, n, sol);
            }
        }
    }

    public static void Permutari(int k, int n, int[] sol, bool[] b)
    {
        if(k>=n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(sol[i] + " ");
            Console.WriteLine();
        }
        else
        {
            for(int i=0;i<n;i++)
                if (!b[i])
                {
                    b[i] = true;
                    sol[k] = i + 1;
                    Permutari(k + 1, n, sol, b);
                    b[i] = false;
                }
        }
    }

    public static void Aranjamente(int k, int n, int p, int[]sol, bool[] b)
    {
        if(k>=p)
        {
            for (int i = 0; i < p; i++)
                Console.Write(sol[i] + " ");
            Console.WriteLine();
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (!b[i])
                {
                    b[i] = true;
                    sol[k] = i + 1;
                    Aranjamente(k + 1, n, p, sol, b);
                    b[i] = false;
                }
            }
            
        }
    }
    public static void Combinari(int k, int n, int p, int[] sol)
    {
        if(k>p)
        {
            for (int i = 1; i <= p; i++)
                Console.Write(sol[i] + " ");
            Console.WriteLine();
        }
        else
        {
            for (int i = sol[k-1]+1; i <=n; i++)
            {
                sol[k] = i;
                Combinari(k + 1, n, p, sol);
            }
        }
    }

}


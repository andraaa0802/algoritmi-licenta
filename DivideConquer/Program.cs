namespace DivideConquer;

class Program
{
    static Random rnd = new Random();
    static void Main(string[] args)
    {
        /* binary search
        int n = int.Parse(Console.ReadLine());
        int[] v = new int[n];
        v[0] = rnd.Next(10);
        for (int i = 1; i < n; i++)
        {
            v[i] = v[i - 1] + rnd.Next(5);
        }
        int x = int.Parse(Console.ReadLine());
        bool found=binarySearch(v, 0, n-1, x);
        if(found)
            Console.Write(x+" exista in: ");
        else
            Console.Write(x+" nu exista in: ");
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            Console.Write(v[i]+" ");
        }
        Console.ReadKey();
        */

        /*Turnurile Hanoi
        Hanoi(7, 'A', 'B', 'C');
        Console.ReadKey();
        */

        Interclasare();

    }

    static bool binarySearch(int[] v, int st, int dr, int x) //O(log(n) (logaritm in baza 2 din n)
    { 
        if (st <= dr)
        {
            int m = (st + dr) / 2; //mijlocul
            if (v[m] == x)
                return true;
            else if (x < v[m])
                return binarySearch(v, st, m - 1, x);
            else
                return binarySearch(v, m + 1, dr, x);
        }
        else return false;
    }

    static void Hanoi(int n, char A, char B, char C) //3 tije //O((2^n)-1) 
    {
        /*
         * 1. se poate muta un singur disc o data
         * 2. nu se poate pune un disc de diam. mai mare pe unul de diam mai mic
         * 3. numar minim de mutari
         */
        if (n==1)
            Console.WriteLine(A + "->" + C );
        else
        {
            Hanoi(n - 1, A, C, B);
            Hanoi(1, A ,B ,C);
            Hanoi(n-1, B, A, C);
        }
    }

    static void Interclasare() //O(n1+n2) //pentru concatenare + sortare: O(n2+(n1+n2)log(n1+n2)) 
    {
        /*Interclasarea a 2 vectori: 
         * pentru v1: 8
                      1 1 3 10 30 31 35
               si v2: 5
                      1 18 40 42 60
             rezulta: 1 1 1 3 10 18 30 31 35 40 42 60
         */

        /*
         * Se presupun 2 vectori sortati (v1, n1) si (v2, n2)
         * Se cere obtinerea vectorului (v3, n1+n2) cu elemente din v1 si v2, sortat
         */

        int k1 = 0, k2 = 0, k3 = 0;

        TextReader load1 = new StreamReader(@"../v1.txt");
        int n1 = int.Parse(load1.ReadLine());
        int[] v1 = new int[n1];
        string[] data1 = load1.ReadLine().Split(' ');
        for (int i = 0; i < n1; i++)
            v1[i] = int.Parse(data1[i]);

        TextReader load2 = new StreamReader(@"../v2.txt");
        int n2 = int.Parse(load2.ReadLine());
        int[] v2 = new int[n2];
        string[] data2 = load2.ReadLine().Split(' ');
        for (int i = 0; i < n2; i++)
            v2[i] = int.Parse(data2[i]);

        int[] v3 = new int[n1 + n2];

        while (k1<n1 && k2 < n2)
        {
            if (v1[k1] <= v2[k2])
            {
                v3[k3] = v1[k1];
                k1++;
                k3++;
            }
            else
            {
                v3[k3] = v2[k2];
                k2++;
                k3++;
            }
        }
        while (k1 < n1)
        {
            v3[k3] = v1[k1];
            k1++;
            k3++;
        }
        while (k2 < n2)
        {
            v3[k3] = v2[k2];
            k2++;
            k3++;
        }

        for(int i=0;i<n1+n2;i++)
            Console.Write(v3[i]+" ");
        Console.ReadKey();
    }
}


namespace ClasaMatrice;

class Program
{
    static void Main(string[] args)
    {
        Matrice A = new Matrice(@"/Users/andra/Desktop/AlgoritmicaLicenta/ClasaMatrice/TextFile1.txt");
        Matrice B = new Matrice(A);
        Matrice C = A + B;
        Matrice D = A * B;

        foreach (string s in A.View())
            Console.WriteLine(s);

        Console.WriteLine();

        foreach (string s in C.View())
            Console.WriteLine(s);

        Console.WriteLine();

        if(D!=Matrice.Empty)
            foreach (string s in D.View())
                Console.WriteLine(s);

        Console.ReadKey();
    }
}


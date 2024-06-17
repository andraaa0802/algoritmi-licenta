using System;
namespace ClasaMatrice
{
	public class Matrice
	{
		public static Matrice Empty;

		double[,] values;

		public int lines { get { return values.GetLength(0); } }
        public int columns { get { return values.GetLength(1); } }


        public Matrice(){ }

		public Matrice(int lin, int col)
		{
			values = new double[lin, col];
		}

		public Matrice(double[,] values)
		{
			this.values = values;
		}

		public Matrice(string fileName)
		{
			TextReader reader = new StreamReader(fileName);
			List<String> data = new List<string>();
			string buffer;

			while ((buffer = reader.ReadLine()) != null)
				data.Add(buffer);

			reader.Close();

			values = new double[data.Count, data[0].Split(' ').Length];
			for(int i=0;i<values.GetLength(0);i++)
			{
				string[] tmp = data[i].Split(' ');
				for (int j = 0; j < values.GetLength(1); j++)
					values[i, j] = double.Parse(tmp[j]);
			}
		}

		public Matrice (Matrice toCopy)
		{
			this.values = new double[toCopy.values.GetLength(0), toCopy.values.GetLength(1)];
			for (int i = 0; i < values.GetLength(0); i++)
				for (int j = 0; j < values.GetLength(1); j++)
					this.values[i, j] = toCopy.values[i, j];
		}

		public List<string> View()
		{
            List<String> toReturn = new List<string>();

			for(int i=0;i<values.GetLength(0);i++)
			{
				string buffer = "";
				for (int j = 0; j < values.GetLength(1); j++)
					buffer += values[i, j].ToString() + " ";
					toReturn.Add(buffer);
			}
			
            return toReturn;
        }

        public static Matrice operator + (Matrice a, Matrice b)
		{
			if (a.lines != b.lines || a.columns != b.columns)
				return Matrice.Empty;
			else
			{
				Matrice toReturn = new Matrice(a.lines, a.columns);
				for (int i = 0; i < a.lines; i++)
					for (int j = 0; j < a.columns; j++)
						toReturn.values[i, j] = a.values[i, j] + b.values[i, j];

				return toReturn;
			}
		}

		public static Matrice operator * (Matrice a, Matrice b)
		{
			if (a.columns != b.lines)
				return Matrice.Empty;
			else
			{
				Matrice toReturn = new Matrice(a.lines, b.columns);
				for (int i=0;i<a.lines;i++)
					for(int j=0;j<b.columns;j++)
					{
						toReturn.values[i, j] = 0;
						for (int k = 0; k < a.columns; k++)
							toReturn.values[i, j] += a.values[i, k] * b.values[k, j];
					}
				return toReturn;
			}
		}

	}
}


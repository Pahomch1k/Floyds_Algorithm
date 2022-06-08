using System;
using static System.Console;
using static System.Convert;


namespace Floyds_Algorithm
{
    class Program
    { 
		static void Main(string[] args)
        {
			int x = 10000; 
			Write("Введите кол-во вершин графа - ");
            int count = ToInt32(ReadLine()); 
            int[,] _matrix = new int[count, count]; 

            WriteLine("Введите матрицу смежности графа:");
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Write($"Элемент {i} {j} - ");
					_matrix[i,j] = ToInt32(ReadLine());
                }
            } 
            minFL(_matrix, count, x); 
		}

        public static void minFL(int[,] _matrix, int count, int x)
        {
			int step = 1;
			for (int k = 0; k < count; ++k)
			{
				for (int i = 0; i < count; ++i) 
					for (int j = 0; j < count; ++j) 
						if (_matrix[i,k] < x && _matrix[k,j] < x) 
							if (_matrix[i,k] + _matrix[k,j] < _matrix[i,j])
								_matrix[i,j] = _matrix[i,k] + _matrix[k,j];    

				WriteLine($"Шаг {step}"); 

				for (int i = 0; i < count; i++)
				{
					for (int j = 0; j < count; j++) 
						Write($"{_matrix[i,j]}  ");  
					WriteLine();
				}
				step++;
			}

			WriteLine("Минимальные пути между вершинами:");

			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < count; j++) 
					Write($"{_matrix[i, j]}  "); 
				WriteLine();
			}
		}
    }
}

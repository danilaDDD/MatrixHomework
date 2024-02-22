/*
Задайте двумерный массив
из целых чисел. Напишите программу, которая удалит
строку и столбец, на пересечении которых расположен
наименьший элемент массива. Под удалением
понимается создание нового двумерного массива без
строки и столбца
*/

void Main()
{
   int rows = 3;
   int columns = 3;
   int[,] matrix = GenerateMatrix(rows, columns);
   PrintMatrix(matrix);
   int minRow, minColumn;
   FindMinPosition(matrix, out minRow, out minColumn);
   System.Console.WriteLine("min row" + minRow + "min column" + minColumn);
   int[,] resultMatrix = DeleteMinRowAndColumn(matrix, minRow, minColumn);
   System.Console.WriteLine("output matrix");
   PrintMatrix(resultMatrix); 
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int[,] DeleteMinRowAndColumn(int[,] matrix, int minRow, int minColumn)
{
  int rows = matrix.GetLength(0);
  int columns = matrix.GetLength(1);
  int[,] newMatrix = new int[rows - 1, columns - 1];

   for (int i = 0; i < rows ; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if(i != minRow && j != minColumn)
            {
                int newRowIndex = GetShiftedIndex(i, minRow);
                int newColumnIndex = GetShiftedIndex(j, minColumn);
                newMatrix[newRowIndex, newColumnIndex] = matrix[i, j];

            }
        }
    }

    return newMatrix;
}

int GetShiftedIndex(int index, int excludedIndex)
{
    if(index < excludedIndex)
        return index;
    else
        return index - 1;
}

void FindMinPosition(int[,] matrix, out int minRow, out int minColumn)
{   
    minRow = 0;
    minColumn = 0;
    int min = matrix[0, 0];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i, j] < min)
            {
                min = matrix[i, j];
                minRow = i;
                minColumn = j;
            }
        }
    }
}

int[,] GenerateMatrix(int rows, int columns)
{
    int[,] newMatrix = new int[rows, columns];
    Random rand = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            newMatrix[i, j] = rand.Next(0, 11);
        }
    }

    return newMatrix;
}

Main();
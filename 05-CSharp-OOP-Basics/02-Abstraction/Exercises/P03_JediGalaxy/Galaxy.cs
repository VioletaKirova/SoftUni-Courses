namespace P03_JediGalaxy
{
    public class Galaxy
    {
        private int[,] matrix;

        public Galaxy(int rows, int cols)
        {
            this.Matrix = new int[rows, cols];
        }

        public int[,] Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public void SetGalaxyStarValue()
        {
            int value = 0;

            for (int i = 0; i < this.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.Matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        public bool IsInside(int row, int col)
        {
            return row >= 0 &&
                row < this.Matrix.GetLength(0) &&
                col >= 0 &&
                col < this.Matrix.GetLength(1);
        }
    }
}

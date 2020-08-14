
namespace Conway.Core
{
    public class ConwayPerformance
    {
        public ConwayPerformance(int maxRows, int maxColumns)
        {
            _temporaryGrid = new bool[maxRows, maxColumns];
        }

        public void NextState(bool[,] state)
        {
            for (var i = 0; i < state.GetLength(0); i++)
            for (var j = 0; j < state.GetLength(1); j++)
            {
                _temporaryGrid[i, j] = NextAlive(state, i, j);
            }

            for (var i = 0; i < state.GetLength(0); i++)
            for (var j = 0; j < state.GetLength(1); j++)
            {
                state[i, j] = _temporaryGrid[i, j];
            }
        }

        private static bool NextAlive(bool[,] state, int x, int y)
        {
            var isAlive = state[x, y];

            var neighbours = CountNeighbours(state, x, y);

            return (isAlive && (neighbours == 2 || neighbours == 3))
                || (!isAlive && neighbours == 3);
        }

        private static int CountNeighbours(bool[,] state, int row, int column)
        {
            var count = 0;

            for (var i = -1; i < 2; i++)
            for (var j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;

                if (IsAlive(state, row - i, column - j)) count++;
            }

            return count;
        }

        private static bool IsAlive(bool[,] state, int x, int y)
        {
            return InBounds(state, x, y) && state[x, y];
        }

        private static bool InBounds(bool[,] state, int x, int y)
        {
            return x >= 0
                && x < state.GetLength(0)
                && y >= 0 && y < state.GetLength(1);
        }

        private readonly bool[,] _temporaryGrid;
    }
}
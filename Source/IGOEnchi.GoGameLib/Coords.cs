namespace IGOEnchi.GoGameLogic {
    public class Coords : ICoords
    {
        
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
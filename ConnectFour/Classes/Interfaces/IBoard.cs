namespace ConnectFour.Classes.Interfaces
{
    public interface IBoard
    {
        char[,] PlayField { get; set; }

        void PrintOutBoard(bool withLegend);
        void AddDiscToTheBoard(int column, bool IsComputer);
    }
}
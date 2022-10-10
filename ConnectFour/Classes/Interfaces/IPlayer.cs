using ConnectFour.Classes;

namespace ConnectFour.Classes.Interfaces
{
    public interface IPlayer
    {
        bool IsComputer { get; set; }
        void PlayerTurn(ref Board board);
    }
}
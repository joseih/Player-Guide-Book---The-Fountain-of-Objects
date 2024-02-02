public class Player
{
    public int row;
    public int col;
    private int _maxpos;

    public Player()
    {
        row = 0;
        col = 0;
    }

    public void Move(int maxpos)
    {
        _maxpos = maxpos;
        Console.WriteLine("Where do you want to move?");
        string input = Console.ReadLine();
        switch (input)
        {
            case "north":
                if (CanMove(row, maxpos, 1))
                {
                    row++;

                }
                else
                {
                    Console.WriteLine("Invalid Move");
                }
                break;

            case "south":
                if (CanMove(row, maxpos, -1))
                {
                    row--;
                }
                else
                {
                    Console.WriteLine("Invalid Move");
                }
                break;

            case "east":
                if (CanMove(col, maxpos, 1))
                {
                    col++;

                }
                else
                {
                    Console.WriteLine("Invalid Move");
                }
                break;

            case "west":
                if (CanMove(col, maxpos, -1))
                {
                    col--;
                }
                else
                {
                    Console.WriteLine("Invalid Move");
                }
                break;
        }
    }
    public void DoSomethingInRoom(IRoom room)
    {
        room.Action();
    }


    public void Sense(IRoom[,] room)
    {
        Console.WriteLine($"You are in room {row}, {col}");
        Console.WriteLine("You see: ");
        room[row, col].TellInfo();
        Console.WriteLine("You sense...");
        if (CanMove(row, _maxpos, -1))
        {
            room[row - 1, col].GetSensed();
        }
        if (CanMove(row, _maxpos, 1))
        {
            room[row + 1, col].GetSensed();
        }
        if (CanMove(col, _maxpos, -1))
        {
            room[row, col - 1].GetSensed();
        }
        if (CanMove(col, _maxpos, 1))
        {
            room[row, col + 1].GetSensed();
        }


    }


    private bool CanMove(int currentpos, int maxrow, int move)
    {
        int futurepos = currentpos + (move);
        if (futurepos > maxrow || futurepos < 0)
        {
            return false;
        }
        return true;
    }

}

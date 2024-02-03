using TheFountainObjects.abstract_classes;

public class World
{
    private IRoom[,] _rooms;
    private Player _player;
    private byte _wordlimit;
    private byte _pedestalcount = 0;
    private static readonly Random random = new Random();  // Mova a instância para fora do método


    public World(string size)
    {

        switch (size)
        {
            case "small":
                _wordlimit = 4;
                _rooms = new IRoom[5, 5];
                CreateRooms();
                break;
            case "medium":
                _wordlimit = 6;
                _rooms = new IRoom[7, 7];
                CreateRooms();
                break;
            case "large":
                _wordlimit = 8;
                _rooms = new IRoom[9, 9];
                CreateRooms();
                break;
        }
        _player = new Player();
    }

    public void CreateRooms()
    {
        int count = 0;
        while(count < _rooms.Length)
        {
            int row = random.Next(_wordlimit+1);
            int col = random.Next(_wordlimit+1);
            if (_rooms[row, col] == null)
            {
                count++;
                _rooms[row, col] = new GenericRoom();
            }
        }

    }
    public void Test()
    {
        int nullcounter = 0;
        int roomcounter = 0;
        for (int i = 0; i < _wordlimit; i++)
        {
            for (int j = 0; j < _wordlimit; j++)
            {
                if (_rooms[i, j] == null)
                {
                    nullcounter++;
                    continue;
                }
                roomcounter++;
                _rooms[i, j].TellInfo();
            }
        }
        Console.WriteLine(nullcounter);
        Console.WriteLine(roomcounter);
    }

    public void Play()
    {
        while (true)
        {
            _player.Move(_wordlimit);
            _player.Sense(_rooms);
        }
    }
}

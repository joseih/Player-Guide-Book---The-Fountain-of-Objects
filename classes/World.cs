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
                _rooms = new IRoom[2 + 1, 2 + 1];
                _wordlimit = 2;
                CreateRooms();
                break;
            case "medium":
                _rooms = new IRoom[6 + 1, 6 + 1];
                _wordlimit = 6;
                CreateRooms();
                break;
            case "large":
                _rooms = new IRoom[8, 8];
                _wordlimit = 8;
                CreateRooms();
                break;
        }
        _player = new Player();
    }

    public void CreateRooms()
    {

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

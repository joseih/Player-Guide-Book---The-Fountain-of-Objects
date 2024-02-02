public abstract class Room : IRoom
{
    public int row;
    public int col;

    public void Action()
    {
    }

    public virtual void GetSensed()
    {
    }

    public virtual void TellInfo()
    {

    }
}

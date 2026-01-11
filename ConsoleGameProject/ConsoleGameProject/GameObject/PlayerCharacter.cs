
using System.Data;

public class PlayerCharacter : GameObject
{
    public Tile[,] Circuit { get; set; }

    public PlayerCharacter()
    {
        Init();
    }

    public void Init()
    {
        Symbol = 'I';
    }
    public void Update()
    {
        if (InputManager.GetKey(ConsoleKey.LeftArrow))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow))
        {
            Move(Vector.Right);
        }
    }
    private void Move(Vector direction)
    {
        if (Circuit == null) return;

        Vector current = Position;
        Vector nextPos = Position + direction;

        // 1. 맵 바깥은 아닌지?
        // 2. 벽인지?

        GameObject nextTileObject = Circuit[nextPos.Y, nextPos.X].OnTileObject;

        Circuit[Position.Y, Position.X].OnTileObject = null;
        Circuit[nextPos.Y, nextPos.X].OnTileObject = this;
        Position = nextPos;
    }
}



using System.Data;
using System.Diagnostics;

public class PlayerCharacter : GameObject
{
    public Tile[,] Circuit { get; set; }
    public bool IsActiveControl { get; set; }


    public PlayerCharacter()
    {
        Init();
    }

    public void Init()
    {
        Symbol = 'I';
        IsActiveControl = true;
    }

    public void Crushed(GameObject gameObject) // 벽, 장애물에 닿으면 게임 오버씬으로 
    {
        SceneManager.Change("GameOver");
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

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            IsActiveControl = !IsActiveControl;
        }

        if (InputManager.GetKey(ConsoleKey.Q))
        {
            SceneManager.Change("Title");
        }
    }

    private void Move(Vector direction)
    {
        if (Circuit == null || !IsActiveControl) return;

        Vector current = Position;
        Vector nextPos = Position + direction;

        GameObject nextTileObject = Circuit[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable).Interact(this);
            }
        }
        else
        {
            Circuit[Position.Y, Position.X].OnTileObject = null;
            Circuit[nextPos.Y, nextPos.X].OnTileObject = this;
            Position = nextPos;
        }
    }
}



public class CreditScene : Scene
{
    public override void Enter()
    {
        Console.Clear();
    }

    public override void Exit()
    {
        Console.Clear();
    }

    public override void Render()
    {
        PrintCreator();
    }

    public override void Update()
    {
        if(InputManager.GetKey(ConsoleKey.Enter))
        {
            SceneManager.Change("Title");
        }
    }

    public void PrintCreator()
    {
        Console.SetCursorPosition(3, 0);
        "Enter : 타이틀로".Print();

        Console.SetCursorPosition(3, 3);
        "제작자 : 연동준".Print(ConsoleColor.Green);

        Console.SetCursorPosition(3, 5);
        "도움 주신 분들".Print(ConsoleColor.Yellow);

        Console.SetCursorPosition(3, 8);
        "김재성 강사님".Print(ConsoleColor.Green);
        Console.SetCursorPosition(3, 7);
        "최영민 강사님".Print(ConsoleColor.Green);
    }
}


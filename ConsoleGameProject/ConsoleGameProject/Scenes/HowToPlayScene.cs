
public class HowToPlayScene : Scene
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
        PrintHoToPlay();
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            SceneManager.Change("Title");
        }
    }

    public void PrintHoToPlay()
    {
        Console.SetCursorPosition(3, 0);
        "Enter : 타이틀로".Print();

        Console.SetCursorPosition(3, 3);
        "장애물을 피하는 간단한 게임입니다.".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(3, 4);
        "점수가 늘어날수록 장애물의 개수가 늘어나거나,".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(3, 5);
        "장애물의 간격이 좁아집니다.".Print(ConsoleColor.Yellow);
        Console.SetCursorPosition(3, 6);
        "벽에 닿지 않고, 장애물들을 피하며 높은 점수를 획득해보세요!".Print(ConsoleColor.Yellow);

        Console.SetCursorPosition(3, 8);
        "조작 방법".Print(ConsoleColor.Green);

        Console.SetCursorPosition(3, 9);
        "왼쪽 방향키 : 왼쪽으로 이동 / 오른쪽 방향키 : 오른쪽으로 이동".Print(ConsoleColor.Green);
        Console.SetCursorPosition(3, 10);
        "Enter : Pause / Q : 게임 나가기".Print(ConsoleColor.Green);
    }
}


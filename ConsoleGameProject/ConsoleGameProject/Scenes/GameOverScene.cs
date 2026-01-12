

public class GameOverScene : Scene
{
    private MenuList _GameOverMenu;
    public GameOverScene()
    {
        Init();
    }

    public void Init()
    {
        _GameOverMenu = new MenuList();
        _GameOverMenu.Add("다시 시작", PlayAgain);
        _GameOverMenu.Add("타이틀로", GotoTitle);
    }
    public override void Enter()
    {
        _GameOverMenu.Reset();
    }

    public override void Exit()
    {

    }

    public override void Render()
    {
        Console.SetCursorPosition(5, 1);
        "Game Over".Print(ConsoleColor.DarkRed);

        _GameOverMenu.Render(5, 5);
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _GameOverMenu.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _GameOverMenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _GameOverMenu.Select();
        }
    }

    private void GotoTitle()
    {
        SceneManager.Change("Title");
    }

    private void PlayAgain()
    {
        SceneManager.Change("Circuit");
    }
}


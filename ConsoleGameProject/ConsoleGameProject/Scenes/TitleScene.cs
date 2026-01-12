
using System.Diagnostics;

public class TitleScene : Scene
{
    private MenuList _titleMenu;

    public TitleScene()
    {
        Init();
    }

    public void Init()
    {
        _titleMenu = new MenuList();
        _titleMenu.Add("게임 시작", GameStart);
        _titleMenu.Add("크레딧", ViewCredits);
        _titleMenu.Add("조작방법", ViewHowToPlay);
        _titleMenu.Add("게임 종료", GameQuit);
    }

    public override void Enter()
    {
        Console.Clear();
        _titleMenu.Reset();
    }

    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _titleMenu.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _titleMenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _titleMenu.Select();
        }
    }

    public override void Render()
    {
        Console.SetCursorPosition(5, 1);
        GameManager.GameName.Print(ConsoleColor.Yellow);

        _titleMenu.Render(5, 5);
    }

    public override void Exit()
    {
        Console.Clear();
    }

    public void GameQuit()
    {
        GameManager.IsGameOver = true;
    }

    public void GameStart()
    {
        SceneManager.Change("Circuit");
    }

    public void ViewCredits()
    {
        SceneManager.Change("Credit");
    }

    private void ViewHowToPlay()
    {
        SceneManager.Change("HowToPlay");
    }
}


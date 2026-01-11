
using System.Diagnostics;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "장애물 레이싱";
    private PlayerCharacter _player;

    public GameManager()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        _player = new PlayerCharacter();

        SceneManager.AddScene("Title", new TitleScene());
        SceneManager.AddScene("Circuit", new CircuitScene(_player));
        
        SceneManager.Change("Title");
    }

    public void init()
    {

    }
    public void Run()
    {
        while(!IsGameOver)
        {
            Console.Clear();

            SceneManager.Render();

            InputManager.GetUserInput();

            SceneManager.Update();
        }
    }

    public void Enter()
    {

    }

    public void Update()
    {

    }
    public void Render()
    {

    }

    public void Exit()
    {

    }

}


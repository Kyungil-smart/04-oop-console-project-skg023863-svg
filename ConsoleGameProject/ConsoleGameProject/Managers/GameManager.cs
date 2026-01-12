
using System.Diagnostics;

public class GameManager
{
    public static bool IsGameOver { get; set; }
    public const string GameName = "장애물 레이싱";
    private PlayerCharacter _player;
    public static int Score = 0;

    public GameManager()
    {
        IsGameOver = false;
        SceneManager.OnChangeScene += InputManager.ResetKey;
        _player = new PlayerCharacter();

        SceneManager.AddScene("Title", new TitleScene());
        SceneManager.AddScene("Circuit", new CircuitScene(_player));
        SceneManager.AddScene("GameOver", new GameOverScene());
        
        SceneManager.Change("Title");
    }
    public void Run()
    {
        while(!IsGameOver)
        {
            Console.Clear();

            SceneManager.Render();

            InputManager.GetUserInput();

            SceneManager.Update();

            Thread.Sleep(100);
        }
    }
}


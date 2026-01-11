
public class CircuitScene : Scene
{
    private Tile[,] _circuit = new Tile[20, 7];
    private PlayerCharacter _player;
    private Wall _wall;

    public CircuitScene(PlayerCharacter player)
    {
        Init(player);
    }

    public void Init(PlayerCharacter player)
    {
        _player = player;
        _wall = new Wall();

        for (int y = 0; y < _circuit.GetLength(0); y++)
        {
            for (int x = 0; x < _circuit.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _circuit[y, x] = new Tile(pos);
                if(x == 0 || x == _circuit.GetLength(1) - 1)
                {
                    _circuit[y, x].OnTileObject = _wall;
                }
            }
        }
    }

    public override void Enter()
    {
        _player.Circuit = _circuit;
        _player.Position = new Vector(3, 17);
        _circuit[_player.Position.Y, _player.Position.X].OnTileObject = _player;
    }

    public override void Exit()
    {
        _circuit[_player.Position.Y, _player.Position.X].OnTileObject = null;
        _player.Circuit = null;
    }

    public override void Render()
    {
        PrintCircuit();
    }

    public override void Update()
    {
        _player.Update();
    }

    private void PrintCircuit()
    {
        for (int y = 0; y < _circuit.GetLength(0); y++)
        {
            for (int x = 0; x < _circuit.GetLength(1); x++)
            {
                _circuit[y, x].Print();
            }
            Console.WriteLine();
        }
    }
}


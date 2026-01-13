
using System;

public class CircuitScene : Scene
{
    private Tile[,] _circuit = new Tile[20, 8];

    private PlayerCharacter _player; // 플레이어

    private Wall _wall; // 벽

    private Obstacle _obstacle; // 장애물
    private Random _random = new Random();
    private int cyclePoint = 8; // 장애물의 등장 주기 지정
    private int Cycle = 0; // Update 메서드에서 1씩 증가 CyclePoint와 같아지면 장애물 등장

    private int scoreUpCyclePoint = 10; // 게임 점수가 올라가는 주기 지정
    private int scoreUpCycle = 0; // PrintScore 메서드에서 1씩 증가 ScoreUpCyclePoint와 같아지면 점수 오름

    private int obstacleSetting = 1; // 장애물 등장 확률 조절
    public CircuitScene(PlayerCharacter player)
    {
        Init(player);
    }

    public void Init(PlayerCharacter player)
    {
        _player = player;
        _wall = new Wall();
        _obstacle = new Obstacle();

        for (int y = 0; y < _circuit.GetLength(0); y++)
        {
            for (int x = 0; x < _circuit.GetLength(1) - 1; x++)
            {
                Vector pos = new Vector(x, y);
                _circuit[y, x] = new Tile(pos);
                if (x == 0 || x == _circuit.GetLength(1) - 2) // 왼쪽, 오른쪽 가장자리에 벽 생성
                {
                    _circuit[y, x].OnTileObject = _wall;
                }
            }
        }
    }

    public override void Enter()
    {
        Console.Clear();
        _player.Circuit = _circuit;
        _player.Position = new Vector(3, 17);
        _circuit[_player.Position.Y, _player.Position.X].OnTileObject = _player;
        GameManager.Score = 0;
    }

    public override void Exit()
    {
        Console.Clear();
        _circuit[_player.Position.Y, _player.Position.X].OnTileObject = null;
        _player.Circuit = null;
        Reset();
    }

    public override void Render()
    {
        PrintCircuit();
    }

    public override void Update()
    {
        DifficultySetting();

        PrintScore();

        _player.Update();

        Cycle++;

        if (Cycle == cyclePoint)
        {
            MakeObstacle();
            Cycle = 0;
        }

        MoveObstaclesDown();
    }

    private void PrintCircuit()
    {
        if (_player.IsActiveControl)
        {
            for (int y = 0; y < _circuit.GetLength(0); y++)
            {
                for (int x = 0; x < _circuit.GetLength(1) - 1; x++)
                {
                    _circuit[y, x].Print();
                }
                Console.WriteLine();
            }
        }
    }
    private void MakeObstacle() //장애물이 서킷의 맨 위에서 랜덤으로 생성됨
    {
        if (_player.IsActiveControl)
        {
            int obstacleCount = 0;

            while (obstacleCount != obstacleSetting) // 장애물 개수 설정
            {
                int x = _random.Next(1, _circuit.GetLength(1) - 2);
                int y = 0;

                if (_circuit[y, x].OnTileObject == null) //만약 생성하려는 곳에 장애물이 있으면 null
                {
                    _circuit[y, x].OnTileObject = _obstacle;
                    obstacleCount++;
                }
            }
        }
    }
    private void MoveObstaclesDown() //장애물이 아래로 내려가도록 하는 메서드
    {
        if (_player.IsActiveControl)
        {
            for (int y = _circuit.GetLength(0) - 2; y >= 0; y--)
            {
                for (int x = 1; x < _circuit.GetLength(1) - 2; x++)
                {
                    if (_circuit[y, x].OnTileObject == _obstacle)
                    {
                        GameObject underObject = _circuit[y + 1, x].OnTileObject;

                        if (underObject == _player) //장애물 아래에 플레이어가 있을 경우 게임 오버 씬으로 이동
                        {
                            _player.Crushed(_obstacle);
                        }
                        else if (underObject == null) // 아래가 비어있으면 이동
                        {
                            if (y + 1 == _circuit.GetLength(0) - 1)  // 바닥에 닿았으면 제거
                            {
                                _circuit[y, x].OnTileObject = null;
                            }
                            else
                            {
                                _circuit[y + 1, x].OnTileObject = _obstacle; // 바닥이 아니라면 이동
                                _circuit[y, x].OnTileObject = null;
                            }
                        }
                    }
                }
            }
        }
    }
    private void Reset() // 재시작 시 장애물, 여러 Cycle 변수 초기화
    {
        for (int y = 0; y < _circuit.GetLength(0); y++)
        {
            for (int x = 0; x < _circuit.GetLength(1) - 1; x++)
            {
                if (_circuit[y, x].OnTileObject == _obstacle)
                {
                    _circuit[y, x].OnTileObject = null;
                }
            }
        }
        cyclePoint = 8;
        scoreUpCyclePoint = 10;
        obstacleSetting = 1;
        _player.IsActiveControl = true;
    }

    private void PrintScore() // 점수 출력하는 메서드
    {
        if (_player.IsActiveControl)
        {
            Console.SetCursorPosition(8, 0);
            scoreUpCycle++;

            if (GameManager.Score >= 10000) // 10000점이 MAX 점수
            {
                Console.Write("Score:MAX");
            }
            else
            {
                Console.Write($"Score:{GameManager.Score}");
                if (scoreUpCycle == scoreUpCyclePoint)
                {
                    GameManager.Score++;
                    scoreUpCycle = 0;
                }
            }
        }
    }

    private void DifficultySetting()
    {
        if (GameManager.Score >= 100)
        {
            cyclePoint = 5;
        }
        else if (GameManager.Score >= 80)
        {
            obstacleSetting = 4;
        }
        else if (GameManager.Score >= 60)
        {
            cyclePoint = 6;
        }
        else if (GameManager.Score >= 40)
        {
            cyclePoint = 7;
            obstacleSetting = 3;
        }
        else if (GameManager.Score >= 20)
        {
            obstacleSetting = 2;
        }
    }
}


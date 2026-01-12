public class Obstacle : GameObject, IInteractable
{
    public Obstacle()
    {
        Init();
    }

    public void Init()
    {
        Symbol = '*';
    }
    public void Interact(PlayerCharacter player)
    {
        player.Crushed(this);
    }
}


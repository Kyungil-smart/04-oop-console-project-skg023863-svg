
public class Wall : GameObject, IInteractable
{
    public Wall()
    {
        Init();
    }

    public void Init()
    {
        Symbol = '|';
    }

    public void Interact(PlayerCharacter player)
    {

    }
}



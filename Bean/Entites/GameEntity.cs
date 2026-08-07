using Bean.Managers;

namespace Bean.Entites;

public abstract class GameEntity
{
    public Vector2 Position { get; set; }
    public short Width{ get; }
    public short Height { get; }
    public Bitmap Sprite { get; protected set; }
    public Vector2 Scale { get; }

    protected GameEntity(
        Vector2 position,
        short width,
        short height,
        Bitmap sprite,
        Vector2? scale = null)
    {
        Position = position;
        Width = width;
        Height = height;    
        Sprite = sprite;    
        Scale = scale ?? new Vector2(1, 1); // ?? = scale.hasvalue ? (se sim usa, se nao usao valor dos parenteses)
        GameScene.AddGameEntityToScene(this);
    }

    public virtual void Update()
    {

    }
    

    
    public virtual void Render(Graphics graphics)
    {
        if (Sprite == null)
            return;

        graphics.DrawImage(Sprite, Position.X, Position.Y, Width * Scale.X, Height * Scale.Y);


    }
    

    
}


namespace Bean.Entites;

public class Map : GameEntity
{
    public Map(ushort level, Vector2 position, short width, short height, Vector2? scale = null)
        : base(position, width, height, null, scale)
    {
        Sprite = (Bitmap)GameResources.ResourceManager.GetObject($"sMap_{level}");
    }

}

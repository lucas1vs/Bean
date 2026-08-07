using Bean.Entites;

namespace Bean.Utils;

public  class SpriteSheet
{
    private readonly Bitmap _spriteSheet;   
    public SpriteSheet(Bitmap spriteSheet)
    {
        _spriteSheet = spriteSheet;
    }

    public Bitmap GetSprite(Vector2 position, short widht, short height)
    {
        var cropArea = new Rectangle((int)position.X, (int)position.Y, widht, height); 
        return _spriteSheet.Clone(cropArea, _spriteSheet.PixelFormat);
    }
}

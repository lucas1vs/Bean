
using Bean.Utils;

namespace Bean.Entites;

public class Player : GameEntity
{
    private const byte Speed = 7;
    private const byte IdleAnimationCount = 4;
    private const byte RunAnimationCount = 7;
    private const byte MaxAnimationFrame = 8;

    private byte _currentIdleAnimationIndex = 0;
    private byte _currentRunAnimationIndex = 0;
    private byte _frameCounter = 0;
    private bool _isLookingLeft;
    private bool _isWalking;

    private static readonly SpriteSheet s_idleSpriteSheet = new(GameResources.sPlayerIdle);
    private static readonly SpriteSheet s_runSpriteSheet = new(GameResources.sPlayerRun);
    private static readonly Bitmap[] s_lefttidleSprite = new Bitmap[IdleAnimationCount];
    private static readonly Bitmap[] s_rightidleSprite = new Bitmap[IdleAnimationCount];
    private static readonly Bitmap[] s_leftRunSprites = new Bitmap[RunAnimationCount];
    private static readonly Bitmap[] s_rightRunSprites = new Bitmap[RunAnimationCount];

    public bool IsGoingToLeft;
    public bool IsGoingToRight;
    public bool IsGoingToUp;
    public bool IsGoingToDown;
    public Player(Vector2 position, short width, short height, Vector2? scale = null)
        : base(position, width, height, null, scale)
    {
        Start();
    }



    public override void Update()
    {
        Move();

        _frameCounter++;

        if (_frameCounter >= MaxAnimationFrame)
        {
            _frameCounter = 0;


            if (_isWalking)
            {
                _currentIdleAnimationIndex = 0;
                _currentRunAnimationIndex++;

                if (_currentRunAnimationIndex >= RunAnimationCount)
                {
                    _currentRunAnimationIndex = 0;
                }
            }
            else
            {
                _currentRunAnimationIndex = 0;
                _currentIdleAnimationIndex++;


                if (_currentIdleAnimationIndex >= IdleAnimationCount)
                {
                    _currentIdleAnimationIndex = 0;
                }
            }   
        }

        if (_isWalking)
        {
            Sprite = _isLookingLeft ? s_leftRunSprites[_currentRunAnimationIndex] : s_rightRunSprites[_currentRunAnimationIndex];
        }
        else
        {
            Sprite = _isLookingLeft ? s_lefttidleSprite[_currentIdleAnimationIndex] : s_rightidleSprite[_currentIdleAnimationIndex];
        }
    }
    



    private void Move()
    { 
        var direction = new Vector2();
        if (IsGoingToLeft)
        {
            _isLookingLeft = true;
            direction.X -= 1;
        }
        else if (IsGoingToRight)
        {
            _isLookingLeft = false;
            direction.X += 1;
        }

        if (IsGoingToUp)
        {
            direction.Y -= 1;
        }
        else if (IsGoingToDown)
        {
            direction.Y += 1;
        }

        if (direction.Magnitude <= 0)
        {
            _isWalking = false;
            return;
        }

        _isWalking = true;
        direction = direction.Normalized(); 

        Position = new Vector2(Position.X + direction.X * Speed, Position.Y + direction.Y * Speed);
    }
      

    private void Start()
    {
        InitializeAnimations(s_lefttidleSprite, s_idleSpriteSheet, true);
        InitializeAnimations(s_rightidleSprite, s_idleSpriteSheet);
        InitializeAnimations(s_rightRunSprites, s_runSpriteSheet);
        InitializeAnimations(s_leftRunSprites, s_runSpriteSheet, true);

    }

    private void InitializeAnimations(Bitmap[] sprites, SpriteSheet spriteSheet, bool flipX = false)
    {
        for (byte i = 0; i < sprites.Length; i++)
        {
            sprites[i] = spriteSheet.GetSprite(new Vector2(i * Width, 0), Width, Height);

            if (flipX == true)
            {
                sprites[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
              
            }
        }
    }

}

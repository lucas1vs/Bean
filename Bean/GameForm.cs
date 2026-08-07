using Bean.Managers;
using Bean.Utils;

namespace Bean;

public partial class GameForm : Form
{
    private const int RenderScale = 2;
    private const int Margin = 60; // espaço da moldura ao redor do mapa

    public GameForm()
    {
        InitializeComponent();

        Text = "Bean";
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        DoubleBuffered = true;
        BackgroundImage = GameResources.sBg;
        BackgroundImageLayout = ImageLayout.Tile;

        ClientSize = new Size(
            GameConstants.Widht * RenderScale + Margin * 2,
            GameConstants.Height * RenderScale + Margin * 2);
        StartPosition = FormStartPosition.CenterScreen;

        GameScene.StartGame();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (GameResources.sBg != null)
        {
            int bgWidth = GameResources.sBg.Width;
            int bgHeight = GameResources.sBg.Height;

            for (int x = 0; x < ClientSize.Width; x += bgWidth)
            {
                for (int y = 0; y < ClientSize.Height; y += bgHeight)
                {
                    e.Graphics.DrawImage(GameResources.sBg, x, y);
                }
            }
        }

        e.Graphics.TranslateTransform(Margin, Margin);
        e.Graphics.ScaleTransform(RenderScale, RenderScale);

        GameScene.Render(e.Graphics);

        base.OnPaint(e);
    }
    


    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        timerGameLoop = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // timerGameLoop
        // 
        timerGameLoop.Enabled = true;
        timerGameLoop.Interval = 16;
        timerGameLoop.Tick += TimerGameLoop_Tick;
        // 
        // GameForm
        // 
        ClientSize = new Size(284, 261);
        Name = "GameForm";
        KeyDown += GameForm_KeyDown;
        KeyUp += GameForm_KeyUp;
        ResumeLayout(false);
    }

    private void TimerGameLoop_Tick(object sender, EventArgs e)
    {
        GameScene.Update();
        Refresh();
    }


    

    private void GameForm_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.W:
            case Keys.Up:
                GameScene.Player.IsGoingToUp = true;
                break;


            case Keys.S:
            case Keys.Down:
                GameScene.Player.IsGoingToDown = true;
                break;

            case Keys.A:
            case Keys.Left:
                GameScene.Player.IsGoingToLeft = true;
                break;

            case Keys.D:
            case Keys.Right:
                GameScene.Player.IsGoingToRight = true;
                break;


            default:
                break;
        }
        
    }

    private void GameForm_KeyUp(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.W:
            case Keys.Up:
                GameScene.Player.IsGoingToUp = false;
                break;


            case Keys.S:
            case Keys.Down:
                GameScene.Player.IsGoingToDown = false;
                break;

            case Keys.A:
            case Keys.Left:
                GameScene.Player.IsGoingToLeft = false;
                break;

            case Keys.D:
            case Keys.Right:
                GameScene.Player.IsGoingToRight = false; 
                break;


            default:
                break;
        }

        }
    }
    

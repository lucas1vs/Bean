using Bean.Entites;
using Bean.Utils;

namespace Bean.Managers;

public static class GameScene
{
    public static Player Player;
    private static readonly List<GameEntity> s_gameEntities = [];

    public static void Update()
    {
        for (int i = 0; i < s_gameEntities.Count; i++)
        {
            s_gameEntities[i].Update();
        }
    }

    public static void Render(Graphics graphics)
    {
        for (int i = 0; i < s_gameEntities.Count; i++)
        {
            s_gameEntities[i].Render(graphics);
        }
    }

    public static void StartGame()
    {
        var map = new Map(1, new Vector2(0, 0), GameConstants.Widht, GameConstants.Height);

        Player = new Player(
            new Vector2(GameConstants.Widht / 2 - 20, GameConstants.Height / 2 - 20),
            40, 40);
    }

    public static void AddGameEntityToScene(GameEntity entity) => s_gameEntities.Add(entity);
}

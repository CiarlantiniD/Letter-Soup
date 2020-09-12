
public interface IGameRepository
{
    bool HaveGame();
    void Save(Game game);
    Game Get();
    void Delete();
}

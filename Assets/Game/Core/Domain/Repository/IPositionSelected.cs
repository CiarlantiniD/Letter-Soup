public interface IPositionSelected
{
    bool Exist(Position position);
    Letter Get(Position position);
    void Save(Letter letterData);
}

public class Letter
{
    public Position Position { get; }
    public TypeClickLetter TypeClickLetter { get; }

    public Letter(Position position, TypeClickLetter typeClickLetter)
    {
        this.Position = position;
        this.TypeClickLetter = typeClickLetter;
    }
}

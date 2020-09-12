public class Word
{
    public int Lenght { get { return Value.Length; } }
    public string Value { get; }

    public Word(string word)
    {
        Value = word;
    }

    public char[] ToCharArray()
    {
        return Value.ToCharArray();
    }
}

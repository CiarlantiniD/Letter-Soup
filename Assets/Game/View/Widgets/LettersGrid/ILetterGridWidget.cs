

public interface ILetterGridWidget
{
    void Load();
    void SetLettersGridPosition(GridWithLetters letterGridData);
    void SetLettersGrid(GridWithLetters letterGridData);
    void TurnOffAll();
    void HightlightLetter(Position position);
}

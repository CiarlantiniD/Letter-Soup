using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterRowComponent : MonoBehaviour
{
    [SerializeField] private LetterComponent[] letters;

    public void SetLetterPosition(int x, int y)
    {
        letters[x].Load(x, y);
    }

    public void SetLetterInPosition(int x, char newLetter)
    {
        letters[x].SetLetter(newLetter);
    }
}

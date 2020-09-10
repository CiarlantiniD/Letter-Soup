using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterRowComponent : MonoBehaviour
{
    [SerializeField] private LetterComponent[] letters;

    public void SetLetterInPosition(int x, char newLetter)
    {
        letters[x].SetLetter(newLetter);
    }

    public void SetLetterPosition(int x, int y)
    {
        letters[x].SetPosition(x, y);
    }
}

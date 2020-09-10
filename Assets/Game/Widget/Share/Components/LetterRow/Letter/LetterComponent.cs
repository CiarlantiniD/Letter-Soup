using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterComponent : MonoBehaviour
{
    [SerializeField] private Text letter;

    public void SetLetter(char newLetter)
    {
        letter.text = newLetter.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameWords : MonoBehaviour
{
    [SerializeField] private Text text;

    public void Load(List<Word> words)
    {
        string texto = "";

        foreach (var word in words)
        {
            texto += word.Value + ", ";
        }

        text.text = texto;
    }
}

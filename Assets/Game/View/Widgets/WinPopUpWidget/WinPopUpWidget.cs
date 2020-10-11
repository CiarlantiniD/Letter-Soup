using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopUpWidget : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private ResetGameWidget resetGameWidget;

    public void Load()
    {
        resetGameWidget.Load();
        resetGameWidget.OnResetGame += ClosePopUp;
        closeButton.onClick.AddListener(ClosePopUp);
        gameObject.SetActive(false);
    }

    public void OpenPopUp()
    {
        gameObject.SetActive(true);
    }

    public void ClosePopUp()
    {
        gameObject.SetActive(false);
    }
}

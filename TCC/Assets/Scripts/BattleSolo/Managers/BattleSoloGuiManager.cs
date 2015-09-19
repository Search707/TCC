using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BattleSoloGuiManager : MonoBehaviour
{
    public enum UIButtons
    {
        START
    }

    public event Action onClickStartButton;

    public Button[] uiButtons;

    public void OnClickStartButton()
    {
        if(onClickStartButton != null) onClickStartButton();
    }

    public void SetUIButtonActive(UIButtons p_button, bool p_active)
    {
        uiButtons[(int)p_button].gameObject.SetActive(p_active);
    }
}

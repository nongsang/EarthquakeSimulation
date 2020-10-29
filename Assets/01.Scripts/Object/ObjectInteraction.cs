using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private bool isActive = false;

    [SerializeField] private string Name = "시작버튼";
    [SerializeField] private string UIMsg = "시작하기";

    public void ShowInteractionMsg(bool isShow)
    {
        UICtrl.UI.ShowInteractionMsg(UIMsg, isShow);
    }

    public void SetActive(bool value)
    {
        isActive = value;
    }

    public bool GetActive()
    {
        return isActive;
    }
}
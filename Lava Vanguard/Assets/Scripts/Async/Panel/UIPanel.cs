using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Button backButton;
    public bool isOpen = false;
    private void Start()
    {
        //backButton.onClick.AddListener(Hide);
    }
    public virtual void Show()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }
}

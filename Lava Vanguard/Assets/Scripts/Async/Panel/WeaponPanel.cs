using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPanel : UIPanel
{
    public override void Show()
    {
        base.Show();
        Time.timeScale = 0f;
    }
    public override void Hide()
    {
        base.Hide();
        Time.timeScale = 1f;
    }
}

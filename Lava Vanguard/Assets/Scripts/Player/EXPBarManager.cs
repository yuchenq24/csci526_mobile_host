using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerView playerView;
    public Image expBarFill;
    public TextMeshProUGUI expLabel;

    // Update is called once per frame
    void Update()
    {
        expBarFill.fillAmount = playerView.GetEXPPercent();
        expLabel.text = "Level: " + playerView.GetLevel();
    }
}

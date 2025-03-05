using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerView playerView;
    public Image hpBarFill;
    public TextMeshProUGUI hpPercentage;
    // Update is called once per frame
    void Update()
    {
        hpBarFill.fillAmount = playerView.GetHealthPercent();
        hpPercentage.text = "HP: "+playerView.GetCurrentHealth()+ "/" + playerView.GetMaxHealth();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerView playerView;
    public Image hpBarFill;

    // Update is called once per frame
    void Update()
    {
        hpBarFill.fillAmount = playerView.GetHeartPercent();
    }
}

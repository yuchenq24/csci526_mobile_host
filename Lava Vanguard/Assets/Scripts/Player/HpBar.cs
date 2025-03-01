using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HpBar : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerView playerView;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerView != null)
        {
            //hpBarFill.fillAmount = playerData.heart / playerData.maxHeart; // 根据血量计算
        }
    }
}

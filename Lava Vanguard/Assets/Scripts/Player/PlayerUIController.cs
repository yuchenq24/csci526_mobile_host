using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [Header("UI Components")]
    public Image hpBarFill;  // 血条填充部分
    public Image expBarFill; // 经验条填充部分

    [Header("Player Stats")]
    private float maxHP = 100f;
    private float currentHP;

    private float maxEXP = 100f;
    private float currentEXP;

    void Start()
    {
        // 初始化血量满，经验值为空
        currentHP = maxHP;
        currentEXP = 0;
        UpdateUI();
    }

    // **🔹 预留给组员的接口**
    
    // ✅ 扣血
    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateUI();
    }

    // ✅ 加血
    public void Heal(float amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateUI();
    }

    // ✅ 经验条一开始为空，击杀敌人后增加经验
    public void GainEXP(float amount)
    {
        currentEXP += amount;
        currentEXP = Mathf.Clamp(currentEXP, 0, maxEXP);
        UpdateUI();
    }

    // ✅ 经验条满后升级
    private void CheckLevelUp()
    {
        if (currentEXP >= maxEXP)
        {
            currentEXP = 0;  // 经验归零
            maxEXP *= 1.2f; // 下一级经验需求增加
            maxHP += 10f;   // 额外提升最大生命值
            currentHP = maxHP; // 恢复血量
        }
    }

    // **更新 UI**
    private void UpdateUI()
    {
        if (hpBarFill)
            hpBarFill.fillAmount = currentHP / maxHP;

        if (expBarFill)
            expBarFill.fillAmount = currentEXP / maxEXP;
    }
}

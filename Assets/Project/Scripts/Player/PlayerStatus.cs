using UnityEngine;
using Assets.Project.Scripts.Managers;
using Assets.Project.Scripts.Player;

public class PlayerStatus : MonoBehaviour
{
    public PlayerConfig playerConfig;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        if (playerConfig != null) maxHealth = playerConfig.maxHealth;
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
        UpdateUI();
        if (currentHealth <= 0) GameManager.Instance.PlayerDied();
    }

    void UpdateUI()
    {
        if (GameManager.Instance != null && GameManager.Instance.gameUI != null)
        {
            GameManager.Instance.gameUI.SetHealth(currentHealth, maxHealth);
        }
    }
}

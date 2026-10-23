using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text scoreText;
    public TMP_Text waveText;

    public void SetHealth(int current, int max)
    {
        if (healthSlider != null) healthSlider.value = (float)current / max;
    }

    public void SetScore(int score)
    {
        if (scoreText != null) scoreText.text = $"{score} Pontos";
    }

    public void SetWave(int current, int total)
    {
        if (waveText != null) waveText.text = $"Onda {current}/{total}";
    }
}

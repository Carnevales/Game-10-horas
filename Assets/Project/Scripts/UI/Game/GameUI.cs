using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthSlider;
    public Text scoreText;
    public Text waveText;

    public void SetHealth(int current, int max)
    {
        if (healthSlider != null) healthSlider.value = (float)current / max;
    }

    public void SetScore(int score)
    {
        if (scoreText != null) scoreText.text = score.ToString();
    }

    public void SetWave(int current, int total)
    {
        if (waveText != null) waveText.text = $"Wave {current}/{total}";
    }
}

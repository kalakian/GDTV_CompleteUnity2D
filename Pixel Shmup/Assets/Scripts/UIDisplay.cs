using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI scoreText;

    Health playerHealth;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        Player player = FindObjectOfType<Player>();
        if (player)
        {
            playerHealth = player.GetComponent<Health>();
        }
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        UpdateHealthSlider();
        UpdateScoreText();
    }

    void UpdateHealthSlider()
    {
        if (healthSlider)
        {
            if (playerHealth)
            {
                healthSlider.value = playerHealth.GetHealthFraction();
            }
            else
            {
                healthSlider.value = 0;
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText && scoreKeeper)
        {
            scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        }
    }
}

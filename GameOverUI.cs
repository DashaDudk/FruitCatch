using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    public void ShowGameOver(int score)
    {
        Debug.Log("Гра завершена. Очки: " + score);
        if (finalScoreText != null)
        {
            finalScoreText.gameObject.SetActive(true); 
            finalScoreText.text = $"Гру завершено!\nВаш рахунок: {score}";
        }

        Time.timeScale = 0f; 
    }

}

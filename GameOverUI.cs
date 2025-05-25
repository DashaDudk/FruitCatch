using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    public void ShowGameOver(int score)
    {
        Debug.Log("��� ���������. ����: " + score);
        if (finalScoreText != null)
        {
            finalScoreText.gameObject.SetActive(true); 
            finalScoreText.text = $"��� ���������!\n��� �������: {score}";
        }

        Time.timeScale = 0f; 
    }

}

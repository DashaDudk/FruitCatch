using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketCatcher : MonoBehaviour
{
    public int score = 0;
    public GameObject scorePopupPrefab;
    public Transform popupParent;
    public Text scoreText;
    public int lives = 3;
    public HeartsManager heartsManager;
    public TMPro.TextMeshPro scoreDisplay;
    public GameOverUI gameOverUI;
    private bool isGameOver = false;

    private List<string> currentAllowedFruits = new List<string>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isGameOver) return;
        if (other.CompareTag("Fruit"))
        {
            if (other.GetComponent<AlreadyCaught>() != null)
            {
                return;
            }

            other.gameObject.AddComponent<AlreadyCaught>();

            Fruit fruit = other.GetComponent<Fruit>();
            if (fruit != null)
            {
                if (currentAllowedFruits.Contains(fruit.fruitType)) 
                {
                        score += 50;
                        Debug.Log("�������� " + fruit.fruitType + "! +50 ����. ����: " + score);
                }
                else
                {
                    MissFruit();
                    Debug.Log("�������� ������������ �����! �����: " + lives);
                }

                Destroy(other.gameObject);
                UpdateScoreText(); 
            }
        }
    }

    private void UpdateScoreText()
    {
        if (scoreDisplay != null)
        {
            scoreDisplay.text = "Score: " + score;
        }
    }

    public void UpdateAllowedFruits(List<string> newFruits)
    {
        currentAllowedFruits = newFruits;
    }


    public void MissFruit()
    {
        lives--;
        Debug.Log("��������� �����! �����: " + lives);

        if (heartsManager != null)
        {
            heartsManager.LoseLife();
        }

        if (lives <= 0 && !isGameOver)
        {
            isGameOver = true;
            Debug.Log("��� ���������! ���������� �������: " + score);

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver(score);
            }

            GamePauseManager.isPaused = true;
        }
    }

    public bool IsFruitAllowed(string type)
    {
        return currentAllowedFruits.Contains(type);
    }

    public void ResetGame()
    {
        score = 0;
        lives = 3;

        UpdateScoreText();

        if (heartsManager != null)
        {
            heartsManager.ResetHearts();
        }

        currentAllowedFruits.Clear();
    }
}

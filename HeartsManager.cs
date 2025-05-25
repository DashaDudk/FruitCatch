using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HeartsManager : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>(); 
    private int currentLives;
    public GameOverUI gameOverUI;
    public int score;
 
    void Start()
    {
        currentLives = hearts.Count;
    }

    public void LoseLife()
    {
        if (currentLives <= 0) return;

        currentLives--;
        hearts[currentLives].SetActive(false);
    }

    public void ResetHearts()
    {
        foreach (var heart in hearts)
        {
            heart.SetActive(true);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject aboutPanel; 
    public GameObject rulesPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowAbout()
    {
        aboutPanel.SetActive(true); 
    }

    public void HideAbout()
    {
        aboutPanel.SetActive(false); 
    }

    public void ShowRules()
    {
        rulesPanel.SetActive(true);
    }

    public void HideRules()
    {
        rulesPanel.SetActive(false); 
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class FruitTaskManager : MonoBehaviour
{
    public List<string> allowedFruits = new List<string>();
    private BasketCatcher catcher;
    private FruitSpawner fruitSpawner;
    public TMPro.TextMeshProUGUI taskMessageText;


    private void Start()
    {
        catcher = FindFirstObjectByType<BasketCatcher>();
        fruitSpawner = FindFirstObjectByType<FruitSpawner>(); 
        StartCoroutine(TaskRoutine());
    }

    private IEnumerator TaskRoutine()
    {
        while (true)
        {
            yield return StartCoroutine(ShowPauseWithMessage("������ ����� ������!", 3f));
            SetAllowedFruits(new List<string> { "Apple" });

            yield return new WaitForSeconds(15f);

            fruitSpawner.ClearFruits();
            yield return StartCoroutine(ShowPauseWithMessage("������ ����� ��!", 5f));
            SetAllowedFruits(new List<string> { "Kiwi" });

            yield return new WaitForSeconds(15f);

            fruitSpawner.ClearFruits();
            yield return StartCoroutine(ShowPauseWithMessage("������ ������ �� �������!", 5f));
            SetAllowedFruits(new List<string> { "Peach", "Avocado" });

            yield return new WaitForSeconds(15f);

            fruitSpawner.ClearFruits();
            yield return StartCoroutine(ShowPauseWithMessage("������ ��, ������� �� ������!", 5f));
            SetAllowedFruits(new List<string> { "Kiwi", "Pineapple", "Apple" });

            yield return new WaitForSeconds(15f);

            fruitSpawner.ClearFruits();
            yield return StartCoroutine(ShowPauseWithMessage("������ ���, ���� ������ �� �������!", 5f));
            SetAllowedFruits(new List<string> { "Blueberry", "Kiwi", "Pineapple", "Avocado" });

            yield return new WaitForSeconds(15f);

            fruitSpawner.ClearFruits();
            yield return StartCoroutine(ShowPauseWithMessage("Գ������� �����! ��� ���� �� � �������) ����, ���� �� ������� �� �����!", 5f));
            SetAllowedFruits(new List<string> { "Peach", "Blueberry", "Apple", "Avocado" });

            while (catcher.lives > 0)
            {
                yield return null; 
            }
            yield break;
        }
    }

    private IEnumerator ShowPauseWithMessage(string message, float pauseDuration)
    {
        if (taskMessageText != null)
        {
            taskMessageText.text = message;
            taskMessageText.gameObject.SetActive(true); 
        }

        GamePauseManager.isPaused = true;
        fruitSpawner.PauseSpawning();

        yield return new WaitForSeconds(pauseDuration); 

        GamePauseManager.isPaused = false;
        fruitSpawner.ResumeSpawning();

        if (taskMessageText != null)
        {
            taskMessageText.gameObject.SetActive(false);
        }
    }



    private void SetAllowedFruits(List<string> newFruits)
    {
        allowedFruits = newFruits;
        if (catcher != null)
        {
            catcher.UpdateAllowedFruits(newFruits);
        }
    }
}
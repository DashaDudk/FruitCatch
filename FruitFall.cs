using UnityEngine;

public class FruitFall : MonoBehaviour
{
    private Fruit fruit;
    private bool wasProcessed = false;
    private Rigidbody2D rb;
    private Vector2 savedVelocity;

    private void Start()
    {
        fruit = GetComponent<Fruit>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GamePauseManager.isPaused)
        {
            if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                savedVelocity = rb.linearVelocity;
                rb.bodyType = RigidbodyType2D.Kinematic; 
            }
            return;
        }
        else
        {
            if (rb.bodyType == RigidbodyType2D.Kinematic)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.linearVelocity = savedVelocity;
            }
        }

        if (GetComponent<AlreadyCaught>() != null || wasProcessed)
        {
            return;
        }

        if (transform.position.y < -3f)
        {
            BasketCatcher catcher = FindAnyObjectByType<BasketCatcher>();
            if (catcher != null)
            {
                if (catcher.IsFruitAllowed(fruit.fruitType))
                {
                    catcher.MissFruit();
                    Debug.Log("Пропущено правильний фрукт: " + fruit.fruitType);
                }
                else
                {
                    Debug.Log("Пропущено неправильний фрукт: " + fruit.fruitType);
                }
            }
            wasProcessed = true;
            Destroy(gameObject);
        }
    }
}

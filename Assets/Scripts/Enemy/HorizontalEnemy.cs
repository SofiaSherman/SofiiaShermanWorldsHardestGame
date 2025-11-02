using UnityEngine;

public class HorizontalEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Vector3 initDirection;
    private Vector3 currentDirection;

    private float timer = 0;
    [SerializeField] private float travelTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDirection = initDirection;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= travelTime)
        {
            currentDirection *= -1;
            timer = 0;
        }
        transform.Translate(currentDirection * Time.deltaTime * speed);
    }
}

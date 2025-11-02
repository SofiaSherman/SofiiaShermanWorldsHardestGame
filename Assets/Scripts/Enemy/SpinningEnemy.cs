using UnityEngine;

public class SpinningEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 currentDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(currentDirection * speed * Time.deltaTime);
    }
}

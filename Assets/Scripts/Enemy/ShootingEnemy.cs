using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private float shootingTimer;
    [SerializeField] private GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBullet();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootingTimer)
        {
            SpawnBullet();
            timer = 0;
        }
    }

    public void SpawnBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}

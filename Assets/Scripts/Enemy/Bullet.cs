using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private float travelTime;
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        transform.Translate(direction * speed * Time.deltaTime);
        
        //delete timer
        timer += Time.deltaTime;
        if (timer >= travelTime)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}

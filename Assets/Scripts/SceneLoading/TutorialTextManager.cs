using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text01;
    [SerializeField] private TMP_Text text02;
    [SerializeField] private TMP_Text text03;
    [SerializeField] private TMP_Text text04;
    [SerializeField] private TMP_Text textScore;
    
    [SerializeField] private BoxCollider2D TextChangeTo02;
    [SerializeField] private BoxCollider2D TextChangeTo03;
    [SerializeField] private BoxCollider2D TextChangeTo04;
    [SerializeField] private BoxCollider2D TPLevel1;
    
    [SerializeField] private MonoBehaviour enemyScript;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private CircleCollider2D enemyCollider;
    [SerializeField] private GameObject enemy;
    
    [SerializeField] private SpriteRenderer coinSprite;
    [SerializeField] private CircleCollider2D coinCollider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TextChangeTo02"))
        {
            transform.position = new Vector3(-6.5f, 0, 0);
            
            text01.enabled = false;
            text02.enabled = true;
            
            TextChangeTo02.enabled = false;
            TextChangeTo03.enabled = true;
            
            enemyScript.enabled = true;
            enemySprite.enabled = true;
            enemyCollider.enabled = true;
        }
        
        else if (other.CompareTag("TextChangeTo03"))
        {
            transform.position = new Vector3(-6.5f, 0, 0);
            
            textScore.enabled = true;
            text02.enabled = false;
            text03.enabled = true;

            TextChangeTo03.enabled = false;
            TextChangeTo04.enabled = true;
            
            enemy.transform.position = new Vector3(-3.5f, 0f, 0);
            
            coinSprite.enabled = true;
            coinCollider.enabled = true;
        }
        else if (other.CompareTag("TextChangeTo04"))
        {
            transform.position = new Vector3(-6.5f, 0, 0);
            
            text03.enabled = false;
            text04.enabled = true;
            
            TPLevel1.enabled = true;

            if (coinSprite != null && coinCollider != null)
            {
                coinSprite.enabled = false;
                coinCollider.enabled = false;
            }
            
            Destroy(enemy);
        }
        
        if (other.CompareTag("TPLevel1"))
        {
            SceneManager.LoadScene(2);
        }
    }
}

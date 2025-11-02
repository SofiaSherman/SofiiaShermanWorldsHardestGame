using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    //stores player's start position
    private Vector3 initPosition;
    
    //coin related
    [SerializeField] private int coinsCollected = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text blockedExit;
    
    //can player finish the level
    private float targetTimer = 5f;
    private bool wallTriggered = false;
    [SerializeField] private TilemapRenderer tilemapRenderer;
    [SerializeField] private TilemapCollider2D tilemapCollider2D;
    
    //tutorial check
    [SerializeField] private GameObject tutorialCheck;

    //checking if player finished tutorial
    private LevelChange boolScript;
    private GameObject player;

    //dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingTime = 0.5f;
    private float dashingCooldown = 1f;
    [SerializeField] private float dashSpeed;
    
    //movement
    private float hInput;
    private float vInput;
    private Vector3 movementDirection;
    [SerializeField] private float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            StartCoroutine(Dash());
        }

        //timer for instructions to dissappear
        if (blockedExit.enabled && wallTriggered == true)
        {
            targetTimer -= Time.deltaTime;

            if (targetTimer <= 0)
            {
                blockedExit.enabled = false;
                wallTriggered = false;
                targetTimer = 5f;
            }
        }
    }

    private void Movement()
    {
        //movement
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        
        movementDirection = new Vector3(hInput, vInput, 0).normalized;
        transform.Translate(movementDirection * Time.deltaTime * speed, Space.World);
    }

    //coroutines execute function over a number of frames
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        
        float startTime = Time.time;

        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(hInput, vInput, 0).normalized;
        
        while (Time.time < startTime + dashingTime)
        {
            transform.Translate(movementDirection * Time.deltaTime * dashSpeed, Space.World);  
            yield return null; //suspends execution of coroutine till next frame, pauses function till next frame
        }
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown); //can delay function by number of seconds, then proceeds
        canDash = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //touch coin
        if (other.gameObject.CompareTag("Coin"))
        {
            UpdateCoins(other);
        }
        //hit by enemy
        else if (other.gameObject.CompareTag("Enemy"))
        {
            boolScript = tutorialCheck.GetComponent<LevelChange>();
            
            if (boolScript.tutorial == false)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.buildIndex);
                transform.position = initPosition; //translate to inital position   
            }
            else if (boolScript.tutorial == true)
            {
                transform.position = initPosition; //translate to inital position
            }
        }
        
        else if (other.gameObject.CompareTag("Walls"))
        {
            transform.position = initPosition;
        }
        else if (other.gameObject.CompareTag("FinalWall") && coinsCollected != 7)
        {
            transform.position = new Vector3(9.6f, 7.5f, 0);
            
            blockedExit.enabled = true;
            wallTriggered = true;
        }
        else if (other.gameObject.CompareTag("LoadVictoryScene"))
        {
            SceneManager.LoadScene(3);
        }
    }

    private void UpdateCoins(Collider2D other)
    {
        Destroy(other.gameObject);
        coinsCollected++;
        scoreText.text = "Score: " + coinsCollected;

        if (coinsCollected == 7)
        {
            tilemapRenderer.enabled = false;
            tilemapCollider2D.enabled = false;
        }
    }
}

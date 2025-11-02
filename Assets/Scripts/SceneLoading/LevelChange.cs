using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera camera;
    [SerializeField] private int coinsCollected;
    
    public bool tutorial = true;

    void Update()
    {
        //checks  if current scene is level1 to turn off tutorial
        Scene currentScene = SceneManager.GetActiveScene ();
        if (currentScene.name == "Level1")
        {
            tutorial = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TPLevel1"))
        {
            player.transform.position = new Vector3(10,10,10);
            camera.transform.position = new Vector3(10,10,10);
        }
    }
}

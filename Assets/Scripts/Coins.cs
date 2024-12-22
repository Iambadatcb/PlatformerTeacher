using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{

    public static int count;
    public Renderer coinRenderer;
    public string scene;
    public bool enemies;
    public TextMeshProUGUI text;
    public static int coinCount = 0;

    //public scenemanagment sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        //sceneManager = GetComponent<SceneManager>();
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        
        count = coins.Length;
        
    }

    void Update(){
        text.text = coinCount.ToString();
    }
    // Update is called once per frame
   void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Check if the collided object is the player
        if(enemies)
        {

        if (collision.gameObject.tag == "Player")
        {
            
            // Disable the current coin
            coinRenderer.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            coinCount++;

            // Decrement the count
            count--;

            // Check if the count is less than or equal to 0
             if (count <= 0 )
             {
                // Activate the teleporter if it's not already active
                SceneManager.LoadScene(scene);
                
             }
        }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
        {
            
            // Disable the current coin
            coinRenderer.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            coinCount++;

            // Decrement the count
            count--;

            // Check if the count is less than or equal to 0
             if (count <= 0)
             {
                // Activate the teleporter if it's not already active
                SceneManager.LoadScene(scene);
                
             }
        }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{

    public static int count;
    public Renderer coinRenderer;
    public string scene;
    //public scenemanagment sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        //sceneManager = GetComponent<SceneManager>();
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        Debug.Log("it turned on");
        count = coins.Length;
    }

    // Update is called once per frame
   void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("It collided");
        // Check if the collided object is the player
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("It detected");
            // Disable the current coin
            coinRenderer.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

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

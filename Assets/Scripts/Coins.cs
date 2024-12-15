using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public static int count;
    public Renderer coinRenderer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        count = coins.Length;
    }

    // Update is called once per frame
   void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.tag == "Player")
        {
            // Disable the current coin
            coinRenderer.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            // Decrement the count
            count--;

            // Check if the count is less than or equal to 0
            // if (count <= 0)
            // {
            //     // Activate the teleporter if it's not already active
                
            // }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    public int startFrame; //starting frame of hitbox
    public int endFrame; //end frame of hitbox

    public int damage;
    // Use this for initialization

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) //if hitbox makes contact with an enemy
        {
            Debug.Log("Hitbox collided");
            Destroy(other.gameObject); //destroy enemy. Will implement damage in future.
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  
}

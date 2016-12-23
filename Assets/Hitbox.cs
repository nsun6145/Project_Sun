using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    public int startFrame;
    public int endFrame;

    public int damage;
    // Use this for initialization

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Enemy")
        {
            Debug.Log("Hitbox collided");
            Destroy(other.gameObject);
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

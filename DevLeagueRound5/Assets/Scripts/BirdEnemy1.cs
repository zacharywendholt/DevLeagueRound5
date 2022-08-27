using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Flare")
        {
            // it dies
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawning 
        // move around (pathfinding stuff in unity)
        // collide with player, and damage
        // maybe make a bird that shoots back?
        // different colors?
    }
}

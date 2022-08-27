using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlare : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(!player.inBaloon)
            {
                
                player.collectedFlare();
                Destroy(gameObject);
                // pick up the item, add to inventory
                // destroy it              
            }
        }
    }

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

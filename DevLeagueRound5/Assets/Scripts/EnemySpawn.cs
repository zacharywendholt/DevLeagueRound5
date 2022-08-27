using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    public List<GameObject> birds;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            foreach(GameObject child in birds)
        {
            child.SetActive(true);
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

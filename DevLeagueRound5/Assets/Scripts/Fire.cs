using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    SpriteRenderer SpriteRenderer = new SpriteRenderer();

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Flare")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            print("ayo!");
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

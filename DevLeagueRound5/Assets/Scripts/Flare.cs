using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject baloon = GameObject.FindWithTag("Baloon");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(baloon.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
        Physics2D.IgnoreCollision(baloon.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}

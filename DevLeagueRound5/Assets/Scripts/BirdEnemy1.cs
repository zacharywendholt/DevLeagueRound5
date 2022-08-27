using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy1 : MonoBehaviour
{

[SerializeField] float moveSpeed = 3f;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Flare")
        {
            // it dies
            Destroy(gameObject);
        }
        if(other.tag == "Baloon")
        {
            other.GetComponent<Baloon>().decreaseHealth();
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
        FollowPath();
    }

    void FollowPath()
    {
        Vector3 targetPosition = GameObject.FindWithTag("Baloon").transform.position;
        float delta = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
    }
}

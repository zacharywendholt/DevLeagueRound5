using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.inBaloon) {
            transform.position = player.transform.position;
        }
    }
}

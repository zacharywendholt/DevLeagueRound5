using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    [SerializeField] Player player;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        player.updateBaloonText();
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.inBaloon) {
            transform.position = player.transform.position;
        }
    }

    public void decreaseHealth() {
        health -= 1;
        player.updateBaloonText();
        if (health <= 0) {
            Application.LoadLevel("GameOver");
        }
    }

    public int getHealth() {
        return health;
    }
}

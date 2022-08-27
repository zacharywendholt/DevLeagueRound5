using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Player : MonoBehaviour
{

    
    public GameObject flarePrefab;
    public Rigidbody2D rb;
    public TextMeshProUGUI  textMesh;

    [SerializeField] int floatSpeed;
    public float maxHorizontalFloatingSpeed;
    public float maxWalkingSpeed;
    public bool inBaloon;
    private bool touchingBaloon;
    [SerializeField] int _throwSpeed;
    private int numberOfFlares;
    

    

    // Start is called before the first frame update
    void Start()
    {
        inBaloon = false;
        touchingBaloon = false;
        numberOfFlares = 0;
        updateFlareText();
    }

    // Update is called once per frame
    void Update()
    {
        // going to have to probably add a check to make sure it is grounded / touching the baloon.
        if (Input.GetKeyDown("space") & touchingBaloon) {
            changeBetweenBaloonAndWalking();
        }

        if (Input.GetMouseButtonDown(0) & numberOfFlares > 0) {
            Vector3 clickLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 throwForce = clickLocation - transform.position;
            throwForce = throwForce.normalized * _throwSpeed;
            
            GameObject flare = Instantiate(flarePrefab, transform.position, Quaternion.identity);
            flare.GetComponent<Rigidbody2D>().AddForce(throwForce, ForceMode2D.Impulse);
            numberOfFlares -= 1;
            updateFlareText();
        }
    }


    private void FixedUpdate() {
       movement();
    }


    private void movement() {
        // setting the float for testing purposes. 
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        float currentHorizontalVelocity = Vector2.Dot(rb.velocity, Vector2.right);
        float currentVerticalVelocity = Vector2.Dot(rb.velocity, Vector2.up);
        
        if (inBaloon) {
            // After testing this needs to be changed to only allow horizontal movement. 
            Vector2 newDirection = new Vector2(horizontalMovement * ( Mathf.Abs(maxHorizontalFloatingSpeed) - (horizontalMovement * currentHorizontalVelocity)), verticalMovement * floatSpeed);
            rb.AddForce(newDirection, ForceMode2D.Force);
        } else {
            rb.velocity = new Vector2(maxWalkingSpeed * horizontalMovement, currentVerticalVelocity);
        }
        
    }


    private void changeBetweenBaloonAndWalking() {
        inBaloon = !inBaloon;
        if (inBaloon) {
            rb.gravityScale = .25f;
        }
        else {
            rb.gravityScale = 1;
        }
    }


    private void updateFlareText() {
        textMesh.text ="Flares: " + numberOfFlares;
    }


    public void collectedFlare() {
        numberOfFlares += 1;
        updateFlareText();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Baloon") {
            touchingBaloon = true;
        }
    }
    

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Baloon") {
            touchingBaloon = false;
        }
    }
}

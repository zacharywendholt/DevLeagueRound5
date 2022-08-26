using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float maxHorizontalSpeed = 3;
    [SerializeField] int floatSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate() {
        // setting the float for testing purposes. 
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        float currentHorizontalVelocity = Vector2.Dot(rb.velocity, Vector2.right);
        float currentVerticalVelocity = Vector2.Dot(rb.velocity, Vector2.up);

        print(currentHorizontalVelocity + " : " +  currentVerticalVelocity);


        
        // After testing this needs to be changed to only allow horizontal movement. 
        Vector2 newDirection = new Vector2(horizontalMovement * ( Mathf.Abs(maxHorizontalSpeed) - (horizontalMovement * currentHorizontalVelocity)), verticalMovement * floatSpeed);
        rb.AddForce(newDirection, ForceMode2D.Force);
    }
}

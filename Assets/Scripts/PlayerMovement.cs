using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private float defaultSpeedMultiplier = 10;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool lastDirection;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement calculation
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        //Fliping Character
        GetComponentInChildren<SpriteRenderer>().flipX = IsLeft();
        
        anim.SetBool("walking", IsWalking());


    }

    private void FixedUpdate() {
        rb.velocity = (moveInput * (moveSpeed)*defaultSpeedMultiplier) * Time.deltaTime;
    }
    //Check player direction 
    private bool IsLeft(){
        //Right
        if((int) Input.GetAxisRaw("Horizontal") == 1){
            
            lastDirection = false;
            return false;
        }
        //Left
        else if((int) Input.GetAxisRaw("Horizontal") == -1){
            
            lastDirection = true;
            return true;
        }
        //If nothing is pressed
        else{
            
            return lastDirection;
        }
    }

    private bool IsWalking(){
        if((int) Input.GetAxisRaw("Horizontal")  == 0 && (int) Input.GetAxisRaw("Vertical") == 0)
            return false;
        else
            return true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce = 10;
    public float Speed = 6;
    public bool jumpRelesed;

    private Rigidbody2D _rb;
   
    void Start()
    {
         _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
     void Jump(){
       if(Input.GetButtonDown("Jump") && !jumpRelesed){
           _rb.AddForce(new Vector2(0,JumpForce * Time.deltaTime), ForceMode2D.Impulse);
       }
    }
     void Movement(){
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,0);
      transform.position += movement * Speed * Time.deltaTime;
    }
    void FixedUpdate(){
        Movement();
        Jump();
    }
    void OnCollisionEnter2D(Collision2D outro){
        if(outro.gameObject.CompareTag("Ground")){
            jumpRelesed = false;
        }
    }
    void OnCollisionExit2D(Collision2D outro){
        if(outro.gameObject.CompareTag("Ground")){
            jumpRelesed = true;
        }
    }
}

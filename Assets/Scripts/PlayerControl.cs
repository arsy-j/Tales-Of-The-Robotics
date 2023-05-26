using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    Vector3 Movement;
    public float speed ;
    private Vector2 move ;
    
    public CharacterController controller;

    Animator animator;
    public float lookRotationSpeed = 0.15f ;
    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Movement.x = move.x;
        Movement.z = move.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void Gravity()
    {
        if (controller.isGrounded)
        {
            float groundedGravity = -0.5f;
            move.y=groundedGravity;
            Movement.y=groundedGravity;
        }
        else 
        {
            float EarthGravity = -9.81f ;
            move.y = EarthGravity;
            Movement.y=EarthGravity;
        }
    }
    public void MovePlayer()
    {
        
         if (move.sqrMagnitude !> 0.15f)
        {
            Vector3 movement = new Vector3(move.x, 0f, move.y);
            animator.SetBool("IsWalking", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            controller.Move(movement * speed * Time.deltaTime);


        }
         else
        {
            animator.SetBool("IsWalking", false);
           
        }
        
    }
    
}

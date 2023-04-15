using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 5f;
    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    bool climb = false;

    //ladder variables
    [SerializeField] public bool canClimb = false;
    [SerializeField] public bool bottomLadder = false;
    [SerializeField] public bool topLadder = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        animator.SetFloat("speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("isCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (canClimb && Input.GetAxisRaw("Vertical") != 0)
        {
            climb = true;
            animator.SetBool("isClimbing", true);
        }
        else
        {
            climb = false;
        }


    }

    void FixedUpdate()
    {

        Debug.Log("Entrada Y: " + Input.GetAxisRaw("Vertical"));
        Debug.Log("Entrada X: " + Input.GetAxisRaw("Horizontal"));

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, climb);
        jump = false;
        //    Debug.Log("crouching" + crouch);
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void onCrouching(bool isCrouching)
    {
        Debug.Log("crouching....");
        animator.SetBool("isCrouching", isCrouching);
    }


}

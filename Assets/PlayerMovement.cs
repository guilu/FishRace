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
    }
    else if (Input.GetButtonUp("Crouch"))
    {
      crouch = false;
    }


  }

  void FixedUpdate()
  {
    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    jump = false;
  }

  public void onLanding()
  {
    animator.SetBool("isJumping", false);
  }

  public void onCrouching(bool isCrouching)
  {
    animator.SetBool("isCrouching", isCrouching);
  }


}

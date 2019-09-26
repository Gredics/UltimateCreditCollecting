using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public Joystick joystick;
    public FixedJoystickButton joystickButton;
    public Animator animator;
    public CharacterController2D characterController2D;
    
    public float runSpeed = 30f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }else if(joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }

        float verticalMove = joystick.Vertical;

        if(!jump && joystickButton.pressed)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public FixedJoystickJumpButton fixedJoystickJumpButton;
    public FixedJoystickLeftButton fixedJoystickLeftButton;
    public FixedJoystickRightButton fixedJoystickRightButton;
    public Animator animator;
    public CharacterController2D characterController2D;
    
    public float speed = 30f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(fixedJoystickRightButton.pressed)
        {
            horizontalMove = speed;
        }else if(fixedJoystickLeftButton.pressed)
        {
            horizontalMove = -speed;
        }
        else
        {
            horizontalMove = 0;
        }

        if(!jump && fixedJoystickJumpButton.pressed)
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
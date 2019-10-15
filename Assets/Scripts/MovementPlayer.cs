using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public GameObject player;

    public CharacterController2D characterController2D;

    public FixedJoystickJumpButton fixedJoystickJumpButton;
    public FixedJoystickLeftButton fixedJoystickLeftButton;
    public FixedJoystickRightButton fixedJoystickRightButton;

    public Animator animator;
    
    public float speed = 30f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (player.name == "Player1")
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

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
            if (player.name == "Player1")
            {
                animator.SetBool("IsJumping", true);
            }
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
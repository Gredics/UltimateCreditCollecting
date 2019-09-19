using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public CharacterController2D characterController2D;
    public float runSpeed = 40f;
    float horizontalMove = 0;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
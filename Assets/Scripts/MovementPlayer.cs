using System;
using System.IO;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public GameObject player;

    public CharacterController2D characterController2D;

    FixedJoystickJumpButton fixedJoystickJumpButton;
    FixedJoystickLeftButton fixedJoystickLeftButton;
    FixedJoystickRightButton fixedJoystickRightButton;

    public Animator animator;
    
    public float speed = 30f;
    float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        readFile();
        fixedJoystickJumpButton = FindObjectOfType<FixedJoystickJumpButton>();
        fixedJoystickLeftButton = FindObjectOfType<FixedJoystickLeftButton>();
        fixedJoystickRightButton = FindObjectOfType<FixedJoystickRightButton>();
    }

    private void Update()
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

    private void FixedUpdate()
    {
        characterController2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void readFile()
    {
        string fileName = "config.ini";

        try
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    int costumeType = lines[0][0] - '0';

                    if ((player.name[name.Length - 1] - '1') != costumeType)
                    {
                        player.SetActive(false);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

                input.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void onLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
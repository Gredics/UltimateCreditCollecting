using UnityEngine;
using UnityEngine.UI;

public class Doorman : MonoBehaviour
{
    Text dialog;
    GameObject dialogBox;
    GameObject nextButton;
    GameObject exitButton;
    GameObject lobbyButton;
    GameObject[] fixedJoystickButtons;
    GameObject[] answersButtons;

    string tutorialDialog;
    string goAwayDialog;
    string[] tutorialDialogArray;
    int count;
    int countTime;
    bool doormanTutorial;

    private void Start()
    {
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
        dialogBox = GameObject.Find("Dialog Box");
        fixedJoystickButtons = GameObject.FindGameObjectsWithTag("Fixed Joystick Button");
        answersButtons = GameObject.FindGameObjectsWithTag("Answer");
        nextButton = GameObject.FindGameObjectWithTag("Next Button");
        exitButton = GameObject.FindGameObjectWithTag("Exit");
        lobbyButton = GameObject.FindGameObjectWithTag("Lobby");

        tutorialDialog = "Welcome to the UCC!\n" +
            "Your job is to collect all the coins on the level.\n" +
            "If you done, you can enter the lift and select the subjects which you want.\n" +
            "Then your credits will be increace!\n" +
            "OK, my job is done. Do your thing...";
        goAwayDialog = "Go Away Son!";

        tutorialDialogArray = tutorialDialog.Split('\n');
        count = 0;
        countTime = 0;
        doormanTutorial = false;

        dialogBox.SetActive(false);
        nextButton.SetActive(false);
        for (int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(dialogBox.activeSelf && doormanTutorial == true)
        {
            countTime++;
            if(countTime > 120)
            {
                dialogBox.SetActive(false);
                countTime = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && doormanTutorial == false)
        {
            nextButtonPressed();

            exitButton.SetActive(false);
            lobbyButton.SetActive(false);
            dialogBox.SetActive(true);
            nextButton.SetActive(true);

            for (int i = 0; i < fixedJoystickButtons.Length; i++)
            {
                fixedJoystickButtons[i].SetActive(false);
            }
        }
        else if(collision.collider.tag == "Player" && doormanTutorial == true)
        {
            dialog.text = goAwayDialog;
            dialogBox.SetActive(true);
        }
    }

    public void nextButtonPressed()
    {
        if (count < tutorialDialogArray.Length)
        {
            dialog.text = tutorialDialogArray[count];
            count++;
        }
        else
        {
            exitButton.SetActive(true);
            lobbyButton.SetActive(true);
            dialogBox.SetActive(false);
            nextButton.SetActive(false);
            doormanTutorial = true;

            for (int i = 0; i < fixedJoystickButtons.Length; i++)
            {
                fixedJoystickButtons[i].SetActive(true);
            }
        }
    }
}
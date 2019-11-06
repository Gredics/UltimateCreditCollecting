using UnityEngine;
using UnityEngine.UI;

public class Doorman : MonoBehaviour
{
    GameObject[] buttons;
    GameObject dialogBox;
    Text dialog;

    bool doormanTutorial = false;

    private void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Fixed Joystick Button");
        dialogBox = GameObject.Find("Dialog Box");
        dialog = GameObject.Find("Dialog").GetComponent<Text>();

        dialogBox.SetActive(false);
        dialog.text = "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tutorialDialog = "Kreatív módon kell monetizálni a globális preferenciák szerinti szegmentumokat.........";
        string goAwayDialog = "Go Away Son!";

        if (collision.collider.tag == "Player")
        {
            dialogBox.SetActive(true);

            if (!doormanTutorial)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(false);
                }

                for (int i = 0; i < tutorialDialog.Length / 87; i++)
                {
                    int count = 0;

                    if (Input.touchCount > 0)
                    {
                        dialog.text = tutorialDialog.Substring(count, count + 87);
                        count += 88;
                    }
                }

                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(true);
                }

                dialogBox.SetActive(false);
                doormanTutorial = true;
            }
            else
            {
                dialog.text = goAwayDialog;
                dialogBox.SetActive(false);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CreditCollected : MonoBehaviour
{
    public GameObject credit;

    Text dialog;
    Text creditCounter;
    GameObject dialogBox;
    GameObject nextButton;
    GameObject exitButton;
    GameObject lobbyButton;
    GameObject[] fixedJoystickButtons;
    GameObject[] answersButtons;

    string fileName = "qaa.txt";

    private void Start()
    {
        fileName = Application.persistentDataPath + "/" + fileName;

        creditCounter = GameObject.Find("Credit Counter").GetComponent<Text>();
        fixedJoystickButtons = GameObject.FindGameObjectsWithTag("Fixed Joystick Button");
        answersButtons = GameObject.FindGameObjectsWithTag("Answer");
        nextButton = GameObject.FindGameObjectWithTag("Next Button");
        exitButton = GameObject.FindGameObjectWithTag("Exit");
        lobbyButton = GameObject.FindGameObjectWithTag("Lobby");
        dialogBox = GameObject.Find("Dialog Box");
        //dialog = GameObject.Find("Dialog").GetComponent<Text>();

        //dialogBox.SetActive(false);
        //nextButton.SetActive(false);
        for (int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            int counter = 0;

            try
            {
                counter = Convert.ToInt32(creditCounter.text);
                counter++;
                creditCounter.text = counter.ToString();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            Destroy(credit);

            if(credit.tag == "Credit - Question")
            {
                readFile();
            }
        }
    }

    public void readFile()
    {
        string[] lines;

        try
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter output = new StreamWriter(fileName))
                {
                    output.Write("What's the name of our University?\n" +
                        "University of Pannonia*\n" +
                        "Szent István University\n" +
                        "University of West Hungary\n" +
                        "Corvinus University\n" +
                        "What's the meaning of MIK?\n" +
                        "Műszaki Informatikai Kar*\n" +
                        "Magyar Irodalmi Kultúra\n" +
                        "How many semesters of curriculum according to the programmer in computer science?\n" +
                        "3\n" +
                        "4\n" +
                        "5\n" +
                        "6*\n");

                    output.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        try
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                try
                {
                    lines = File.ReadAllLines(fileName);

                    input.Close();
                }catch(Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
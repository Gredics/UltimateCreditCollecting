using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Sprite idle1_1;
    public Sprite idle2_1;

    Button changeCostumeButton;

    string fileName = "config.ini";

    void Start()
    {
        changeCostumeButton = GameObject.Find("Change Costume").GetComponent<Button>();
        readFile();
    }

    public void changeCostume()
    {
        if (changeCostumeButton.image.sprite == idle1_1)
        {
            changeCostumeButton.image.sprite = idle2_1;
        }
        else
        {
            changeCostumeButton.image.sprite = idle1_1;
        }
    }

    public void readFile()
    {
        try
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    char costumeType = lines[0][0];

                    if (costumeType == '0')
                    {
                        changeCostumeButton.image.sprite = idle1_1;
                    }
                    else
                    {
                        changeCostumeButton.image.sprite = idle2_1;
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

    public void writeFile()
    {
        using (StreamWriter output = new StreamWriter(fileName))
        {
            try
            {
                if (changeCostumeButton.image.sprite == idle1_1)
                {
                    output.Write("0");
                }
                else
                {
                    output.Write("1");
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            output.Close();
        }
    }

    public void playGame()
    {
        Debug.Log("Starting the Game.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Debug.Log("The Program is Quiting...");
        Application.Quit();        
    }
}
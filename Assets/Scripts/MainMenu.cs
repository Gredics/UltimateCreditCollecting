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

    string fileName = "settings.ini";
    string[] lines;

    void Start()
    {
        changeCostumeButton = GameObject.Find("Change Costume").GetComponent<Button>();
        fileName = Application.persistentDataPath + "/" + fileName;
        readFile();
    }

    public void changeCostume()
    {
        if (changeCostumeButton.image.sprite == idle1_1)
        {
            changeCostumeButton.image.sprite = idle2_1;
            lines[0] = "1";
        }
        else
        {
            changeCostumeButton.image.sprite = idle1_1;
            lines[0] = "0";
        }
    }

    public void readFile()
    {
        try
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter output = new StreamWriter(fileName))
                {
                    output.Write("0\n" +
                        "0");

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
        try
        {
            using (StreamWriter output = new StreamWriter(fileName))
            {
                for(int i = 0; i < lines.Length; i++)
                {
                    output.WriteLine(lines[i]);
                }

                output.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
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
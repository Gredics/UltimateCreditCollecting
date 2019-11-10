using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{
    public Text creditCounter;

    string fileName = "settings.ini";
    string[] lines;

    private void Start()
    {
        fileName = Application.persistentDataPath + "/" + fileName;
        readFile();
    }

    public void readFile()
    {
        try
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                lines = File.ReadAllLines(fileName);

                try
                {
                    creditCounter.text = lines[1];
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
                lines[1] = creditCounter.text;

                for(int i = 0; i < lines.Length; i++)
                {
                    output.WriteLine(lines[i]);
                }

                output.Close();
            }
        }catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void exitToMenu()
    {
        writeFile();
        SceneManager.LoadScene(0);
    }

    public void exitToLobby()
    {
        writeFile();
        SceneManager.LoadScene(2);
    }
}
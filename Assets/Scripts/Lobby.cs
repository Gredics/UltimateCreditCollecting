using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Text creditCounter;
    public Text collectedCredit;
    public Slider creditSlider;

    GameObject[] subjects;

    string fileName = "settings.ini";
    string[] lines;

    private void Start()
    {
        subjects = GameObject.FindGameObjectsWithTag("Subject");

        fileName = Application.persistentDataPath + "/" + fileName;

        readFile();
        countCredits();
    }

    public void readFile()
    {
        try
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                lines = File.ReadAllLines(fileName);

                creditCounter.text = lines[1];

                if (lines.Length > 2)
                {
                    for (int i = 2; i < lines.Length; i++)
                    {
                        for (int j = 0; j < subjects.Length; j++)
                        {
                            if (lines[i] == subjects[j].name)
                            {
                                subjects[j].GetComponent<Image>().color = new Color32(74, 208, 131, 255);
                            }
                        }
                    }
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

                output.WriteLine(lines[0] + "\n" + lines[1]);

                for (int i = 0; i < subjects.Length; i++)
                {
                    if (subjects[i].GetComponent<Image>().color == new Color32(74, 208, 131, 255))
                    {
                        output.WriteLine(subjects[i].name);
                    }
                }

                output.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void accomplishSubject()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.GetComponent<Button>().name;

        int i = 0;

        while(i < subjects.Length && subjects[i].name != buttonName)
        {
            i++;
        }

        if (i < subjects.Length && subjects[i].GetComponent<Image>().color != new Color32(74, 208, 131, 255)
            && Convert.ToInt32(creditCounter.text) >= Convert.ToInt32(subjects[i].GetComponentsInChildren<Text>()[1].text))
        {
            subjects[i].GetComponent<Image>().color = new Color32(74, 208, 131, 255);
            creditCounter.text = (Convert.ToInt32(creditCounter.text)
                - Convert.ToInt32(subjects[i].GetComponentsInChildren<Text>()[1].text)).ToString();
            countCredits();
        }
    }

    public void countCredits()
    {
        int all = 0;
        creditSlider.value = 0;

        for (int i = 0; i < subjects.Length; i++)
        {
            if (subjects[i].GetComponent<Image>().color == new Color32(74, 208, 131, 255))
            {
                creditSlider.value += Convert.ToInt32(subjects[i].GetComponentsInChildren<Text>()[1].text);
            }

            all += Convert.ToInt32(subjects[i].GetComponentsInChildren<Text>()[1].text);
        }

        collectedCredit.text = creditSlider.value.ToString() + "/" + all.ToString();
    }

    public void exitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
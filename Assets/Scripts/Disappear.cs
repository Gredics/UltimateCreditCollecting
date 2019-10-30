using System;
using UnityEngine;
using UnityEngine.UI;

public class Disappear : MonoBehaviour
{
    public GameObject credit;
    Text creditCounter;

    private void Start()
    {
        creditCounter = GameObject.Find("Credit Counter").GetComponent<Text>();
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
            }catch(Exception e)
            {
                Debug.LogError(e);
            }

            Destroy(credit);
        }
    }
}
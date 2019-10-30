using UnityEngine;

public class Doorman : MonoBehaviour
{
    GameObject dialogueBubble;

    private void Start()
    {
        dialogueBubble = GameObject.FindGameObjectWithTag("Dialogue Bubble");
        dialogueBubble.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            dialogueBubble.SetActive(true);
        }
    }
}
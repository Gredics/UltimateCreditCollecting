using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject credit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("You gain 1 Credit!");
            credit.SetActive(false);
        }
    }
}

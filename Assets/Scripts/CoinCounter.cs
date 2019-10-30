using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text creditCounter;
    GameObject[] credits;

    private void Start()
    {
        credits = GameObject.FindGameObjectsWithTag("Credit");
    }
}
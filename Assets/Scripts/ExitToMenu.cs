using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    public void exitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
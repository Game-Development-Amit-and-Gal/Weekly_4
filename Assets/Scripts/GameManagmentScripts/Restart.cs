using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Restart the Game
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

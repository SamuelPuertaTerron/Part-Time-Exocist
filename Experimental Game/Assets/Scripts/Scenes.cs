using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void WaitScreen(){
        SceneManager.LoadScene("WaitScreen");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void GameScreen(){
        SceneManager.LoadScene("Gameplay");
    }
}

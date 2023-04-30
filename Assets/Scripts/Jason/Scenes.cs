using UnityEngine;
using UnityEngine.SceneManagement;

namespace PartTimeExocist {
    
    //Pretty self exoplanitory

    public class Scenes : MonoBehaviour {
        public void WaitScreen() {
            SceneManager.LoadScene("WaitScreen");
        }

        public void MainMenu() {
            SceneManager.LoadScene("MainMenu");
        }

        public void GameScreen() {
            SceneManager.LoadScene("Main");
        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PartTimeExocist {
    public class SceneController : Extensions.Singleton<SceneController> {

        public void LoadWaitScene() {
            SceneManager.LoadScene("WaitScreen");
        }

        public void LoadMainMenu() {
            SceneManager.LoadScene("MainMenu");
        }

        public void LoadGameScreen() {
            SceneManager.LoadScene("Main");
        }
    }
}



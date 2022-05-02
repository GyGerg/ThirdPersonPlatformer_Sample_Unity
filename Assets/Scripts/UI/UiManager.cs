using UnityEngine;
using UnityEngine.SceneManagement;

public static class UiManager
    {
        public static void Restart()
        {
            var GMinst = GameManager.Instance;
            var VictInst = VictoryScreen.Instance;
            var GameOverInst = GameOverScreen.Instance;
            var GameUiInst = GameUiScreen.Instance;
            GameManager.Instance = null;
            VictoryScreen.Instance = null;
            GameOverScreen.Instance = null;
            GameUiScreen.Instance = null;
            Object.Destroy(GMinst);
            Object.Destroy(VictInst);
            Object.Destroy(GameOverInst);
            if(GameUiInst != null) Object.Destroy(GameUiInst);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            Cursor.lockState = CursorLockMode.Locked;
        }

        public static void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
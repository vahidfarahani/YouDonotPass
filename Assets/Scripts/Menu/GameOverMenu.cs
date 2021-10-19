using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

namespace Menu
{
    public class GameOverMenu : MonoSingleton<GameOverMenu>, IMenu
    {
        public Text Score;
        public Text HighScore;
        public Button Reset;
        public Button ReturnToHome;

        public void Start()
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            Score.text = string.Format("Score: {0}", GameManager.Instance.Score.ToString());
            HighScore.text = string.Format("High Score: {0}", highScore.ToString());
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Restart()
        {
            PlayerPrefs.SetInt("Reset", 1);
            SceneManager.LoadScene(0);
        }

        public void Return()
        {
            SceneManager.LoadScene(0);
        }
    }
}
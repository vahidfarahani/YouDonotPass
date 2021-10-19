using UnityEngine;
using UnityEngine.UI;
using Utility;

// Start is called before the first frame update
namespace Menu
{
    public class GameHomeMenu : MonoSingleton<GameHomeMenu>, IMenu
    {
        public Text HighScore;
        public Button Play;

        void Start()
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            HighScore.text = string.Format("High Score\n{0}", highScore.ToString());

            int isReset = PlayerPrefs.GetInt("Reset", 0);
            if (isReset == 1)
            {
                PlayerPrefs.SetInt("Reset", 0);
                PlayPressed();
            }
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void PlayPressed()
        {
            Hide();
            GameManager.Instance.Show();
        }

    }
}

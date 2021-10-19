using Menu;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Weapon;

namespace Menu
{
    public class GameManager : MonoSingleton<GameManager>, IMenu
    {
        public int Score;
        public Text ScoreText;
        public int Life;
        public Text LifeText;
        public ToggleGroup WeaponGroup;
        public WeaponManager PlayerWeapons;
        public EnemyManager EnemyManager;

        List<Toggle> allToggles;

        void Start()
        {
            ScoreText.text = Score.ToString();
            LifeText.text = Life.ToString();
            allToggles = new List<Toggle>(WeaponGroup.GetComponentsInChildren<Toggle>());
        }

        public void IncrementScore()
        {
            Score++;
            ScoreText.text = Score.ToString();
            var activeWeapons = PlayerWeapons.SetActive(Score);
            foreach (var weapon in activeWeapons)
            {
                allToggles.Find(w => w.name == weapon.ToString()).interactable = true;
            }
        }
        public void WeaponSelected(bool value)
        {
            List<Toggle> activeToggles = new List<Toggle>(WeaponGroup.ActiveToggles());

            foreach (Toggle toggle in activeToggles)
            {
                Enum.TryParse(toggle.name, out WeaponType o);

                PlayerWeapons.ChangeWeapon(o);
            }
        }

        public void DecrementLife()
        {
                Life--;
                LifeText.text = Life.ToString();
                if (Life == 0)
                {
                    SaveAndExit();
                }
        }

        private void SaveAndExit()
        {
            SaveHighScore();
            Hide();
            GameOverMenu.Instance.Show();
        }

        private void SaveHighScore()
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            if (Score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", Score);
                PlayerPrefs.Save();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            EnemyManager.StopSpawn();
            gameObject.SetActive(false);
        }
    }
}

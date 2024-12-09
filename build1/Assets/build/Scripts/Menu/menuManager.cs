using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class menuManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject optionMenu;
        [SerializeField] private GameObject gameMenu;
        [SerializeField] private GameObject controlsmenu;
    
        Scene scene;

        void Start()
        {

            scene = SceneManager.GetActiveScene();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SceneManager.LoadScene("GameCheat");
            }
            if (gameMenu.activeSelf == false && (scene.name == ("level1") || scene.name == ("level2") || scene.name == ("level3")) && Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                gameMenu.SetActive(true);
            }
            else if (optionMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
            {
                optionMenu.SetActive(false);
                gameMenu.SetActive(true);
            }
            else if (gameMenu.activeSelf == true && (scene.name == ("level1") || scene.name == ("level2") || scene.name == ("level3")) && Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                gameMenu.SetActive(false);
            }


        }


        public void Play()
        {
            SceneManager.LoadScene("cutscene");

            Score.counter = 0;
            Score.scoreValue = 0;
            Score.killCounterValue = 0;
            PlayerLife.ignore = true;
            WinCondition.chances = 3;
            WinCondition.i = 0;
        }


        public void Audio()
        {
            optionMenu.SetActive(true);
        }

        public void Resume()
        {
            Time.timeScale = 1;
            gameMenu.SetActive(false);
        }

        public void Options()
        {
            
            optionMenu.SetActive(true);
             controlsmenu.SetActive(false);
        }

        public void controls()
        {
           
            optionMenu.SetActive(false);
            controlsmenu.SetActive(true);
        }

        public void Exit()
        {
            
            Application.Quit();
        }
        public void NextLevel()
        {
            Score.killTimer = 0f;
            if (scene.name == ("level1"))
            {
                SceneManager.LoadScene("level2");
                WinCondition.i = 0;
            }
            else if (scene.name == ("level2"))
            {
                WinCondition.i = 0;
                SceneManager.LoadScene("level3");
            }
            else if (scene.name == ("level3"))
            {
                WinCondition.i = 0;
                SceneManager.LoadScene("Credits");
            }
        }
        public void Back()
        {
            if (scene.name == ("MainMenu"))
            {
                controlsmenu.SetActive(false);
                mainMenu.SetActive(true);
                optionMenu.SetActive(false);
                
            }
            else if (scene.name == ("level1"))
            {
                controlsmenu.SetActive(false);
                optionMenu.SetActive(false);
                gameMenu.SetActive(true);
                
            }
            else if (scene.name == ("level2"))
            {
                controlsmenu.SetActive(false);
                optionMenu.SetActive(false);
                gameMenu.SetActive(true);
            }
            else if (scene.name == ("level3"))
            {
                controlsmenu.SetActive(false);
                optionMenu.SetActive(false);
                gameMenu.SetActive(true);
            }

        }
        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }

    }
}

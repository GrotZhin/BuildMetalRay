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
            mainMenu.SetActive(false);
            optionMenu.SetActive(true);
        }

        public void Exit()
        {
            Debug.Log("kitou");
            Application.Quit();
        }
        public void NextLevel()
        {
            Score.killTimer = 0f;
            SceneManager.LoadScene("level2");
        }
        public void Back()
        {
            if (scene.name == ("MainMenu"))
            {
                mainMenu.SetActive(true);
                optionMenu.SetActive(false);
            }
            else if(scene.name == ("level1"))
            {
                optionMenu.SetActive(false);
                gameMenu.SetActive(true);
            } 
            else if(scene.name == ("level2"))
            {
                optionMenu.SetActive(false);
                gameMenu.SetActive(true);
            } 
            else if(scene.name == ("level3"))
            {
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

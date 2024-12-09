using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class Retry : MonoBehaviour
    {
        Scene scene;
        public static int i;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                RetryGame();
            }
        }
        public void RetryGame()
        {
            scene = SceneManager.GetActiveScene();
            Score.counter = 0;
            Score.scoreValue = 0;
            Score.killCounterValue = 0;
            SceneManager.LoadScene(scene.name);
            PlayerLife.ignore = true;
            WinCondition.chances = 3;
            WinCondition.i = 0;




        }
    }
}
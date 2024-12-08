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
        public void RetryGame()
        {
            scene = SceneManager.GetActiveScene();
            if (i == 1)
            {

                Score.counter = 0;
                Score.scoreValue = 0;
                Score.killCounterValue = 0;
                SceneManager.LoadScene("level1");
                PlayerLife.ignore = true;
            }
            else if (i == 2)
            {

                Score.counter = 0;
                Score.scoreValue = 0;
                Score.killCounterValue = 0;
                PlayerLife.ignore = true;
                SceneManager.LoadScene("level2");
            } else if (i == 3)
            {

                Score.counter = 0;
                Score.scoreValue = 0;
                Score.killCounterValue = 0;
                PlayerLife.ignore = true;
                SceneManager.LoadScene("level3");
            }


        }
    }
}

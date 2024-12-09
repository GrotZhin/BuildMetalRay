using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class WinCondition : MonoBehaviour
    {
        Scene scene;
        public static int i = 0;
        public GameObject winScreen;
        
         public static int chances = 3;
        float time = 0;
        float killtimer = 0;
        void Start()
        {
          i = 0;
          scene = SceneManager.GetActiveScene();
        }

        // Update is called once per frame
        void Update()
        {
             if (PlayerLife.die == true)
            {
                killtimer += Time.deltaTime;
              
            }
            if (killtimer >= 2)
            {
                SceneManager.LoadScene("lose");
                killtimer = 0f;
            }
            if (scene.name == ("level1") && i == 1)
            {
                 Retry.i = 1;

                 time += Time.deltaTime;
                 if (time >= 5f)
                 {
                    winScreen.SetActive(true);
                    time = 0;
                    i = 0;
                 }
                 
            }
             else if (scene.name == ("level2") && i == 2)
            {
                 Retry.i = 2;
                 time += Time.deltaTime;
                 if (time >= 5f)
                 {
                    SceneManager.LoadScene("win1");
                    time = 0;
                    i = 0;
                 }
            }
            else if (scene.name == ("level3") && i ==3)
            {
                Retry.i = 3;
                time += Time.deltaTime;
                if(time >= 5f)
                {
                    SceneManager.LoadScene("win1");
                    time= 0;    
                    i = 0;
                }

            }
        }
    }
}

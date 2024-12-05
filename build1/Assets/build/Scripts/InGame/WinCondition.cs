using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class WinCondition : MonoBehaviour
    {
        Scene scene;
        public static int i = 0;
        float time = 0;
        void Start()
        {
          scene = SceneManager.GetActiveScene();
        }

        // Update is called once per frame
        void Update()
        {
            if (scene.name == ("level1") && i == 1)
            {
                 Retry.i = 1;

                 time += Time.deltaTime;
                 if (time >= 5f)
                 {
                    SceneManager.LoadScene("win");
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

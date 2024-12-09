using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class gameCheat : MonoBehaviour
    {
        Scene scene;
        public static float cheatLife;
        void Start()
        {
            scene = SceneManager.GetActiveScene();
        }
        void Update()
        {
            if (scene.name == ("level1") && Input.GetKeyUp(KeyCode.F2))
            {
                SceneManager.LoadScene("level2");
            }
            else if (scene.name == ("level2") && Input.GetKeyUp(KeyCode.F2))
            {
                SceneManager.LoadScene("level3");
            }
            
            
        }


    }
}

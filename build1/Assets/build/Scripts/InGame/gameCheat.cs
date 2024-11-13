using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class gameCheat : MonoBehaviour
    {
        Scene scene;
        void Start()
        {
        scene = SceneManager.GetActiveScene();
        }

        // Update is called once per frame
        void Update()
        {
            if ( scene.name == ("level1") && Input.GetKeyDown(KeyCode.Tab))
            {
                SceneManager.LoadScene("level2");
            }
             if(scene.name == ("level2") && Input.GetKeyDown(KeyCode.Tab)){
                 SceneManager.LoadScene("level1");
            }
        }
    }
}

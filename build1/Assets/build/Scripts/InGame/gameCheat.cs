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
      
        }
        public void Level1()
        {
            SceneManager.LoadScene("level1");
        }
        public void Level2()
        {
            SceneManager.LoadScene("level2");
        }
      
        
    }
}

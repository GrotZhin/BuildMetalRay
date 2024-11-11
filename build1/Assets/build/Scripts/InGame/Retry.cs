using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class Retry : MonoBehaviour
    {
        public void RetryGame(){
            SceneManager.LoadScene("level1");
        }
    }
}

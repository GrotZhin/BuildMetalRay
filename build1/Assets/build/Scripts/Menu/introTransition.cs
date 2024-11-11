using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class introTransition : MonoBehaviour
    {

        public Animator tras;
        public float str;

        public GameObject canvas;

        void Start()
        {

            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            Invoke(nameof(Activateani), str);

        }

        // Update is called once per frame

        public void Endfadein()
        {

            SceneManager.LoadScene("MainMenu");
            tras.Play("fadeout");

        }

        public void Endfadeout()
        {
           
            Destroy(gameObject);
            Destroy(canvas);
            Debug.Log("sepafoi");

        }
        void OnDestroy()
        {
            Debug.Log("destruido");
        }
        void Activateani()
        {

            tras.enabled = true;

        }

    }
}

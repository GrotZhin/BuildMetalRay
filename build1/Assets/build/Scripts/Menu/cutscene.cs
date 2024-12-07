using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class cutscene : MonoBehaviour
    {
        public float timer;
        public float dur;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= dur)
            {
                SceneManager.LoadScene("level1");
            }
        
        }
    }
}

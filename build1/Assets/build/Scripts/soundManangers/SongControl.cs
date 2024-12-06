using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

namespace MetalRay
{
    public class SongControl : MonoBehaviour
    {
        public AudioSource[] songs;

        float time;
        bool toggle;
        
        void Start()
        {

            toggle = true;
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;

            for (int i = 0; i < songs.Length; i++)
            {
                if (toggle == true)
                {
                    songs[i].Play();
                    toggle = false;
                }
                toggle = true;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

namespace MetalRay
{
    public class SongControl : MonoBehaviour
    {
        public AudioSource[] songsLoop;
        public AudioSource[] song;

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
            if(time >= 5)
            {
                Stop();
            }


            if (song[song.Length - 1].isPlaying == false && toggle == true)
            {
                Loop();
                toggle = false;
            }

        }
        public void Loop()
        {
            for (int i = 0; i < songsLoop.Length; i++)
            {
                songsLoop[i].Play();
            }
        }
        public void Stop()
        {
            for (int i = 0; i < song.Length; i++)
            {
                song[i].Pause();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class ChorusPowerUp : MonoBehaviour
    {
        public static bool active;
        public GameObject model;
        float time;
        void OnTriggerEnter(Collider other)
        {
           
            active = true;
            if (active == true)
            {
                volumeSettings.volume.ChorusSongOn();
                volumeSettings.volume.DefaultSongOff();
            }


            if (other.gameObject.CompareTag("Player"))
            {
                Weapon.j = 1;
                Destroy(model);
            }

        }

        void Update()
        {
            if (active == true)
                Debug.Log(active);
            {
                time += Time.deltaTime;
                
                if (time >= 10f)
                {
                    Weapon.j = 0;
                    active = false;
                    Debug.Log(active);
                    time = 0;
                    Destroy(this.gameObject);
                }

            }
            if (active == false)
            {
                volumeSettings.volume.DefaultSongOn();
                volumeSettings.volume.ChorusSongOff();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class ReverbPowerUp : MonoBehaviour
    {
        public static bool active;
        public GameObject model;

         public ParticleSystem vfx;
         public ParticleSystem vfx2;
         public ParticleSystem vfx3;
         float time;

        void OnTriggerEnter(Collider other)
        {
            active = true;
            if (active == true)
            {
                volumeSettings.volume.ReverbSongOn();
                volumeSettings.volume.DefaultSongOff();
            }


            if (other.gameObject.CompareTag("Player"))
            {
                enemyShoot.speed = 1.5f;
                Destroy(model);
                Instantiate(vfx, transform.position, Quaternion.identity);
                Instantiate(vfx2, transform.position, Quaternion.identity);
                Instantiate(vfx3, transform.position, Quaternion.identity);
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
                    enemyShoot.speed = 3;
                    active = false;
                    Debug.Log(active);
                    time = 0;
                    Destroy(this.gameObject);
                }

            }
            if (active == false)
            {
                volumeSettings.volume.DefaultSongOn();
                volumeSettings.volume.ReverbSongOff();
            }
        }
    }
}

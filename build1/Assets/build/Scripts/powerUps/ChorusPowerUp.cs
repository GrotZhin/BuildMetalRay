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

        
        public new BoxCollider collider;
        float time;
        void OnTriggerEnter(Collider other)
        {
            time = 0f;
            active = true;
            if (active == true)
            {
                volumeSettings.volume.ChorusSongOn();
                volumeSettings.volume.DefaultSongOff();
            }


            if (other.gameObject.CompareTag("Player"))
            {
                Weapon.j = 1;
                soundManager.PlaySound(SoundType.CHORUS);
                Destroy(model);
                collider.enabled = false;
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

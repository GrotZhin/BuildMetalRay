using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class DelayPowerUp : MonoBehaviour
    {
        public static bool active;
        public GameObject model;
         public new BoxCollider collider;
        public static float time;
        void OnTriggerEnter(Collider other)
        {
            
            time = 0f;
            active = true;
            if (active == true)
            {
                volumeSettings.volume.DelayOn();
                volumeSettings.volume.DefaultSongOff();
            }


            if (other.gameObject.CompareTag("Player"))
            {
                Weapon.fireRate = 0.1f;
                soundManager.PlaySound(SoundType.DELAY);
                Destroy(this.gameObject);
                collider.enabled = false;
                
            }

        }

     
    }
}

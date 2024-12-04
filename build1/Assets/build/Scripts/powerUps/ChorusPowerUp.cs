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
        public static float time;
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
                Destroy(gameObject);
                
            }

        }

    
    }
}

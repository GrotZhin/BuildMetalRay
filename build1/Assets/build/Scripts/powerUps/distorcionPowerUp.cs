using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
  public class distorcionPowerUp : MonoBehaviour
  {
    public static bool active;
    public GameObject model;

    public new BoxCollider collider;
    public static float timer;
    void OnTriggerEnter(Collider other)
    {
      
      timer = 0f;
      active = true;
      soundManager.PlaySound(SoundType.DISTORCION);
      if (active == true)
      {
        volumeSettings.volume.DistorcionSongOn();
        volumeSettings.volume.DefaultSongOff();
      }


      if (other.gameObject.CompareTag("Player"))
      {
        Weapon.i =1;
        Destroy(this.gameObject);
        collider.enabled = false;
      }

    }

   
  }
}

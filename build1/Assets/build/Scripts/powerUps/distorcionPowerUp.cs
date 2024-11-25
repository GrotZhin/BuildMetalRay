using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
  public class distorcionPowerUp : MonoBehaviour
  {
    public bool active;
    void OnTriggerEnter(Collider other)
    {
      Weapon weapon = other.GetComponent<Weapon>();
      volumeSettings volume = other.GetComponent<volumeSettings>();
      active = true;

      if (active == true)
      {
        volumeSettings.volume.DistorcionSongOn();
        volumeSettings.volume.DefaultSongOff();
      }
      else if (active == false)
      {
        volumeSettings.volume.DefaultSongOn();
        volumeSettings.volume.DistorcionSongOff();
      }
      if (other.gameObject.CompareTag("Player"))
      {
        weapon.DistorcionPowerUp();

        Destroy(this.gameObject);
      }



    }
  }
}

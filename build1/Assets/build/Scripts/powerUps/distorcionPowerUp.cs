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
    void OnTriggerEnter(Collider other)
    {
      Weapon weapon = other.GetComponent<Weapon>();

      active = true;
      if (active == true)
      {
        volumeSettings.volume.DistorcionSongOn();
        volumeSettings.volume.DefaultSongOff();
      }


      if (other.gameObject.CompareTag("Player"))
      {
        weapon.DistorcionPowerUp();

        Destroy(model);
      }

    }

    void Update()
    {
      if (active == false)
      {
        volumeSettings.volume.DefaultSongOn();
        volumeSettings.volume.DistorcionSongOff();
      }
    }
  }
}

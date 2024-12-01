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
    float timer;
    void OnTriggerEnter(Collider other)
    {
      
      Weapon weapon = other.GetComponent<Weapon>();
      timer = 0f;
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
        collider.enabled = false;
      }

    }

    void Update()
    {
      if (active == true)
      {
        timer += Time.deltaTime;
        if (timer >= 10f)
        {
          timer = 0;
          active = false;
          Weapon.i = 0;

          Destroy(this.gameObject);

        }

      }
      if (active == false)
      {
        volumeSettings.volume.DefaultSongOn();
        volumeSettings.volume.DistorcionSongOff();
      }
    }
  }
}

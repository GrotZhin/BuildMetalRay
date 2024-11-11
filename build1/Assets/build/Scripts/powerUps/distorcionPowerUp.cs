using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class distorcionPowerUp : MonoBehaviour
    {
        
        void OnTriggerEnter(Collider other)
        {
            Weapon weapon = other.GetComponent<Weapon>();
          if (other.gameObject.CompareTag("Player"))
          {
            weapon.DistorcionPowerUp();
             Destroy(this.gameObject);
          }
            
           

        }
    }
}

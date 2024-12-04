using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class PowerUpControl : MonoBehaviour
    {
       
       
        void Update()
        {
            if (ChorusPowerUp.active == true)
                Debug.Log(ChorusPowerUp.active);
            {
                ChorusPowerUp.time += Time.deltaTime;

                if (ChorusPowerUp.time >= 10f)
                {
                    Weapon.j = 0;
                    ChorusPowerUp.active = false;

                    ChorusPowerUp.time = 0;
                    
                }

            }
            if (ChorusPowerUp.active == false)
            {
                volumeSettings.volume.DefaultSongOn();
                volumeSettings.volume.ChorusSongOff();
            }
            if (DelayPowerUp.active == true)

            {
                DelayPowerUp.time += Time.deltaTime;

                if (DelayPowerUp.time >= 10f)
                {
                    Weapon.fireRate = 0.2f;
                    DelayPowerUp.active = false;
                    Debug.Log(DelayPowerUp.active);
                    DelayPowerUp.time = 0;
                  

                }

            }
            if (DelayPowerUp.active == false)
            {
                volumeSettings.volume.DefaultSongOn();
                volumeSettings.volume.DelayOff();

            }
            if (distorcionPowerUp.active == true)
            {
                distorcionPowerUp.timer += Time.deltaTime;
                if (distorcionPowerUp.timer >= 10f)
                {
                    distorcionPowerUp.timer = 0;
                    distorcionPowerUp.active = false;
                    Weapon.i = 0;
                    
                }

            }
            if (distorcionPowerUp.active == false)
            {
                volumeSettings.volume.DefaultSongOn();
                volumeSettings.volume.DistorcionSongOff();
            }

            if (ReverbPowerUp.active == true)
                Debug.Log(ReverbPowerUp.active);
            {
                ReverbPowerUp.time += Time.deltaTime;

                if (ReverbPowerUp.time >= 10f)
                {
                    enemyShoot.speed = 3;
                    ReverbPowerUp.active = false;
                    Debug.Log(ReverbPowerUp.active);
                    ReverbPowerUp.time = 0;
                    
                }

            }
            if (ReverbPowerUp.active == false)
            {
                volumeSettings.volume.DefaultSongOn();
                volumeSettings.volume.ReverbSongOff();
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class Combos : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ChorusPowerUp.active = true;
            DelayPowerUp.active = true;
            distorcionPowerUp.active = true;
            ReverbPowerUp.active = true;
        }


        void Update()
        {
            if (ChorusPowerUp.active == true && DelayPowerUp.active == true)
            {

            }
            else if(distorcionPowerUp.active == true && ReverbPowerUp.active == true)
            {

            }
            else if(DelayPowerUp.active = true && distorcionPowerUp.active == true)
            {

            }

        }
    }
}


using UnityEngine;

namespace MetalRay
{
    public class DropRate : MonoBehaviour
    {

        [SerializeField] GameObject[] powerUp;
        

        public void DropPowerUp()
        {
            var item = powerUp[Random.Range(0, powerUp.Length)];
            int dropRate = UnityEngine.Random.Range(0, 100);

            if (dropRate <= 20 && dropRate > 10)
            { 
                Instantiate(item, transform.position, Quaternion.identity);
            }else if (dropRate <= 10)
           
            {
                Instantiate(item, transform.position, Quaternion.identity);
                
            }

        }
    }
}

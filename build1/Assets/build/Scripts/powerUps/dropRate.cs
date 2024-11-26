
using UnityEngine;

namespace MetalRay
{
    public class DropRate : MonoBehaviour
    {

        [SerializeField] GameObject[] powerUp;
        [SerializeField] int dropChance;
        

        public void DropPowerUp()
        {
            var item = powerUp[Random.Range(0, powerUp.Length)];
            int dropRate = UnityEngine.Random.Range(0, 100);

            if (dropRate <= dropChance)
            { 
                Instantiate(item, transform.position, Quaternion.identity);
            }

        }
    }
}

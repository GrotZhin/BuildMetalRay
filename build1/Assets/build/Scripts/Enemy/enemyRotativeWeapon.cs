using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class enemyRotativeWeapon : MonoBehaviour
    {
        public GameObject RotativeShoot;
        public float bltlife = 1f;
        public float spd = 15f;
        public float fireRate = 0.75f;

        private GameObject spawnedRotShoot;
        public float timer = 0f;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
         timer += Time.deltaTime;
         transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
         if (timer >=fireRate)
         {
            Fire();
            timer = 0;
         }
        }
         public void Fire()
         {
            if(RotativeShoot)
            {
                spawnedRotShoot = Instantiate(RotativeShoot,transform.position,Quaternion.identity); 
                spawnedRotShoot.GetComponent<RotativeShoot>().spd = spd;
                spawnedRotShoot.GetComponent<RotativeShoot>().bltlife = bltlife;
                spawnedRotShoot.transform.rotation = transform.rotation;

            }

         }
    }
}

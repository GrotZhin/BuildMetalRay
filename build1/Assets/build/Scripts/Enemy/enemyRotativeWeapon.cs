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
        public float awakeTime;
        public bool left;
        public bool shootOn;

        private GameObject spawnedRotShoot;
        public float timer = 0f;

        void Start()
        {
            shootOn = false;
            if (left == true)
            {
                spd *= -1;
            }
        }

        // Update is called once per frame
        void Update()
        {
            awakeTime += Time.deltaTime;
            if (awakeTime >= 0.7f)
            {
                shootOn = true;
            }
            if (shootOn == true)
            {
                timer += Time.deltaTime;
                transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);

                if (timer >= fireRate)
                {
                    Fire();
                    timer = 0;
                }
            }
        }
        public void Fire()
        {
            if (RotativeShoot)
            {
                soundManager.PlaySound(SoundType.ROTATIVE);
                spawnedRotShoot = Instantiate(RotativeShoot, transform.position, Quaternion.identity);
                spawnedRotShoot.GetComponent<RotativeShoot>().spd = spd;
                spawnedRotShoot.GetComponent<RotativeShoot>().bltlife = bltlife;
                spawnedRotShoot.transform.rotation = transform.rotation;

            }

        }
    }
}

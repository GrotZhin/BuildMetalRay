using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class SpawnEnemy : MonoBehaviour
    {

        public GameObject[] enemyType;
        public GameObject subBoss;
        int i = 0;
        int j = 0;
        bool boss;

        public Transform spawn;

        void Start()
        {

            InvokeRepeating("Spawn", 1f, 4f);

        }

        void Spawn()
        {
            var random = enemyType[Random.Range(0, enemyType.Length)];
            var enemyTransform = Instantiate(random, spawn.transform);
            if (i >= 20 && j == 0)
            {
                Instantiate(subBoss, spawn.transform);
                
                j = 1;
            }
            i += 1;


           if (WinCondition.i >=1)
            {
                Destroy(this.gameObject);
            }

        }
    }

}
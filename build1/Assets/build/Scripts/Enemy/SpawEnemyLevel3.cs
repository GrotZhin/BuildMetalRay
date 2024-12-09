using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class SpawnEnemyLevel3 : MonoBehaviour
    {

        public GameObject[] enemyType;
        public GameObject Boss;
        public static GameObject bossInScreen;
        int i = 0;

        bool boss;

        public Transform spawn;

        void Start()
        {
            InvokeRepeating("Spawn", 1f, 4.5f);
            boss = true;

        }

        void Spawn()
        {
            var random = enemyType[Random.Range(0, enemyType.Length)];
            var enemyTransform = Instantiate(random, spawn.transform);
             
            if (WinCondition.i >=3)
            {
                Destroy(this.gameObject);
            }

        }
    }

}
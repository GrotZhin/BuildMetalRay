using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class SpawnEnemy : MonoBehaviour
    {

        public GameObject[] enemyType;

        public Transform spawn;

        void Start()
        {
            InvokeRepeating("Spawn", 1f, 5f);
        }

        void Spawn()
        {
            var random = enemyType[Random.Range(0, enemyType.Length)];

            var enemyTransform = Instantiate(random, spawn.transform);
        }
    }

}
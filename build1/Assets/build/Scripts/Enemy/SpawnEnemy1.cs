using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MetalRay
{
    public class SpawnEnemyLevel2 : MonoBehaviour
    {

        public GameObject[] enemyType;
        public GameObject subBoss;
        public static GameObject bossInScreen;
        int i = 0;

        bool boss;

        public Transform spawn;

        void Start()
        {
            InvokeRepeating("Spawn", 1f, 4.5f);

        }

        void Spawn()
        {
            var random = enemyType[Random.Range(0, enemyType.Length)];
            var enemyTransform = Instantiate(random, spawn.transform);
            if (i %15 == 0 && i!=0)
            {
                boss = true;
                Debug.Log(bossInScreen);
               
            }
           
            else if (boss == true && bossInScreen == null)
            {   
                
               bossInScreen = Instantiate(subBoss, spawn.transform);
                
                boss = false;
                
            }
            i += 1;
            Debug.Log(i);
            Debug.Log(bossInScreen);

            if (WinCondition.i >=2)
            {
                Destroy(this.gameObject);
            }

        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class lv1Meteors : MonoBehaviour
    {
        public GameObject [] meteors;
        public Transform reference;

        
        void Start()
        {
        InvokeRepeating("SpawnMeteor",1f, 3f);
        }

        // Update is called once per frame
    
        void SpawnMeteor()
        {
            var randomMeteor = meteors[Random.Range(0,meteors.Length)];
            float randomX = Random.Range(-2,2);
            Vector3 randomspawn = new Vector3(randomX, reference.position.y, 2.5f);
            
            Instantiate(randomMeteor, randomspawn, Quaternion.identity);
            
        }

        }
    }


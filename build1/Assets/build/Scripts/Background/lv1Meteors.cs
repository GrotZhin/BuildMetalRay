using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class lv1Meteors : MonoBehaviour
    {
        public GameObject [] meteors;

        float counter;
         public float timer;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
         counter +=Time.deltaTime;

        if (counter >= timer)
        {
            int randomIndex= Random.Range(0,meteors.Length);

            Vector3 randomspawn = new Vector3(Random.Range(-2,2),7,2);
            Instantiate(meteors[randomIndex],randomspawn,Quaternion.identity);
            counter =0;
        }


        }
    }
}

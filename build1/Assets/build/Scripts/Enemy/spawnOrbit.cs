using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class spawnOrbit : MonoBehaviour
    {
        public GameObject Orbit;
          public float xSpread;
         public float zSpread;   
         public float yOffset;
        // Start is called before the first frame update
        void Start()
        {
         
            for (int i = 0; i<4;i++){
            
           
            GameObject a =Instantiate(Orbit,transform.position,Quaternion.identity,this.transform);

             Enemy_mov_orbit temp = a.GetComponent<Enemy_mov_orbit>();
            temp.xSpread = xSpread;
            temp.zSpread = zSpread;
            temp.yOffset = yOffset;
            temp.centerPoint = this.transform;


            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

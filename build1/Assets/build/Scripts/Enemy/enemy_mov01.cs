using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class enemy_mov01 : MonoBehaviour
{
    public float spd = 1;
  
    private void FixedUpdate()
    {
        
        
        float move = -spd * Time.fixedDeltaTime;

        transform.Translate(0, move, 0);

        

    }
   
}

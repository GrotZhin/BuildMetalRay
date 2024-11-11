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
        Vector2 pos = transform.position;


        pos.y -= spd * Time.fixedDeltaTime;


        transform.position = pos;

    }
   
}

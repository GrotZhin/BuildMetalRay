using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class subBossMove : MonoBehaviour
{
    public float spd = 1;
    public bool move;
    int i = 0;

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (move == true && i < 5 )
        {
            pos.x -= spd * Time.fixedDeltaTime;
            if (pos.x <= -2)
            {
                move = false;
                i+=1;
            }

        }
        else if (move == false && i < 5 )
        {
            pos.x += spd * Time.fixedDeltaTime;
        
            if (pos.x >= 2)
            {
                move = true;
                i+=1;
            }
        }
        else if(i >= 5)
        {
        
        pos.y -= 20 * Time.fixedDeltaTime;
        //transform.position = new Vector3());
        i = 0;
        }

        transform.position = pos;
        
    }

}

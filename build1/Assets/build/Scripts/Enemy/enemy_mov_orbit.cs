using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
    public class Enemy_mov_orbit : MonoBehaviour
    {
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;
    float timer = 0;


    void Rotate() {
    float x = -Mathf.Cos(timer) * xSpread;
    float z = Mathf.Sin(timer) * zSpread;
    Vector3 pos = new Vector3(x,z , yOffset);
    transform.position = pos + centerPoint.position;

        }

    }
}

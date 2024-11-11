using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalRay
{
   public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float length;
    [SerializeField] private GameObject reference;

    private void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        Vector3 distance = reference.transform.position - transform.position;
        if (Mathf.Abs(distance.y) > length)
        {
            transform.Translate(0f, Mathf.Sign(distance.y) * length, 0f);
        }
    }
}
}

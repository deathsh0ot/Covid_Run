using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteRona : MonoBehaviour
{
     public int damage = 25;

   void OnTriggerEnter2D ( Collider2D hitInfo)
    {
        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi != null)
        {
            boi.TakeDamage(damage);
        }
    }
}

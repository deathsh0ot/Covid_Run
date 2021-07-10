using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    void OnTriggerEnter2D ( Collider2D hitInfo)
    {
        
        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi !=null)
        {
            boi.PickupFirstAid();
            Destroy(gameObject);
        }
        
    }
}

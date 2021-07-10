using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPickup : MonoBehaviour
{
     void OnTriggerEnter2D ( Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi !=null)
        {
            boi.PickUpMask();
            Destroy(gameObject);
        }
        
    }
}

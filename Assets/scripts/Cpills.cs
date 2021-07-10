using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cpills : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi != null)
        {
            Destroy(gameObject);
            boi.PickupCPills();

        }

    }
}

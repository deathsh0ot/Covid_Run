using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi != null)
        {
            boi.PickupBluePills();
            Destroy(gameObject);
        }

    }
}

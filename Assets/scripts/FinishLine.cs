using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
     void OnTriggerEnter2D ( Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi !=null)
        {
           SceneManager.LoadScene("GameWon");
        }
        
    }
}

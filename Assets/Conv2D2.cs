using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conv2D2 : MonoBehaviour
{
    public int progressUp;
    public GameObject narrator;
    private bool contact = false;
    public GameObject continueButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && contact == false)
        {
            narrator.GetComponent<Dialog>().progressNum += progressUp;
            contact = true;
        }
    }
}

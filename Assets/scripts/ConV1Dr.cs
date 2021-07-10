using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ConV1Dr : MonoBehaviour
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


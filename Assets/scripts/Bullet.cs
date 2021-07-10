using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 20;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        target = GameObject.FindGameObjectWithTag("Background");
    }

    void OnTriggerEnter2D ( Collider2D hitInfo)
    {
        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi != null)
        {
            boi.TakeDamage(damage);
        }
        if (hitInfo != target)
        {
            Destroy(gameObject);
        }
    }
}

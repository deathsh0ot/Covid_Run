using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BoiHealth boi = hitInfo.GetComponent<BoiHealth>();
        if (boi != null)
        {
            Destroy(gameObject);
            this.gameObject.SetActive(false);
            boi.TakeDamage(damage);
            
        }
    }
}

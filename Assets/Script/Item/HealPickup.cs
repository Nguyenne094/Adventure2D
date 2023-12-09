using UnityEngine;

public class HealPickup : MonoBehaviour
{
    private const uint healthRestore = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        Damageable damageable = other.GetComponent<Damageable>();

        if(damageable && damageable.Health != damageable.MaxHealth){
            damageable.Heal(healthRestore);
            Destroy(gameObject);
        }
    }
}

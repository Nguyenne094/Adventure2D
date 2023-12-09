using UnityEngine;

public class CherryPickup : MonoBehaviour
{
    Player player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(player){
            player.cherry++;
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private float degreePerSecons = 5f;

    private void FixedUpdate() {
        RotateAround();
    }

    private void RotateAround()
    {
        transform.Rotate(Vector3.up, degreePerSecons);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}

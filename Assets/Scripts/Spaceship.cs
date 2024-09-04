using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Projectile projectilePrefab;
    public float speed = 5f;

    void Update() {
        ApplyMovement();
        FireProjectile();
    }

    void ApplyMovement() {
        transform.Translate(Time.deltaTime * speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
    void FireProjectile() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}

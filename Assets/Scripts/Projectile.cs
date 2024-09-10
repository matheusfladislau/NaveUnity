using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Time.deltaTime * speed * new Vector3(0, 3f));
    }

    private void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}

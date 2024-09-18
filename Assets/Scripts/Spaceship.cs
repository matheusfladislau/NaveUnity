using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Bounds _cameraBounds;
    private SpriteRenderer _renderer;
    public Projectile projectilePrefab;
    public float speed = 5f;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        var height = Camera.main.orthographicSize * 2;
        var width = height * Camera.main.aspect;

        _cameraBounds = new Bounds(Vector3.zero, new Vector3(width, height));
    }

    private void LateUpdate() 
    {
        var spriteWidth  = _renderer.sprite.bounds.extents.x;
        var spriteHeight = _renderer.sprite.bounds.extents.y;

        var newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, _cameraBounds.min.x + spriteWidth, _cameraBounds.max.x - spriteWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, _cameraBounds.min.y + spriteHeight, _cameraBounds.max.y - spriteHeight);
        transform.position = newPosition;
    }

    void Update()
    {
        ApplyMovement();
        FireProjectile();
    }

    void ApplyMovement()
    {
        transform.Translate(Time.deltaTime * speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
    void FireProjectile()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}

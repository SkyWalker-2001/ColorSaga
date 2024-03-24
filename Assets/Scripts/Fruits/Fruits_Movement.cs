using UnityEngine;

public class Fruits_Movement : MonoBehaviour
{
    private Rigidbody2D _rb_Fruit;
    private SpriteRenderer _spriteRenderer_Fruit;

    public float directionY;

    private void Awake()
    {
        _rb_Fruit = GetComponent<Rigidbody2D>();
        _spriteRenderer_Fruit = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _rb_Fruit.velocity = new Vector2(0, directionY);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float lifeSpan;

    [SerializeField]
    private float projSpeed;

    private Vector2 projVelocity = Vector2.zero;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 dir)
    {
        projVelocity = dir * projSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (projVelocity != Vector2.zero)
        {
            rb.velocity = projVelocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (other.CompareTag("Boss"))
        {
            GameManager.Instance.BossTakeDamage(damage);
        }
    }
}

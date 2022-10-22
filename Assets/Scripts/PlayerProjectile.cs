using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float lifeSpan;
    private float time;

    [SerializeField]
    private float projSpeed;

    public bool fire;
    private bool fireOnce;

    private Vector2 projVelocity = Vector2.zero;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 dir)
    {
        rb.velocity = dir * projSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > lifeSpan)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;
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

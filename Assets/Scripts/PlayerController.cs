using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D bc;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [Tooltip("Set To Platforms!")]
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private Animator animator;

    private Vector3 localScale;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        localScale = transform.localScale;
    }

    private void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(body.velocity.x));

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        SwitchScale();

        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.Space))
            {
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(bc.bounds.center, Vector2.down, bc.bounds.extents.y + .5f, platformLayer);
        return hit.collider != null;
    }

    private void SwitchScale()
    {
        if (body.velocity.x > 0)
        {
            localScale.x = 1;
        }

        if (body.velocity.x < 0)
        {
            localScale.x = -1;
        }

        transform.localScale = localScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameManager manager;

    private Animator animator;

    public void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        if (transform.parent != null)
        {
            animator = transform.parent.GetComponent<Animator>();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (animator != null)
            {
                if (animator.GetBool("Moving"))
                {
                    return;
                }
            }

            manager.PlayerTakeDamage();
            //Debug.Log("here");
        }
    }

    //public void Update()
    //{
    //    transform.Translate(.05f, 0f, 0f);
    //}
}

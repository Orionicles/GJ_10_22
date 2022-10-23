using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameManager manager;

    public void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.PlayerTakeDamage();
            //Debug.Log("here");
        }
    }

    //public void Update()
    //{
    //    transform.Translate(.05f, 0f, 0f);
    //}
}

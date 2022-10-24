using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GameManager.PlayerDeath += PlayerDead;
        GameManager.BossDeath += PlayerCelebrate;
    }

    public void PlayerDead()
    {
        //animator.SetTrigger("Dead");
    }

    public void PlayerCelebrate()
    {
        // animator.SetTrigger("Celebrate")
    }

    public void PlayerJump()
    {
        //animator.SetTrigger("Jump")
        FindObjectOfType<AudioManager>().Play("Jump");
    }

    public void PlayerFall()
    {
        //animator.SetTrigger("Fall")
    }

    public void PlayerWalk()
    {
        //animator.SetTrigger("Walk")
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

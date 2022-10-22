using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GameManager.Instance.PlayerDeath += PlayerDead;
        GameManager.Instance.BossDeath += PlayerCelebrate;
    }

    public void PlayerDead()
    {
        //animator.SetTrigger("Dead");
    }

    public void PlayerCelebrate()
    {
        // animator.SetTrigger("Celebrate")
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

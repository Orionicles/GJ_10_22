using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // public elements
    public event Action PlayerDeath;
    public event Action BossDeath;

    [Tooltip("Player Icons")]
    public Image[] images;

    //Debugging elements (never mind them)
    public bool triggerDamage;
    private bool damagedOnce;

    private static GameManager instance;

    [Header("Health Components")]
    [SerializeField]
    private int playerHealth = 5;
    [SerializeField]
    private int bossHealth = 100;

    private bool playerDead;
    private bool bossDead;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public void PlayerTakeDamage()
    {
        if (!playerDead) 
        { 
            playerHealth--;

            images[playerHealth].enabled = false;

            if (playerHealth == 0)
            {
                PlayerDeath();
                playerDead = true;
            }
        }
    }

    public void BossTakeDamage(int damage)
    {
        if (!bossDead)
        {
            bossHealth -= damage;

            if (bossHealth <= 0)
            {
                BossDeath();

                // prevents extra calls to BossDeath
                bossDead = true;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerDamage && !damagedOnce)
        {
            PlayerTakeDamage();
            damagedOnce = true;
        }

        if (!triggerDamage)
        {
            damagedOnce = false;
        }
    }
}

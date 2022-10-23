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

    [SerializeField]
    [Tooltip("Player Icons")]
    private Image[] images;

    [SerializeField]
    private Slider bossHP;

    //Debugging elements (never mind them)
    public bool triggerDamage;
    private bool damagedOnce;
    public bool triggerBossDmg;
    private bool bDmgOnce;

    private static GameManager instance;

    [Header("Health Components")]
    [SerializeField]
    private int playerHealth = 5;
    [SerializeField]
    private int bossHealth = 100;
    private int maxBossHealth;

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

    public bool GetPlayerDead()
    {
        return playerDead;
    }

    public bool GetBossDead()
    {
        return bossDead;
    }

    public void PlayerTakeDamage()
    {
        if (!playerDead) 
        { 
            playerHealth--;
            FindObjectOfType<AudioManager>().Play("Hurt");
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

            bossHP.value = (float)bossHealth / maxBossHealth;

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
        FindObjectOfType<AudioManager>().Play("Gameplay Theme");
        maxBossHealth = bossHealth;
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

        if (triggerBossDmg && !bDmgOnce)
        {
            BossTakeDamage(1);
            bDmgOnce = true;
        }

        if (!triggerBossDmg)
        {
            bDmgOnce = false;
        }
    }
}

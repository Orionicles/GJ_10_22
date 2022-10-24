using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // public elements
    public static event Action PlayerDeath;
    public static event Action BossDeath;

    [SerializeField]
    [Tooltip("Player Icons")]
    private Image[] images;

    [SerializeField]
    private Slider bossHP;

    private static GameManager instance;

    [Header("Health Components")]
    [SerializeField]
    private int playerHealth = 5;
    [SerializeField]
    private int bossHealth = 100;
    private int maxBossHealth;

    private float iFrames = 2;
    private float time;
    private bool playerTakeDamage;

    private bool playerDead;
    private bool bossDead;

    public static GameManager Instance
    {
        get
        {
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
        if (!playerDead && playerTakeDamage) 
        { 
            playerHealth--;
            FindObjectOfType<AudioManager>().PlayOneShot("Hurt");
            images[playerHealth].enabled = false;
            playerTakeDamage = false;
            time = 0;

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

    public void PlayScooping()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Spoon");
    }

    public void PlayKnife()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Knife");
    }

    public void PlayGrab()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Grab");
    }

    public void PlaySaw()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Saw");
    }

    public void PlayFire()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("Fire");
    }


    // Start is called before the first frame update
    void Awake()
    {
        maxBossHealth = bossHealth;

        instance = this;
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Gameplay Theme");
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > iFrames)
        {
            playerTakeDamage = true;
        }
    }

}

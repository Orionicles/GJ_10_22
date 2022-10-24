using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool playerDead = false;
    public bool bossDead = false;
    public GameManager gameManager;

    private void Start()
    {
        if (gameManager != null)
        {
            GameManager.PlayerDeath += StartAgain;
            GameManager.BossDeath += End;
        }
    }

    void Update()
    {
        //if (GameManager.Instance != null)
        //{
        //    playerDead = GameManager.Instance.GetPlayerDead();
        //    bossDead = GameManager.Instance.GetBossDead();
        //}
        
        //if (playerDead)
        //{
        //    StartAgain();
        //}

        //if (bossDead)
        //{
        //    SceneManager.LoadScene("end");
        //}

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("UI");
            SceneManager.LoadScene("main menue");
        }
    }

    public void End()
    {
        Debug.Log("Ending");
        StartCoroutine(LoadLevel(2));
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelIndex);
    }
}

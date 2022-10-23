using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool playerisalive = true;
    public bool bossIsAlive = true;
    public GameManager gameManager;
    void Update()
    {
        playerisalive = GameManager.Instance.GetPlayerDead();
        bossIsAlive = GameManager.Instance.GetBossDead();
        
        if (playerisalive == false)
        {
            StartAgain();
        }

        if (bossIsAlive == false)
        {
            SceneManager.LoadScene("end");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("UI");
            SceneManager.LoadScene("main menue");
        }
    }
    public void StartAgain()
    {
        SceneManager.LoadScene("Sample Scene");
    }
    public void LoadNextLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelIndex);
    }
}

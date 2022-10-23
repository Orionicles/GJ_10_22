using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Menu Theme");
    }
    public void PlayGame ()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void CreditsScene ()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        SceneManager.LoadScene("Credits");
    }
}

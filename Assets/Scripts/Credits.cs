using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Credits Theme");
    }
    public void MainMenu ()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        SceneManager.LoadScene("main menue");
    }
}

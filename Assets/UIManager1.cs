using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager1 : MonoBehaviour
{

    public AudioSource clip;   
    public GameObject optionPanel;
    public void OptionPanel()
    {
        Time.timeScale = 0;
        optionPanel.SetActive(true);

    }
    public void Return()
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false);
    }
    public void AnotherOptions()
    {
        // Sound Graphics etc...
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlaySoundButton()
    {
        clip.Play();

    }
}

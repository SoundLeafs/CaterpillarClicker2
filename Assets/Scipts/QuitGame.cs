using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    [SerializeField] GameObject _showCredits;

    public void Start()
    {
        _showCredits.SetActive(false);
    }

    public void ShowCredits()
    {
        _showCredits.SetActive(true);
    }

    public void HideCredits()
    {
        _showCredits.SetActive(false);
    }

    public void PlayGame(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }

}

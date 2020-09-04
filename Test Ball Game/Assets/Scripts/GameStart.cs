using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject firstMenu;
    public GameObject SecondMenu;
   

    // Start is called before the first frame update
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void UiElementsToggle()
    {
        firstMenu.gameObject.SetActive(false);
        SecondMenu.gameObject.SetActive(true);
    }
    public void CreditsToMenu()
    {
        SecondMenu.gameObject.SetActive(false);
        firstMenu.gameObject.SetActive(true);
    }
   
}

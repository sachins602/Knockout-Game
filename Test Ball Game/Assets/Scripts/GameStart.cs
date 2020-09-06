using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject FirstMenu;
    public GameObject SecondMenu;
    public GameObject GoogleMenu;
   

    // Start is called before the first frame update
    public void PlayGame()
    {
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
    public void QuitGame()
    {
        Application.Quit();
    }
    /*public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }*/
    public void UiElementsToggle()
    {
        FirstMenu.gameObject.SetActive(false);
        SecondMenu.gameObject.SetActive(true);
    }
    public void CreditsToMenu()
    {
        SecondMenu.gameObject.SetActive(false);
        FirstMenu.gameObject.SetActive(true);
    }
    public void GoogleStuffButton()
    {
        FirstMenu.gameObject.SetActive(false);
        SecondMenu.gameObject.SetActive(false);
        GoogleMenu.gameObject.SetActive(true);
        
    }
   
}

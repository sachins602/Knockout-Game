using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject FirstMenu;
    public GameObject SecondMenu;
    //public GameObject SkinMenu;
   

    // Start is called before the first frame update
    public void PlayGame()
    {
        
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AdManager.instance.HideBannerAd();
        Time.timeScale = 1;
        Debug.Log("Scene Change Code Is running");

    }
  
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AdManager.instance.RequestBanner();
        AdManager.instance.ShowBannerAd();
    }
    public void MenuToCredits()
    {
        FirstMenu.gameObject.SetActive(false);
        SecondMenu.gameObject.SetActive(true);
       
    }
    public void CreditsToMenu()
    {
        SecondMenu.gameObject.SetActive(false);
        FirstMenu.gameObject.SetActive(true);
      //  SkinMenu.gameObject.SetActive(false);
      
    }
    public void GoogleStuffButton()
    {
        FirstMenu.gameObject.SetActive(false);
        SecondMenu.gameObject.SetActive(false);
  
        
    }
    public void SkinMenuPopUp()
    {
        FirstMenu.gameObject.SetActive(false);
        SecondMenu.gameObject.SetActive(false);
        //SkinMenu.gameObject.SetActive(true);
    }
   
}

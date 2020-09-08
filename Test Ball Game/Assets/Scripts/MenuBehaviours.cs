using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviours : MonoBehaviour
{
    public Button optionsButton;
    public Button exitButton;
    public Button googleButton;
    public Button noAdButton;
    public Button musicButton;
    public Button sfxButton;
    public Button skinsButton;
    public Button restartButton;
    public Button startButton;
    public Button creditsButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI waveCounterText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScoreText;

    public GameObject optionsCluster;
    public GameObject firstUi;
    public GameObject inGameUi;
    public GameObject gameOverUi;

    public Sprite optionsOpen;
    public Sprite optionsCollapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        firstUi.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void OnOptionsButtonPress()
    {
        if(optionsCluster.activeSelf == false)
        {
            optionsButton.GetComponent<Image>().sprite = optionsOpen;
            optionsCluster.SetActive(true);
        }
        else
        {
            optionsButton.GetComponent<Image>().sprite = optionsCollapsed;
            optionsCluster.SetActive(false);
        }
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        firstUi.SetActive(false);
        inGameUi.SetActive(true);
        gameOverUi.SetActive(false);
        Time.timeScale = 1;
    }
}

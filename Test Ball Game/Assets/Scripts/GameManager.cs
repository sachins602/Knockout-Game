using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public TextMeshProUGUI waveCounterText;
	public TextMeshProUGUI highScoreText;
	public TextMeshProUGUI finalScoreText;


	enum PageState
	{
		None,
		Start,
		Countdown,
		GameOver
	}

	//int score = 0;
	bool gameOver = true;

	public bool GameOver { get { return gameOver; } }

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void OnEnable()
	{
		PlayerController.OnPlayerDied += OnPlayerDied;
		PlayerController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}

	void OnDisable()
	{
		PlayerController.OnPlayerDied -= OnPlayerDied;
		PlayerController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
	}

	void OnCountdownFinished()
	{
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		gameOver = false;
	}

	void OnPlayerScored()
	{
		score++;
		scoreText.text = score.ToString();
	}

	void OnPlayerDied()
	{
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore)
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
		SetPageState(PageState.GameOver);
	}

	void SetPageState(PageState state)
	{
		switch (state)
		{
			case PageState.None:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Start:
				startPage.SetActive(true);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Countdown:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
				break;
			case PageState.GameOver:
				startPage.SetActive(false);
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
				break;
		}
	}

	public void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = "SCORE : " + score;
		finalScoreText.text = "SCORE : " + score;
		if (score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", score);
			highScoreText.text = "HIGHSCORE: " + score;
			//highScoreTextHome.text = "HIGHSCORE: " + score;
		}

	}

	public void ConfirmGameOver()
	{
		SetPageState(PageState.Start);
		scoreText.text = "0";
		OnGameOverConfirmed();
	}

	public void StartGame()
	{
		SetPageState(PageState.Countdown);
	}
	public void GameOver()
	{
		//spawnAudio.PlayOneShot(gameOverAudio, 1.0f);
		finalScoreText.gameObject.SetActive(true);
		scoreText.gameObject.SetActive(false);
		waveCounterText.gameObject.SetActive(false);
		restartButton.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(true);
		//mainMenuButton.gameObject.SetActive(true);
		highScoreText.gameObject.SetActive(true);
	}
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1;
	}
}

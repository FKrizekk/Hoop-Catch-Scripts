using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
	public GameObject ball;
	float timer = 1;
	public static bool gameOn = false;
	float startTime = 0;
	
	//SCORE STUFF
	public static int score = 0;
	public static int hScore = 0;
	public TMP_Text scoreText;
	public TMP_Text hScoreText;
	public TMP_Text menuHScoreText;
	
	//MENU STUFF
	public GameObject menuUI;
	public GameObject gameUI;
	
	public static void Save()
	{
		PlayerPrefs.SetInt("hScore", hScore);
	}
	
	void Load()
	{
		hScore = PlayerPrefs.GetInt("hScore", 0);
	}
	
	public void StartGame()
	{
		startTime = Time.time;
		gameOn = true;
		gameUI.SetActive(true);
		menuUI.SetActive(false);
	}
	
	public void StopGame()
	{
		score = 0;
		gameOn = false;
		menuUI.SetActive(true);
		gameUI.SetActive(false);
		var balls = FindObjectsOfType<GameObject>();
		foreach(var ball in balls)
		{
			if(ball.tag == "ball")
			{
				Destroy(ball);
			}
		}
	}
	
	void Start()
	{
		Load();
		StartCoroutine(Spawner());
	}
	
	void Update()
	{
		timer = 2-((Time.time-startTime)/40);
		if(gameOn)
		{
			scoreText.text = "Score: " + score;
			hScoreText.text = "HighScore: " + hScore;
		}else
		{
			menuHScoreText.text = "HighScore: " + hScore;
		}
	}
	
	IEnumerator Spawner()
	{
		if(gameOn)
		{
			SpawnBasketball();
		}
		yield return new WaitForSeconds(timer);
		StartCoroutine(Spawner());
	}
	
	void SpawnBasketball()
	{
		Instantiate(ball,new Vector3(Random.Range(-3f,3f),14.93f,0),Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f)));
	}
	
	public static void AddScore(int amount)
	{
		int newScore = score + amount;
		if(newScore > hScore)
		{
			hScore = newScore;
		}
		score = newScore;
		Save();
	}
}

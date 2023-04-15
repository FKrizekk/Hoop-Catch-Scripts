using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballScript : MonoBehaviour
{
	GameObject hoop;
	public GameObject scoreEffect;
	public GameObject badEffect;
	public GameControllerScript gameControl;
	
	void Start()
	{
		hoop = GameObject.Find("hoopEffectSpawn");
		gameControl = GameObject.Find("GameController").GetComponent<GameControllerScript>();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "ringDetect")
		{
			Caught();
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Lava")
		{
			NotCaught();
		}
	}
	
	void destroy()
	{
		Destroy(gameObject);
	}
	
	
	void NotCaught()
	{
		Instantiate(badEffect,gameObject.transform.position,Quaternion.identity);
		gameControl.StopGame();
		destroy();
	}
	
	void Caught()
	{
		Instantiate(scoreEffect,hoop.transform);
		GameControllerScript.AddScore(10);
		destroy();
	}
}

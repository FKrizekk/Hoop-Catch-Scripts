using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopScript : MonoBehaviour
{
	Vector2 deltaPos = new Vector2(0,0);
	
	float a = 100;
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.touches != null)
		{
			foreach(Touch touch in Input.touches)
			{
				if(touch.fingerId == 0)
				{
					//Get position since last frame
					deltaPos = touch.deltaPosition;
				}
			}
		}else
		{
			deltaPos = new Vector2(0,0);
		}
		
		
		
		
		float newPos = transform.position.x + deltaPos.x/a;
		if(newPos < 3 && newPos > -3 && GameControllerScript.gameOn)
		{
			transform.position = new Vector3(newPos, -20.65f, 4.76f);
		}
	}
}
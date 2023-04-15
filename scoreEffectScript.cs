using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy",1f);
    }

    void destroy()
    {
    	Destroy(gameObject);
    }
}

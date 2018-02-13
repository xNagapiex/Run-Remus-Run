using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    public float scrollSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(Vector3.up * scrollSpeed);
        
        if (transform.position.y >= 10.24f)
        {
            transform.position = new Vector3(transform.position.x, -10.24f, 2);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    float moveSpeed = 0.04f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(DestructionTimer());
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed);

        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestructionTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}


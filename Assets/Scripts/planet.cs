using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour {

    public AudioSource hitSound;
    public AudioSource explosionSound;
    public float moveSpeed;
    public int HP;
    GameObject GM;
    public int points;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("GameManager");
        hitSound = transform.GetComponent<AudioSource>();
        explosionSound = transform.GetChild(0).GetComponent<AudioSource>();

        if(Time.timeSinceLevelLoad > 80)
        {
            moveSpeed += 0.025f;
        }

        else if (Time.timeSinceLevelLoad > 60)
        {
            moveSpeed += 0.02f;
        }

        else if (Time.timeSinceLevelLoad > 40)
        {
            moveSpeed += 0.015f;
        }

        else if (Time.timeSinceLevelLoad > 20)
        {
            moveSpeed += 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            --HP;
            hitSound.Play();
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

            if (HP <= 0)
            {
                explosionSound.Play();
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GM.GetComponent<gamemanager>().AddToScore(points);
            }
        }
    }
}

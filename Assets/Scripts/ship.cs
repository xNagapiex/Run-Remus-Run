﻿using UnityEngine;
using System.Collections;

public class ship : MonoBehaviour
{
    public Rigidbody2D rb;
    bool dead = false;
    public float speed;
    public GameObject gameManager;
    public GameObject projectile;
    Vector3 projectileOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileOffset = new Vector3(0, 0.7f, 1);
        InvokeRepeating("Shoot", 0.01f, 0.1f);
    }

    void FixedUpdate()
    {
        if (!dead)
        {

            rb.velocity = new Vector3(Input.acceleration.x * speed, Input.acceleration.y * speed, 0);

            Vector3 accel = Input.acceleration;

            if (accel == new Vector3(0, 0, 0)) // For testing movement in Editor
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(mousePosition.x, mousePosition.y, 0),
                speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            CancelInvoke();
            dead = true;
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            gameManager.GetComponent<gamemanager>().PlayerDead();
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position + projectileOffset, Quaternion.identity);
    }
}
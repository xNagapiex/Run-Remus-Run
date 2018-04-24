using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ship : MonoBehaviour
{
    public Rigidbody2D rb;
    bool dead = false;
    Vector3 neutralAccel;
    public float speed;
    public GameObject gameManager;
    public GameObject projectile;
    Vector3 projectileOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileOffset = new Vector3(0, 0.7f, 1);
        Vector3 neutralAccel = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (!dead) // If not dead, take input and move accordingly
        {

            Vector3 accel = Input.acceleration - neutralAccel;

    //        testText.text = "Accel: " + System.Math.Round((decimal)Input.acceleration.x, 2) + ", " + System.Math.Round((decimal)Input.acceleration.y, 2) + ", " + System.Math.Round((decimal)Input.acceleration.z, 2) +
    //"\nNeutral: " + System.Math.Round((decimal)neutralAccel.x, 2) + ", " + System.Math.Round((decimal)neutralAccel.y, 2) + ", " + System.Math.Round((decimal)neutralAccel.z, 2) +
    //"\nMovement: " + System.Math.Round((decimal)accel.x, 2) + ", " + System.Math.Round((decimal)accel.y, 2) + ", " + System.Math.Round((decimal)accel.z, 2);

            if (neutralAccel.z >= 1)
            {
                accel = -(accel);
            }

            rb.velocity = new Vector3(accel.x * speed, accel.y * speed, 0);


            //if (accel == new Vector3(0, 0, 0)) // For testing movement in Editor
            //{
            //    Vector3 mousePosition = Input.mousePosition;
            //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(mousePosition.x, mousePosition.y, 0),
            //    speed * Time.deltaTime);
            //}
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

    public void SetNeutralAccel()
    {
        neutralAccel = Input.acceleration;
        gameManager.GetComponent<gamemanager>().AccelOK();
        InvokeRepeating("Shoot", 0.01f, 0.1f);
    }

    public void ResetNeutralAccel()
    {
        neutralAccel = Input.acceleration;
    }
}
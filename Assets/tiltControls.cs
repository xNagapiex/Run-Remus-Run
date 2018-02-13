using UnityEngine;
using System.Collections;

public class tiltControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.acceleration.x * speed, Input.acceleration.y * speed, 0);

        Vector3 accel = Input.acceleration;

        //if (accel == new Vector3(0, 0, 0)) // For testing movement in Editor
        //{
        //    Vector3 mousePosition = Input.mousePosition;
        //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(mousePosition.x, mousePosition.y, 0), 
        //    speed * Time.deltaTime);
        //}
    }
}
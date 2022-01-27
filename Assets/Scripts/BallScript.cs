using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 movement = new Vector2(1, 3);
    private Rigidbody2D rigidbodyComponent;
    private bool ballServed = false;

    public ScoringController scoringController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !ballServed)
        {
            ballServed = true;
        }
    }

    void FixedUpdate()
    {
        if (ballServed)
        {
            moveBall(movement);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCollide(collision);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            wallCollide(collision);
        }
        else if (collision.gameObject.tag == "Floor")
        {
            floorCollide(collision);
        }
        else
        {
            brickCollide(collision);
        }
    }

    void moveBall(Vector2 direction)
    {
        rigidbodyComponent.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void brickCollide(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        movement = Vector2.Reflect(movement, contact.normal);

        Destroy(collision.gameObject);
        scoringController.Score += 10;
    }

    void wallCollide(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        movement = Vector2.Reflect(movement, contact.normal);
    }

    void playerCollide(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Vector2 center = collision.collider.bounds.center;

        bool right = contact.point.x > center.x;
        bool left = contact.point.x < center.x;

        movement = Vector2.Reflect(movement, contact.normal);
    }

    void floorCollide(Collision2D collision)
    {
        scoringController.Lives--;
        ballServed = false;
        rigidbodyComponent.transform.position = new Vector2(0.25f, -4.65f);
    }
}

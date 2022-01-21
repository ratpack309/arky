using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = this.GetComponent<Rigidbody2D>();
        movement = new Vector2(0,-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        moveBall(movement);
    }

    void OnCollisionEnter2D()
    {
        ballCollide(movement);
    }

    void moveBall(Vector2 direction)
    {
        rigidbodyComponent.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void ballCollide(Vector2 direction)
    {
        movement = new Vector2(direction.x * -1, direction.y * -1);
    }
}

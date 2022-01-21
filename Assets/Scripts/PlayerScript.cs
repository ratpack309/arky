using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rigidbodyComponent.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}

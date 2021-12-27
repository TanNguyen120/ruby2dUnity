using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float timer = 10f;
    private bool vertical;
    private int direction;


    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        vertical = true;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveSet();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 5f;
            direction = -direction;
        }

    }

    void moveSet()
    {
        if (vertical)
        {
            Vector2 position = transform.position;
            position.y += speed * Time.deltaTime * direction;
            rigidBody.MovePosition(position);
        }
        else
        {
            Vector2 position = transform.position;
            position.x += speed * Time.deltaTime * direction;
            rigidBody.MovePosition(position);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ruby")
        {
            other.gameObject.GetComponent<RubyController>().reciveDamage(5);
        }
    }

}

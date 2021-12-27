using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    Rigidbody2D rigidBody;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidBody.MovePosition(position);
    }

    public void restoreHealth(int amount)
    {
        // Mathf clamp make sure health will not go above maxHealth
        health = Mathf.Clamp(health + amount, 0, maxHealth);


    }

    public void reciveDamage(int amount)
    {
        health -= amount;
    }

}

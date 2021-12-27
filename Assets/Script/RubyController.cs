using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    Rigidbody2D rigidBody;
    public float speed = 5f;

    public GameObject cog;

    Vector2 lookDirection = new Vector2(1, 0);

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHandles();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
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

    public void moveHandles()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidBody.MovePosition(position);
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(cog, rigidBody.position + Vector2.up * 0.5f, Quaternion.identity);

        CogController projectile = projectileObject.GetComponent<CogController>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float timer = 10f;
    public bool vertical;
    private int direction;

    private Animator animator;

    private bool broken = true;

    public ParticleSystem smokeEffect;


    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        vertical = true;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!broken)
        {
            return; //
        }
    }

    void FixedUpdate()
    {
        if (!broken)
        {
            return; //
        }
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
            // set animator state
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
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

    public void Fix()
    {

        broken = false;
        rigidBody.simulated = false;
        Debug.Log(smokeEffect.tag);
        smokeEffect.Stop();
    }

}

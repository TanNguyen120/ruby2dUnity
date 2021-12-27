using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        cleanCog();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        robotController e = other.collider.GetComponent<robotController>();
        if (e != null)
        {
            e.Fix();
        }
        Debug.Log("OnCollision: " + other.gameObject.tag);
        //we also add a debug log to know what the projectile touch
        Destroy(gameObject);
    }

    void cleanCog()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
}

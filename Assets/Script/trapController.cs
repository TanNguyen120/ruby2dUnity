using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ruby")
        {
            other.gameObject.GetComponent<RubyController>().reciveDamage(damage);
        }
    }
}

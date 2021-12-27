using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthRestore = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<RubyController>().restoreHealth(healthRestore);
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip collectedClip;
    public int healthRestore = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ruby")
        {
            other.gameObject.GetComponent<RubyController>().restoreHealth(healthRestore);
            other.gameObject.GetComponent<RubyController>().playPickUpSound(collectedClip);

            Destroy(gameObject);

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectVIda : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Vida"))
        {
            Destroy(other.gameObject);
        }
    }
}

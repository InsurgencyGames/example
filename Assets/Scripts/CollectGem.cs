using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }

    //void onTriggerEnter2D(Collider2D target) {
        //Debug.Log(target.gameObject.tag);
        //if (target.gameObject.tag == "player"){
        //    Destroy(gameObject);
      //  }
    //}
}

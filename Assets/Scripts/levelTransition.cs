using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour{

    public int index;
    public string levelName;


    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Mudanca")){
            //SceneManager.LoadScene(index);
            SceneManager.LoadScene(levelName);
        }
    }
}

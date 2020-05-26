using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite: MonoBehaviour{

    public Sprite[] sprites;

    void Start()
    {
        var myRender = GetComponent<SpriteRenderer>();

        if (sprites.Length >0){

            myRender.sprite = sprites[Random.Range(0, sprites.Length)];
            myRender.sortingOrder = Random.Range(-8, 8);
        }
    }
}

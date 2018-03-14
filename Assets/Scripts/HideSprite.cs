using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HideSprite : MonoBehaviour {

    public bool hideSpriteInGame = true;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = !hideSpriteInGame;
    }
}

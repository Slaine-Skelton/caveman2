using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text healthtext;
    public Text collectionText;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        healthtext.text = GetComponent<Health>().currentHealth.ToString();
        collectionText.text = GetComponent<CollectMatches>().matchCount.ToString();
    }
}

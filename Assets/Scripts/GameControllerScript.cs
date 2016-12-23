using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public Text HitText;
    public Text MissText;
    private static int countHit;
    private static int countMiss;

    // Use this for initialization
    void Start () {
        HitText.text = "Hit: " + countHit.ToString();
        MissText.text = "Miss: " + countMiss.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Hit()
    {
        countHit++;
        HitText.text = "Hit: " + countHit.ToString();
    }
    public void Miss()
    {
        countMiss++;
        MissText.text = "Miss: " + countMiss.ToString();
    }
}

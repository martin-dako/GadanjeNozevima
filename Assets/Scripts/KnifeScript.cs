using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeScript : MonoBehaviour {

	Vector3 knifeHit;
	Vector3 direction;
	public float KnifeSpeed; 
	private GameObject Player;
	private PlayerScript playerScript;
	public float RotateSpeed;
    public bool InitMove;
    private bool Move;
    private GameControllerScript gameControllerScript;
    public Text YouMissedText;
    

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("FPSController").GetComponentInChildren<PlayerScript>();   
		knifeHit = playerScript.knifeHit;
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        YouMissedText = GameObject.Find("YouMissedText").GetComponent<Text>();
        YouMissedText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (InitMove)
        {
            InitMove = false;
            direction = playerScript.direction;
            transform.rotation = Quaternion.LookRotation(direction);
            Move = true;           
        }
        if (Move)
        {
            //print("pomicem se");
            //print(direction);
            transform.Translate(direction * Time.deltaTime * KnifeSpeed, Space.World);
            transform.Rotate(Vector3.right, RotateSpeed * Time.deltaTime);
        }
        if (transform.position.magnitude > 25)
        {
           
            YouMissedText.text = "You missed!";
            StartCoroutine("WaitForEnd");
            
        }
        
	}

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSecondsRealtime(3);
        gameControllerScript.Miss();
        Application.LoadLevel("scena1");
    }
}

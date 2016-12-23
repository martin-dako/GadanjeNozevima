using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour {

    private GameObject Player;
    private PlayerScript playerScript;
    private Camera fpsCamera;
    public GameObject KnifePrefab;
    public GameObject GameController;
    private GameControllerScript gameControllerScript;
    public Text YouHitText;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("FPSController");
        playerScript = Player.GetComponentInChildren<PlayerScript>();  
        fpsCamera = Player.GetComponentInChildren<Camera>();
        gameControllerScript = GameController.GetComponent<GameControllerScript>();
        YouHitText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if ( collision.gameObject.tag == "Knife")
        {
            gameControllerScript.Hit();
            Destroy(collision.gameObject);
            YouHitText.text = "Hit!";
            StartCoroutine("WaitForEnd");
            //Destroy(transform.parent.gameObject);
            //playerScript.Knife = Instantiate(KnifePrefab, new Vector3(fpsCamera.transform.position.x + 3.68f, fpsCamera.transform.position.y - 3.86f, 1f), Quaternion.identity);
            //playerScript.KnifeRdy = 1;                  
        }
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSecondsRealtime(3);
        Application.LoadLevel("scena1");
    }
}

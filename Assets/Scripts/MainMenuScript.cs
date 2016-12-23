using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public Button PlayGameButton;
    public Button ExitGameButton;

	// Use this for initialization
	void Start () {
        PlayGameButton.onClick.AddListener(ClickAndPlay);
        ExitGameButton.onClick.AddListener(ClickAndExit);
	}
	
    void ClickAndPlay()
    {
        Application.LoadLevel("scena1");
    }

    void ClickAndExit()
    {
        Application.Quit();
    }
}

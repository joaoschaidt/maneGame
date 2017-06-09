using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startScene(int scenne)
    {
        Application.LoadLevel(scenne);
    }

    public void instrucoes()
    {
        Application.LoadLevel("instrucoes");
    }









    public void StartGame()
    {
        Application.LoadLevel("Game");

    }
}

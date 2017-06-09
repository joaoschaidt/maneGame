using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRight: MonoBehaviour {

    private Rigidbody2D corpoDireita;
    private Vector2 position;

    private float speedDireita;
    private float alturaCurvaDireita;
    private bool curveDireita = true;

    // Use this for initialization
    void Start () {
       
        corpoDireita = this.GetComponent<Rigidbody2D>();
        speedDireita = Random.Range(5.0f, 20.0f);
    }
	
	// Update is called once per frame
	void Update () {

            transform.position += Vector3.right * speedDireita * (Time.deltaTime);
        if (curveDireita==true) {
            speedDireita = Random.Range(1.0f, 10.0f);
            alturaCurvaDireita = Random.Range(7.0f, 15.0f);
            corpoDireita.velocity = new Vector2(corpoDireita.velocity.x, alturaCurvaDireita);
            curveDireita = false;
        }
    }
}

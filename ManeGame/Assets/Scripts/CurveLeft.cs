using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveLeft : MonoBehaviour {

    private Rigidbody2D corpoEsquerda;

    public float speedEsquerda;
    public float alturaCurvaEsquerda;
    public bool curveEsquerda = true;
 
    void Start () {

        corpoEsquerda = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.left * speedEsquerda * (Time.deltaTime);
        if (curveEsquerda == true) {
            speedEsquerda = Random.Range(1.0f, 10.0f);
            alturaCurvaEsquerda = Random.Range(7.0f, 15.0f);
            corpoEsquerda.velocity = new Vector2(corpoEsquerda.velocity.x, alturaCurvaEsquerda);
            curveEsquerda = false;
        }
    }

}

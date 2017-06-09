using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonus : MonoBehaviour {

    private float tempo = 0;
    private float tempoatualizado;
    private int cont = 1;
    public Transform prefabSpawn;
    public float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {

        tempoatualizado += (Time.time - startTime);


        if (tempoatualizado > tempo)
        {

            Instantiate(prefabSpawn, transform.position, Quaternion.identity);

            tempo = tempoatualizado + Random.Range(500, 1000);
        }

    }


}

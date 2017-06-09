using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class Controles : MonoBehaviour {

    private Rigidbody2D corpo;
    private bool jump;
    private Vector2 movimentoVector;
    public float forcaMovimento = 10;
    public float forcaPulo = 10;
    public SpriteRenderer imagem;
    private Animator anim;
    private Vector2 vectorApoio;
    public Text score;
    private float startTime;
    private bool perdeu;
    private bool chao=true;

    // Use this for initialization
    void Start () {
        perdeu = false;
        startTime = Time.time;
        corpo = this.GetComponent<Rigidbody2D>();
        imagem = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (perdeu==false)
        {
            score.text = (Time.time - startTime).ToString("0.0");
        }
        

        vectorApoio = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
           CrossPlatformInputManager.GetAxis("Vertical"));

        movimentoVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * forcaMovimento,
            CrossPlatformInputManager.GetAxis("Vertical"));

        jump = CrossPlatformInputManager.GetButton("Jump");

        corpo.AddForce(movimentoVector);

        if (vectorApoio.x > movimentoVector.x)
        {
            imagem.flipX = true;
        }
        else
        {
            imagem.flipX = false;
        }


        if (jump==true)
        {
            if (chao==true) {

                corpo.velocity = new Vector2(corpo.velocity.x, forcaPulo);
                chao = false;
                jump = false;
            }
        }

       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("barco"))
        {
            chao = true;
        }


        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            Application.LoadLevel("restart");

            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = false;
            }

            //nao para no ar por causa que a tainha usa gravidade -dynamic e nao kinematic
            /*foreach (CurveLeft curveleft in FindObjectsOfType<CurveLeft>())
            {
                curveleft.enabled = false;
            }*/

            foreach (SpawnerBonus spawner in FindObjectsOfType<SpawnerBonus>())
            {
                spawner.enabled = false;
            }
            perdeu = true;

            //SceneManager.LoadSceneAsync("Game");
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            Destroy(collision.gameObject);
            startTime -= 3;
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    public Transform verificaChao;
    public bool estaNoChao;
    public float velocidade;
    public float forcaPulo;
    public float raioVchao;
    public LayerMask solido;
    float movimento;
    public VariableJoystick variableJoystick;
    public Canvas canvas;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioVchao, solido);

        movimento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimento * velocidade, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.AddForce(tr.up * forcaPulo);

            estaNoChao = false;
        }
    }

    public void FixedUpdate()
    {

        rb.velocity = new Vector3(variableJoystick.Horizontal * velocidade, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "portal")
        {
            SceneManager.LoadScene("cena2");

            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(canvas);
            transform.position = new Vector2(-6, -1);
        }
    }
}


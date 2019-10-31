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
    public GameObject cameraCinematic;
    PlayerAnimator player;
    bool turnRight;

    void Start()
    {
        turnRight = true;
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        player = GetComponent<PlayerAnimator>();
    }
    public float Movimento { get; set; }
    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioVchao, solido);
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb.AddForce(tr.up * forcaPulo);

            estaNoChao = false;
        }
        if (movimento != 0 || variableJoystick.Horizontal != 0)
        {
            player.Walk();
        }
        else
        {
            player.Idle();
        }

        if ((movimento < 0 || variableJoystick.Horizontal < 0) && turnRight)
        {
            Flip();
        }
        else if ((movimento > 0 || variableJoystick.Horizontal > 0) && turnRight == false)
        {
            Flip();
        }
    }
    void Flip()
    {
        turnRight = !turnRight;
        tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
    }
    public void FixedUpdate()
    {
        movimento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimento * velocidade, rb.velocity.y);
        //rb.velocity = new Vector2(variableJoystick.Horizontal * velocidade, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "portal")
        {
            SceneManager.LoadScene("cena2");

            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(cameraCinematic);
            transform.position = new Vector2(-6, -1);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
}


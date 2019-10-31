using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    PlayerBehaviour player;
    //Controle de animação
    void Start()
    {
        player = GetComponent<PlayerBehaviour>();
        anim = GetComponent<Animator>();
    }
    public void Walk()
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
    }
    public void Idle()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject bola;
    public Vector2 mouse2;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            mouse2 = new Vector2(mouse.origin.x,mouse.origin.y);
            RaycastHit2D toque = Physics2D.Raycast(mouse2, Vector2.zero);
            if (toque.collider!=null&& toque.collider.gameObject.tag=="click")
            {
                Instantiate(bola, Vector3.Scale(mouse.origin, Vector3.one - Vector3.forward), Quaternion.identity);
            }
        }
    }
}

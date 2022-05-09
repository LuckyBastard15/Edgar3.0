using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2d : MonoBehaviour
{
    [Header("Configuracion de player")]
    public float velocidad;
    public float fuerzaSalto;

    [Header("Checador de suelo")]
    public Vector3 checkSuelopos;
    public float checkSueloRadio;
    bool estatocandoSuelo;
    public LayerMask checkSueloMask;
    bool agachado;


    Rigidbody2D RB;
    Animator anim;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        GoingLR();
        Crauch();
    }

    void Update()
    {
       
        Jump();
        
       
    }
    void Flip(float _dirx)
    {
        Vector3 localScale = transform.localScale;
        
        if(_dirx > 0f)
        {
            localScale.x = 1f;
        }
        else if(_dirx < 0f)
        {
            localScale.x = -1f;
        }
        transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + checkSuelopos, checkSueloRadio);
    }
    public void GoingLR()
    {
        if (!agachado)
        {
            Vector2 Vel = RB.velocity;
            Vel.x = Input.GetAxis("Horizontal") * velocidad;
            RB.velocity = Vel;
            anim.SetInteger("Velocidad", Mathf.FloorToInt(Mathf.Abs(Vel.x)));
            estatocandoSuelo = Physics2D.OverlapCircle(transform.position + checkSuelopos, checkSueloRadio, checkSueloMask);
            Flip(Vel.x);
        }
        else
        {
            agachado = true;
        }
        
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estatocandoSuelo && !agachado)
        {
            RB.AddForce(Vector2.up * fuerzaSalto);
            anim.SetTrigger("Jump");
        }
    }
    public void Crauch()
    {
        if (Input.GetKey(KeyCode.DownArrow) && estatocandoSuelo)
        {
            anim.SetTrigger("Crauch");
            agachado = true;
        }
        else
        {
            agachado = false;
        }
    }

}

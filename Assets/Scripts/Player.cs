using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad = 2.0f;
    [SerializeField] float velocidadSalto = 2.0f;
    private float xInicial, yInicial;
    private float alturaPlayer;
    private Animator anim;
    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPlayer = GetComponent<Collider2D>().bounds.size.y;
        anim = gameObject.GetComponent<Animator>();
        sonido = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(
                transform.position, new Vector2(0, -1));
        float distanciaSuelo = hit.distance;
        bool tocandoSuelo = distanciaSuelo < alturaPlayer;
        float horizontal = Input.GetAxis("Horizontal");

        if (tocandoSuelo && (horizontal > 0.1f))
        {
            anim.Play("PersonajeCorriendoDerecha");
        }
        else if (tocandoSuelo && (horizontal < -0.1f))
        {
            anim.Play("PersonajeCorriendoIzquierda");
        }
 
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        float salto = Input.GetAxis("Jump");

        if (salto > 0)
        {
            if (tocandoSuelo)
            {
                Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
                GetComponent<Rigidbody2D>().AddForce(fuerzaSalto);

                AudioSource.PlayClipAtPoint(sonido.clip,
                        Camera.main.transform.position);           
            }           
        }

        if (tocandoSuelo == false)
        {
            if (horizontal < 0)
                anim.Play("PersonajeSaltandoIzquierda");
            else
                anim.Play("PersonajeSaltando");
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}

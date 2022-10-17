using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad = 2.0f;
    [SerializeField] float velocidadSalto = 30.0f;
    private float xInicial, yInicial;
    private float alturaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPlayer = GetComponent<Collider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        float salto = Input.GetAxis("Jump");
        
        if (salto > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position, new Vector2(0, -1));
            float distanciaSuelo = hit.distance;
            
            bool tocandoSuelo = distanciaSuelo < alturaPlayer * 4/6;

            if (tocandoSuelo)
            {
                Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
                GetComponent<Rigidbody2D>().AddForce(fuerzaSalto);
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
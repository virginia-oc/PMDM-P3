using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    private float velocidad;
    private Vector3 siguientePosicion;
    private byte siguienteIndice = 0;
    private float distanciaCambio = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 2;
        siguientePosicion = wayPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            siguientePosicion,
            velocidad * Time.deltaTime);

        if (Vector3.Distance(
            transform.position, siguientePosicion) < distanciaCambio)
        {
            siguienteIndice++;

            if (siguienteIndice >= wayPoints.Count)           
                siguienteIndice = 0;
            
            siguientePosicion = wayPoints[siguienteIndice].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameController>().SendMessage("PerderVida");
    }
}

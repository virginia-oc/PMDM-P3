using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        sonido = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(sonido.clip,
                        Camera.main.transform.position);
        FindObjectOfType<GameController>().SendMessage("AnotarItemRecogido");
        Destroy(gameObject);
    }
}

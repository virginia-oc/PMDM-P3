using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int puntos;
    private int vidas;
    private int itemsRestantes;
    private int nivelActual;
    [SerializeField] TMPro.TextMeshProUGUI HUD;
    [SerializeField] TMPro.TextMeshProUGUI texto;
    [SerializeField] Transform prefabKey;

    // Start is called before the first frame update
    void Start()
    {
        itemsRestantes = FindObjectsOfType<Coin>().Length;
        puntos = FindObjectOfType<GameStatus>().puntos;
        vidas = FindObjectOfType<GameStatus>().vidas;
        nivelActual = FindObjectOfType<GameStatus>().nivelActual;
        texto.enabled = false;
        texto.text = "Game Over";
        HUD.text = "Puntos: " + puntos + "\n" +
            "Vidas: " + vidas;
        prefabKey.GetComponent<SpriteRenderer>().enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnotarItemRecogido()
    {
        puntos += 10;
        FindObjectOfType<GameStatus>().puntos = puntos;
        itemsRestantes--;
        
        if (itemsRestantes <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                AvanzarNivel();
            }
            else
            {
                prefabKey.GetComponent<AudioSource>().Play();
                prefabKey.GetComponent<SpriteRenderer>().enabled = true;
            }                  
        }

        HUD.text = "Puntos: " + puntos + "\n" +
            "Vidas: " + vidas;
    }

    public void PerderVida()
    {
        vidas--;
        FindObjectOfType<GameStatus>().vidas = vidas;

        HUD.text = "Puntos: " + puntos + "\n" +
            "Vidas: " + vidas;
        FindObjectOfType<Player>().SendMessage("ResetPosition");
        
        if (vidas <= 0)
        {
            TerminarPartida();
        }
    }

    private void AvanzarNivel()
    {      
        nivelActual++;
       
        if (nivelActual > FindObjectOfType<GameStatus>().nivelMasAlto)
        {
            texto.text = "Fin \n Puntuación obtenida: " + puntos;
            nivelActual = 1;
            TerminarPartida();
        }
        else
        {
            FindObjectOfType<GameStatus>().nivelActual = nivelActual;
            SceneManager.LoadScene("Level" + nivelActual);
        }
        
    }

    private void TerminarPartida()
    {
        StartCoroutine(VolverAlMenuPrincipal());
    }

    private IEnumerator VolverAlMenuPrincipal()
    {
        texto.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

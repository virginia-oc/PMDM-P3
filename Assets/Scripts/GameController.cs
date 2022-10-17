using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int puntos;
    private int vidas;
    [SerializeField] TMPro.TextMeshProUGUI HUD;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        vidas = 3;
        HUD.text = "Puntos: " + puntos + "\n" +
            "Vidas: " + vidas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnotarItemRecogido()
    {
        puntos += 10;
        HUD.text = "Puntos: " + puntos + "\n" +
            "Vidas: " + vidas;
    }

    public void PerderVida()
    {
        vidas--;
        HUD.text = "Puntos: " + puntos + "\n" +
            "Vidas: " + vidas;
        FindObjectOfType<Player>().SendMessage("ResetPosition");
        
        if (vidas <= 0)
        {
            //Pantalla de GameOver -> volver al menu principal
        }
    }
}

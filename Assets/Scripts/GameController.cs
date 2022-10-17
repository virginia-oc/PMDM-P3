using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int puntos;
    private int vidas;
    private int itemsRestantes;
    [SerializeField] TMPro.TextMeshProUGUI HUD;
    [SerializeField] Transform prefabKey;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        vidas = 3;
        itemsRestantes = FindObjectsOfType<Coin>().Length;
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
        itemsRestantes--;
        if (itemsRestantes <= 0)
        {
            Vector3 position = new Vector3(6.11f, -1.82f, 0f);
            Transform key = Instantiate(prefabKey, position, Quaternion.identity);
        }

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

    private void AvanzarNivel()
    {
        SceneManager.LoadScene("Level2");
    }
}

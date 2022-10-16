using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int puntos;
    [SerializeField] TMPro.TextMeshProUGUI HUD;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        HUD.text = "Puntos: " + puntos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnotarItemRecogido()
    {
        puntos += 10;
        HUD.text = "Puntos: " + puntos;
    }
}

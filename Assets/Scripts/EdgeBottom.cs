using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeBottom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Player>().SendMessage("ResetPosition");
    }
}

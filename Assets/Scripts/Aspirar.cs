using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspirar : MonoBehaviour
{
    public float velAbsorcion;
    public GameObject aspirador;
    private Vector3 dirAspiracion;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Mierda"))
        {
            dirAspiracion = other.transform.position - aspirador.transform.position;
            other.transform.Translate(dirAspiracion.normalized*velAbsorcion*Time.deltaTime, Space.World);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Mierda"))
        {
            Destroy(other.gameObject);

        }
    }
}

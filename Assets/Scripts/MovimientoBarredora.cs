using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoBarredora : MonoBehaviour
{
    Rigidbody myRigid;

    //Variables de movimiento
    public float vel;
    public float rotationVel;

    public bool workModeOn = false;

    //Variables Aspirar
    public float velAbsorcion;
    public GameObject aspirador;
    private Vector3 dirAspiracion;

    //UI
    public Text workModeText;

    //Referencia collider 
    public Collider areaAspiracion;

    //Shit Counter
    private float shitCounter = 0;





    void Start()
    {
        myRigid = GetComponent<Rigidbody>();

        areaAspiracion = GameObject.Find("RadioDeAccion").GetComponent<BoxCollider>();
    }


    void Update()
    {
        Controls();

        if (workModeOn)
        {
            WorkMode();
        }
        else
        {
            NormalMode();
        }

    }

    void Controls()
    {
        // The Machine movement

        if (Input.GetKey(KeyCode.W))
        {
            myRigid.AddRelativeForce(Vector3.forward * vel * Time.deltaTime, ForceMode.VelocityChange);

        }
        if (Input.GetKey(KeyCode.S))
        {
            myRigid.AddRelativeForce(-Vector3.forward * vel * Time.deltaTime, ForceMode.VelocityChange);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationVel * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationVel * Time.deltaTime);

        }

        //Enable, disable WorkMode

        if (Input.GetKeyDown(KeyCode.Q))
        {
            workModeOn = !workModeOn;
        }
    }

    void WorkMode()
    {

        vel = 20;
        rotationVel = 50;
        workModeText.enabled = true;

        areaAspiracion.enabled = true;
    }

    void NormalMode()
    {

        vel = 60;
        rotationVel = 30;
        workModeText.enabled = false;
        areaAspiracion.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Mierda")&&shitCounter<=10)
        {
            dirAspiracion = other.transform.position - aspirador.transform.position;
            other.transform.Translate(dirAspiracion.normalized * velAbsorcion * Time.deltaTime, Space.World);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("Mierda") && shitCounter <= 10)
        {
            Destroy(other.gameObject);
            ++shitCounter;
        }

        void Descargar()
        {


        }
    }
}

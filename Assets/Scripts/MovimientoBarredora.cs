using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBarredora : MonoBehaviour
{
    Rigidbody myRigid;

    //Variables de movimiento
    public float vel;
    public float rotationVel;

    public bool workModeOn = false;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
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
        Debug.Log("Work Mode On");
    }

    void NormalMode()
    {
        Debug.Log("Work Mode Off");

    }
}

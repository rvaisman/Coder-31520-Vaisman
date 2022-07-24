using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform posJugador;


    void LookAt()
    {

        this.transform.LookAt(posJugador);
        this.transform.Rotate(-5 , 0 , 0) ;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
        //transform.position = posJugador.transform.position + new Vector3(-75, 50, 75);
    }
}
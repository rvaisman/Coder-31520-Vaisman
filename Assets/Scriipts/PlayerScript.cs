using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static PlayerManager unicaInstancia;
    public GameObject _player;
    public Rigidbody playerRB;
    public float speed = 5;
    public Animator _playerAnimator;
    public GameObject enemy;
    public int vida = 10000; 


    private void OnTriggerEnter(Collider collision)
    {
        GameObject otherObject = collision.gameObject;
        //Debug.Log("Collision Enter with " + collision.gameObject.name);
        if (otherObject != null)
        {
            if (collision.gameObject.tag == "Spider" && _playerAnimator.GetBool("patea"))
            {
                //Debug.Log("Hit on  " + collision.gameObject.name);
                otherObject.GetComponent<SpiderFollow>().BajaVida(40);


            }
        }
    }



    private void OnTriggerStay(Collider collision)

    {
        GameObject otherObject = collision.gameObject;
        //Debug.Log("Collision Stay with " + collision.gameObject.name);


        if (otherObject != null)
        {
            if (otherObject.tag == "Spider" && _playerAnimator.GetBool("patea"))
            {
                //Debug.Log("Hit on  " + otherObject.name);
                otherObject.GetComponent<SpiderFollow>().BajaVida(40);


            }
        }

       
    }


    public bool IsDead()
    {

        if (vida <= 0)
        {
            _playerAnimator.SetBool("golpeado", true);
            _playerAnimator.SetBool("seMurio", true);
            return true;
        }
        else
        {
            return false;
        }

    }

    public void BajaVida(int hp)
    {
        vida -= hp;
        _playerAnimator.SetBool("golpeado", true);
        Debug.Log("Vida Player " + vida);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

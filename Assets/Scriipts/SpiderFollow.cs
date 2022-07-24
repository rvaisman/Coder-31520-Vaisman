using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFollow : MonoBehaviour
{
    public Transform transformJugador;

    [SerializeField] float enemySpeed = 5f;
    public Animator _spiderAnim;
    public Rigidbody rb;
    public float speed = 6;
    public int vida = 100; 

    

    void LookAt()
    {

        transform.LookAt(transformJugador);

    }


    float ChequearDistancia()
    {

        float dist = Vector3.Distance(transform.position, transformJugador.position);
        //Debug.Log(dist);
        return dist;

    }
    void SeguirJugador()
    {

        transform.position = Vector3.MoveTowards(transform.position, transformJugador.position, enemySpeed * Time.deltaTime);
            _spiderAnim.SetBool("isWalking", true); 
            _spiderAnim.SetBool("isAttacking", false);
            _spiderAnim.SetBool("isDead", false);
        
    }


    void AtacarJugador()
    {

        
            _spiderAnim.SetBool("isWalking", false);
            _spiderAnim.SetBool("isAttacking", true);
            _spiderAnim.SetBool("isDead", false);

        
    }


    private void OnCollisionEnter(Collision collision)
    {

        GameObject otherObject = collision.gameObject;


        if (otherObject != null)
        {
            if (collision.gameObject.name == "Maledetto" && _spiderAnim.GetBool("isAttacking"))
            {
                //Debug.Log("Hit on  " + collision.gameObject.name);
                otherObject.GetComponent<PlayerScript>().BajaVida(40);

            }
        }
           
    }


    private void OnCollisionStay(Collision collision)
    {

        GameObject otherObject = collision.gameObject;


        if (otherObject != null)
        {
            if (collision.gameObject.name == "Maledetto" && _spiderAnim.GetBool("isAttacking"))
            {
                //Debug.Log("Hit on  " + collision.gameObject.name);
                otherObject.GetComponent<PlayerScript>().BajaVida(40);

            }
        }
            
    }

    public bool IsDead()
    {

        if (vida <= 0)
        {
            _spiderAnim.SetBool("isDead", true);
            return true;
        } else
        {
            return false;
        }
        
    }

    public void BajaVida(int hp)
    {
        vida -= hp;
        Debug.Log("Vida Araña " + vida);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead() == false)
        {
            float distancia = ChequearDistancia();
            //Debug.Log("Distancia en Update: " + distancia);
            //MovimientoPlayer();

            LookAt();
            if (distancia > 5.4f)
            {
                SeguirJugador();
            }
            if (distancia <= 5.4f)
            {
                AtacarJugador();
            }

        }
        
    }
}

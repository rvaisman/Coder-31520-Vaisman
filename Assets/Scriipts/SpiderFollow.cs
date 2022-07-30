using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFollow : MonoBehaviour
{
    //public Transform transformJugador;

    public int numSpider;
    public Animator _spiderAnim;
    public GameObject _spider;
    public Rigidbody rb;
    public float speed = 5;
    public int vida = 100;
    public GameObject player;
    GameObject SceneMan;
    
    public int NumSpider()
    {
        string nameSpider = rb.name;
        int v = (int)char.GetNumericValue(nameSpider, 7);
        numSpider = v;
        //Debug.Log("Spider Num " + numSpider);
        return numSpider;
      
    }

    void ReportManager()
    {
        SceneMan = GameObject.FindWithTag("SceneManager");
        //SceneMan.GetComponent<SceneManager>().ListarSpider(NumSpider(), 1, IsDead(), transform.position, transform.rotation);

    }


    void LookAt()
    {

        transform.LookAt(player.transform);

    }


    float ChequearDistancia()
    {

        float dist = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(dist);
        return dist;

    }
    void SeguirJugador()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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

        //Debug.Log("Enter Coll on  " + collision.gameObject.tag);
        //if (otherObject != null)
       // {
            if (collision.gameObject.tag == "Player" && _spiderAnim.GetBool("isAttacking"))
            {
                //_spiderAnim.GetBool("isAttacking");
                otherObject.GetComponent<PlayerScript>().BajaVida(40);
                Debug.Log("Hit on  " + collision.gameObject.name);
                

            }
       // }
           
    }


    private void OnCollisionStay(Collision collision)
    {

        GameObject otherObject = collision.gameObject;
        //Debug.Log("Stay Coll on  " + collision.gameObject.tag);

        //if (otherObject != null)
        // {
        if (collision.gameObject.tag == "Player" && _spiderAnim.GetBool("isAttacking"))
        {
                //_spiderAnim.GetBool("isAttacking");
                Debug.Log("Hit on  " + collision.gameObject.name);
                otherObject.GetComponent<PlayerScript>().BajaVida(40);

            }
        //}
            
    }

    public bool IsDead()
    {

        if (vida <= 0)
        {
            _spiderAnim.SetBool("isDead", true);
            _spiderAnim.SetBool("isAttacking", false);
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
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        NumSpider();
        ReportManager();
        if (IsDead() == false)
        {
            float distancia = ChequearDistancia();
            //Debug.Log("Distancia en Update: " + distancia);
            //MovimientoPlayer();

            LookAt();
            if (distancia > 5.3f)
            {
                SeguirJugador();
            }
            if (distancia <= 5.3f)
            {
                SeguirJugador();
               AtacarJugador();
            }

        }
        
    }
}

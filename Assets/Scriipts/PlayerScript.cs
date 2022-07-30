using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject _player;
    public Rigidbody playerRB;
    public float speed = 5;
    public Animator _playerAnimator;
    public GameObject enemy;
    public int vida;
    GameObject SceneMan;

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

    public void SetPlayer()
    {

    }



    public void GetPlayer()
    {

    }

    void MovimientoPlayer(GameObject _Player)
    {
        Animator anim2 = _player.GetComponent<Animator>();
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(hor, 0, ver);


        if (inputPlayer == Vector3.zero)
        {


            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetBool("vaPatras", false);

        }
        else
        {


            if (ver > 0)
            {
                _playerAnimator.SetBool("isWalking", true);
                _playerAnimator.SetBool("vaPatras", false);
                speed = 7;
            }
            else if (ver < 0)
            {
                _playerAnimator.SetBool("isWalking", false);
                _playerAnimator.SetBool("vaPatras", true);
                speed = 3;
            }

            //Debug.Log("Hor: " + hor);
            //Debug.Log("Ver: " + ver);

        }

        if (Input.GetKeyDown(KeyCode.Space) /*|| Input.GetKey(KeyCode.Space) */)
        {
            _playerAnimator.SetBool("patea", true);

        }
        else
        {
            _playerAnimator.SetBool("patea", false);

        }

        _Player.transform.Translate(new Vector3(0, 0, ver) * speed * Time.deltaTime);
        _Player.transform.Rotate(new Vector3(0, hor, 0) * speed * 10 * Time.deltaTime);


    }

    public bool IsDead()
    {

        if (vida <= 0)
        {
            //_playerAnimator.SetBool("golpeado", true);
            _playerAnimator.SetBool("seMurio", true);
            return true;
        }
        else
        {
            return false;
        }

    }

    public void AlertObservers(string message)
    {
        if (message.Equals("HitAnimationEnded"))
        {
            _playerAnimator.SetBool("golpeado", false);
            //pc_anim.SetBool("attack", false);
            // Do other things based on an attack ending.
        }
    }
    public void BajaVida(int hp)
    {
        vida -= hp;
        _playerAnimator.SetBool("golpeado", true);
        Debug.Log("Vida Player " + _playerAnimator.GetBool("golpeado"));
        Debug.Log("Vida Player " + vida);
        SceneMan.GetComponent<EscenaManager>().vidaPlayer = vida;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead()) {
            MovimientoPlayer(_player);
        }
        
    }
}

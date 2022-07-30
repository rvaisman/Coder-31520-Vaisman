using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    
    public static PlayerManager unicaInstancia;
    public GameObject _player;
    public Rigidbody playerRB;
    public float speed = 7f;
    public Animator _playerAnimator;
    
   

    private void Awake()
    {
        Animator anim2 = _player.GetComponent<Animator>();        
        if (PlayerManager.unicaInstancia == null)
        {
            //Primera Instancia del Siungleton
            PlayerManager.unicaInstancia = this;
            DontDestroyOnLoad(gameObject);
            
        } else 
        {
            Destroy(gameObject);
        }
    anim2.enabled = true;

    }




    void MovimientoPlayer(GameObject _Player)
    {
    Animator anim2 = _player.GetComponent<Animator>();
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer= new Vector3 (hor, 0 , ver) ;
        

        if (inputPlayer == Vector3.zero)
        {


            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetBool("vaPatras", false);

        } else
        {
            
            
            if (ver > 0)
            {
                _playerAnimator.SetBool("isWalking", true);
                _playerAnimator.SetBool("vaPatras", false);
                speed = 7;
            } else if (ver < 0)
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
            
        } else
        {
            _playerAnimator.SetBool("patea", false);

        }
        
        _Player.transform.Translate(new Vector3(0, 0, ver) * speed * Time.deltaTime);
        _Player.transform.Rotate(new Vector3(0, hor, 0) * speed * 10 * Time.deltaTime);


    }

   

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPlayer(_player);
        
        

        
    }
}

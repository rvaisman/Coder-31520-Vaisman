using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaManager : MonoBehaviour
{
    public int vidaPlayer;
    public int currentScene;


    public GameObject _player;
    public GameObject spider;
    public Transform spawnPoint;
    int cantSpiders = 0;
    float timerSecs = 7f;

        
    public List<Spider> SpiderList = new List<Spider>();
    
    
    public static EscenaManager unicaInstancia;

    Scene y;

    private void Awake()
    {

        if (EscenaManager.unicaInstancia == null)
        {
            //Primera Instancia del Singleton
            EscenaManager.unicaInstancia = this;
            DontDestroyOnLoad(gameObject);
            _player.GetComponent<PlayerScript>().vida = 10000;

        }
        else
        {
            Destroy(gameObject);
        }



    }

    void soltarSpider(int Num)
    {
        GameObject spiderSuelta = Instantiate(spider, spawnPoint.position, spawnPoint.rotation);
        spiderSuelta.name = "Spider " + Num;
        
    }

    public void ListarSpider(int index, int level, bool isDead, Vector3 position, Vector3 rotation)
    {
        SpiderList.Insert(index, new Spider(level, isDead, position, rotation)); 
    }


   
 


    // Start is called before the first frame update
    void Start()
    {
         y = SceneManager.GetActiveScene();
        Debug.Log("LVL " + y.name);
        if (y.name == "LVL 1")
        {
            soltarSpider(cantSpiders);
            cantSpiders += 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("LVL 1", LoadSceneMode.Single);
            _player.GetComponent<PlayerScript>().vida = vidaPlayer;
            Debug.Log("Vida Player Sceneman " + vidaPlayer);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("LVL 2", LoadSceneMode.Single);
            _player.GetComponent<PlayerScript>().vida = vidaPlayer;
            Debug.Log("Vida Player Sceneman " + vidaPlayer);
        }

        y = SceneManager.GetActiveScene();
        Debug.Log("LVL " + y.name);

        if (y.name == "LVL 1")
        {
            timerSecs -= Time.deltaTime;
            //Debug.Log("Timer " + timerSecs);
            if (timerSecs <= 0 && cantSpiders <= 3)

            {
                soltarSpider(cantSpiders);
                Debug.Log("Cant Spiders " + cantSpiders);
                timerSecs = 7f;
                cantSpiders += 1;

            }


            
        }
        

       

    }
}

public class Spider : MonoBehaviour
{
    public int level;
    public bool isAlive;
    public Vector3 position;
    public Vector3 rotation;

    public Spider(int level, bool isAlive, Vector3 position, Vector3 rotation)

    {
        this.level = level;
        this.isAlive = isAlive;
        this.position = position;
        this.rotation = rotation;
    }


    public int  Level
    {
        get { return level; }
        set { level = value; }
    }

    public bool IsDead
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }
    public Vector3 Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }
}





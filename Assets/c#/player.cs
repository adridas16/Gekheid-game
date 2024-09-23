using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float velocidad = 4f;
    public float girar = 0.01f;
    Animator _animator;
    public GameObject CambioEscena;
    public GameObject EscenaPasillo;
    public GameObject Seguircamara;
    public GameObject Camara;
    public GameObject Cuboescena;
    public GameObject EnfermeraQuitar;
    public float Temporizadorcambioescena = 2;
    public float Temporizadorpasillo = 1.5f;
    public float Siguienteescena = 1.2f;
    float tiempoGrande = 1.1f;
    bool cambiotamaño = true;
    

    // Start is called before the first frame update
    void Start()
    {
        _animator= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        animator();
        Pasillo();
        agrandar();
        if (Siguienteescena <= 0)
        {
            //SceneManager.LoadScene(0);
            SceneManager.LoadScene(2);
            Debug.Log("funciona");
        }
    }
   

    void Movimiento()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * velocidad*Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -velocidad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.up * -velocidad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * velocidad * Time.deltaTime;
        }

        if (velocidad == 0)
        {
            Temporizadorcambioescena -= Time.deltaTime;
        }
        else if (velocidad == 0.01f)
        {
            Siguienteescena -= Time.deltaTime;
        }
        
 
    }
    void animator()
    {
        if (velocidad != 0.01f)
        {
            if (velocidad != 0)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    _animator.SetFloat(name: "MoveHorizontal", value: Input.GetAxis("Horizontal"));
                }
                else if (Input.GetAxis("Vertical") != 0)
                {
                    _animator.SetFloat(name: "MoveVertical", value: Input.GetAxis("Vertical"));
                }
            }
        }
       
            
    }

    void Pasillo()
    {
        
        if (Temporizadorcambioescena <= 0)
        {
            Camara.transform.position = new Vector3(14.1499996f, 22.0499992f, -1);
            transform.position = new Vector3(14.1499996f, 22.0499992f, -1);
            if (transform.position == new Vector3(14.1499996f, 22.0499992f, -1))
            {
                Seguircamara.SetActive(true);
                CambioEscena.SetActive(false);
                EscenaPasillo.SetActive(true);
                if (Temporizadorpasillo <= 0)
                {
                    velocidad = 4f;
                    EscenaPasillo.SetActive(false);
                    Temporizadorcambioescena = 2f;
                    EnfermeraQuitar.SetActive(true);
                    
                }
                
            }
        }
        
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Puerta")
        {
            velocidad = 0;

            CambioEscena.SetActive(true);

            


        }
        


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cambioescena")
        {
            Cuboescena.transform.localScale += new Vector3(0.01f, 0, 0);
            Temporizadorpasillo -= Time.deltaTime;
            tiempoGrande -= Time.deltaTime;
            Debug.Log("va colider");
            if (Temporizadorpasillo <= 0f)
            {
                Destroy(collision.gameObject);
                Debug.Log("va");
            }
            
        }
        
        if (collision.gameObject.tag == "Escenamedicinas")
        {

            velocidad = 0.01f;
           
            CambioEscena.SetActive(true);
            
        }
        

    }
    void agrandar()
    {
        if (tiempoGrande <= 0 &&cambiotamaño==true)
        {
            transform.localScale *= 1.5f;
            cambiotamaño = false;
        }
    }

}

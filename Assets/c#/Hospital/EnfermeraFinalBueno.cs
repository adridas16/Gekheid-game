using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnfermeraFinalBueno : MonoBehaviour
{
    // Start is called before the first frame update
    float TemporizadorEnfermera = 2f;
    float velocidad = 3;
    public int ConteoE = 0;
    public GameObject CanvasFinalJuego;
    public GameObject CanvasDialoge;
    bool finaljuego = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovimientoEnfermera();

        if (finaljuego == true)
        {
            Debug.Log("asasas");
            if (Input.GetKeyDown(KeyCode.E))
            {
                ConteoE++;
            }

            if (ConteoE >= 1)
            {
                CanvasFinalJuego.SetActive(true);
            }
        }
    }
    void MovimientoEnfermera()
    {
        TemporizadorEnfermera -= Time.deltaTime;
        {
            if (TemporizadorEnfermera <= 0)
            {
                if (transform.position != new Vector3(-14.1300001f, -1.11000001f, -2))
                {
                    transform.position += new Vector3(0, velocidad * Time.deltaTime, 0);
                }

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            velocidad = 0;
        }



    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            finaljuego = true;
        }
        else
        {
            finaljuego = false;
        }
    }
}

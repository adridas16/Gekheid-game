using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicos : MonoBehaviour
{
   
    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    private bool posicionCorrecta = true;
    public Transform textoPapelMedicos;

    Vector3 posicionVuelta, ScalaOriginal, EscalaOriginalTexto;

    // Start is called before the first frame update
    void Start()
    {
        transform.position -= new Vector3(0, 1.50f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            textoPapelMedicos.position = mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, -0.8f);

        }

    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            posicionVuelta = transform.position;
            isBeingHeld = true;
        }



    }
    private void OnMouseUp()
    {
        isBeingHeld = false;
        if (!posicionCorrecta)
        {
            transform.position = posicionVuelta;
            textoPapelMedicos.position = Camera.main.WorldToScreenPoint(posicionVuelta);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Soltar")
        {
            posicionCorrecta = false;
        }
        //if (collision.tag == "AgrandarPapel")
        //{
        //    ScalaOriginal = transform.localScale;
        //    EscalaOriginalTexto = transform.localScale;
        //    transform.localScale *= 1.5f;

        //}


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Soltar")
        {
            posicionCorrecta = true;
        }
        //if (collision.tag== "AgrandarPapel")
        //{
        //    transform.localScale = ScalaOriginal;
        //}


    }

}


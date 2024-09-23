using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertencia : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    public bool isBeingHeld = false;
    private bool posicionCorrecta = true;
    public float Velocidad =5f;
    Vector3 posicionVuelta,ScalaOriginal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.position += Vector3.up * Velocidad * Time.deltaTime;
        if(transform.position.y >=-3.86999989f)
        {
            Velocidad = 0;
        }
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, -0.1f);

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
            
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Soltar")
        {
            posicionCorrecta = false;
        }
        if (collision.tag == "AgrandarPapel")
        {
            ScalaOriginal = transform.localScale;
           
            transform.localScale *= 1.5f;

        }
        


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Soltar")
        {
            posicionCorrecta = true;
        }
        if (collision.tag == "AgrandarPapel")
        {
            transform.localScale = ScalaOriginal;
        }


    }
}

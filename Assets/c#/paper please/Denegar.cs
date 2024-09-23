using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Denegar : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 ScalaOriginalX, PosicionvueltaDenegar;
    public bool isBeingDragged = false;


    // Start is called before the first frame update
    void Start()
    {
        ScalaOriginalX = transform.localScale;
        PosicionvueltaDenegar = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingDragged == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, -0.5f);
        }

    }
    private void OnMouseDown()
    {

        isBeingDragged = true;
       
    }
    private void OnMouseUp()
    {
        isBeingDragged = false;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "AgrandarPapel")
        {
            ScalaOriginalX = transform.localScale;
            transform.localScale *= 1.5f;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "AgrandarPapel")
        {
            transform.localScale = ScalaOriginalX;
        }

    }


}


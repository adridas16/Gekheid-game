using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcTexto : MonoBehaviour
{
    public string[] TextoNpc;
    
    public SpriteRenderer teclaE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && teclaE.enabled)
        {
            DialogeManager.instance.MostrarTexto(TextoNpc);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            
            teclaE.enabled = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        DialogeManager.instance.OcultarTexto();
        teclaE.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            teclaE.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DialogeManager.instance.OcultarTexto();
        teclaE.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    
    public Collider2D colision;
    public int destruir=0;
    
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (destruir >= 1 && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            destruir = 1;




        }
        else
        {
            destruir = 0;
        }
        
        


    }
    
    
        
    










}

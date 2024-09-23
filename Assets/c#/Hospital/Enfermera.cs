using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enfermera : MonoBehaviour
{
    public GameObject CapsuleColiderEnfermera;
    public Transform enfermeraMover;
    public float movimiento=5f;
    public bool mover=false;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {

            
            
            mover = true;
            
            


        }
        if(mover==true)
        {
            movimiento -= Time.deltaTime;
            if (movimiento <= 0)
            {
                enfermeraMover.transform.position = new Vector3(15.9399996f, 24.1900005f, -0.300000012f);
                CapsuleColiderEnfermera.SetActive(false);
            }
           
            
        }

    }
    







}

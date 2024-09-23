using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrescripcionGameManager : MonoBehaviour
{
    public GeneradorDePrescripcion generadorDePrescripcion;
    public ConfirmacionDePrescripcion confirmacionDePrescripcion;
    public TMP_Text PrescripcionObjeto;
    public GameObject prescriptionObject;
    private bool PildorasEntregadas = false;
    public PrescripcionMedica EstaPrescripcion;
    public GameObject[] pildoras;
    
     int Personas=10;
    public GameObject canvasFin,Intro;
    public float temporizador = 2;
    public int Falladas=5;
    public Soltar soltar;




    // Start is called before the first frame update
    void Start()
    {
        if (Personas == 11)
        {
            soltar.PonerAdvertencia();
        }
        
        //soltar = FindObjectOfType<Soltar>();

        Intro.SetActive(true);

        CrearReceta();
       
        
        
        //PrescripcionObjeto.text= $"Prescr-ipcion: {EstaPrescripcion.NombreDeDoctor}\n{EstaPrescripcion.NombreMedicina }\n{EstaPrescripcion.Dosi }";
        //prescripcionValida = confirmacionDePrescripcion.IsPrescriptionValid(EstaPrescripcion);
        
       
        //prescriptionObject.transform.GetChild(0).GetComponent<TextMesh>().text="Prescripcion:{prescripcionrandom.NombreDeDoctor},{prescripcionrandom.NombreMedicina},{prescripcionrandom.NombreMedicina}";
        
        
    }

     
    // Update is called once per frame
    void Update()
    {
        

        if (Personas<=0) 
        {
            
            temporizador -= Time.deltaTime;
            if (soltar.PersonasEquivocadas >= 5)
            {
                if (temporizador <= 0)
                {
                    SceneManager.LoadScene(4);
                    //SceneManager.LoadScene("SampleScene");
                    Debug.Log("funciona");
                }
            }
            else if(soltar.PersonasEquivocadas <= 5)
            {
                SceneManager.LoadScene(3);
                //SceneManager.LoadScene("SampleScene");
                Debug.Log("funciona");
            }
            
        }
        



        // if (!PildorasEntregadas && Input.GetMouseButtonUp(0))
        // {
        //     foreach(var pildora in pildoras) 

        //     {
        //         if (pildora.activeSelf && IsPildoraSelected(pildora))
        //         {
        //             bool prescripcionValida = confirmacionDePrescripcion.IsPrescriptionValid(EstaPrescripcion);
        //             bool pildorasValidadas = pildora.name == EstaPrescripcion.NombreMedicina;
        //             if (prescripcionValida && pildorasValidadas)
        //             {
        //                 Debug.Log("receta valida");
        //             }
        //             else if(pildorasValidadas)
        //             {
        //                 Debug.Log("prescripcion invalida");
        //             }
        //             else
        //             {
        //                 Debug.Log("pildoras invalidas "+ pildora.name + " "+ EstaPrescripcion.NombreMedicina);
        //             }
        //             PildorasEntregadas = true;
        //             break;
        //         }
        //     }

        // }
        //bool  IsPildoraSelected(GameObject pildora)
        // {
        //     return true;
        // }

    }
    public void CrearReceta()
    {
        if (Personas > 0)
        {
            EstaPrescripcion = generadorDePrescripcion.GenerateRandomPrescription();

            prescriptionObject.SetActive(true);
            PrescripcionObjeto.text = $"Prescripcion: {EstaPrescripcion.NombreDeDoctor}\n{EstaPrescripcion.NombreMedicina}\n{EstaPrescripcion.Dosi}";
            Personas--;
        }
        else if (Personas <= 0)
        {
            PrescripcionObjeto.text = ("Ya no quedan personas");
            canvasFin.SetActive(true);
        }

    }
    
}

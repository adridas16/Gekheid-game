using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrescripcionMedica : MonoBehaviour
{
    
    public string NombreMedicina { get; set; }
    public string Dosi { get; set; }
    public string NombreDeDoctor { get; set; }
    public bool DoctorCorrecto { get; set; }
    
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PrescripcionMedica(string nombredemecidina, string dosis, string nombrededoctor, bool doctorCorrecto)
    {

        NombreMedicina = nombredemecidina;
        Dosi = dosis;
        NombreDeDoctor = nombrededoctor;
        DoctorCorrecto = doctorCorrecto;
    }


}

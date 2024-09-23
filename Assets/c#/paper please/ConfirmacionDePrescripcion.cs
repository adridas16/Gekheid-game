using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ConfirmacionDePrescripcion : MonoBehaviour
{
    public List<string> doctorValido;
    public List<string> doctorNovalido;

    public ConfirmacionDePrescripcion()
    {
        doctorValido = new List<string> { "Dr. Kalgan", "Dr. Alarcón", "Dr. Amador", "Dr. Archila", "Dr. Arias", "Dr. Barrera", "Dr. Bernal", 
            "Dr. Lucena" };
        
        

    }


    public bool IsPrescriptionValid(PrescripcionMedica prescripcion)
    {
     
       
            return doctorValido.Contains(prescripcion.NombreDeDoctor);
       
       
        //List<string> DoctoresValidos = doctorHorario.DoctoresValidosPorhoy(hoy);

        //// Verificar si el médico está en la lista de doctores válidos para el día actual
        //return DoctoresValidos.Contains(prescripcion.NombreDeDoctor);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}

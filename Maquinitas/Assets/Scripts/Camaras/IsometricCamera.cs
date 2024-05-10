using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá (por ejemplo, el jugador)
    public float distance = 10f; // Distancia de la cámara al objetivo
    public float height = 5f; // Altura de la cámara sobre el objetivo

    private void Start()
    {
        IsometicCamera();
    }

    private void IsometicCamera()
    {
        // Calcula la posición de la cámara
        Vector3 offset = new Vector3(0f, height, -distance);
        Vector3 desiredPosition = target.position + offset;

        // Establece la posición directamente sin interpolación
        transform.position = desiredPosition;

        // Mira hacia el objetivo
        //transform.LookAt(target);
        Vector3 lookDirection = target.position - transform.position;

        // Calcula la rotación necesaria para mirar hacia el punto
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

        // Aplica la rotación al objeto
        transform.rotation = targetRotation;
    }
}

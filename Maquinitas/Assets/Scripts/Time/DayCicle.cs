using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public Light directionalLight; // Asigna la luz que deseas controlar desde el inspector

    void Update()
    {
        float tiempoDelJuego = Clock.tiempoDelJuego;
        float grados = ((tiempoDelJuego / Clock.tiempoDeUnDiaSegundos) * 360f);
        transform.localEulerAngles = new Vector3(grados, -300f, 0f);

        // Desactivar la luz cuando el ángulo X sea 180 grados
        if (transform.localEulerAngles.x >= 180f && directionalLight.enabled)
        {
            directionalLight.enabled = false;
        }

        // Activar la luz cuando el ángulo X sea 0 grados
        if (transform.localEulerAngles.x <= 0f && !directionalLight.enabled)
        {
            directionalLight.enabled = true;
        }
    }
}

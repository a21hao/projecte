using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public Light directionalLight;

    void Update()
    {
        float tiempoDelJuego = Clock.tiempoDelJuego;
        float grados = ((tiempoDelJuego / Clock.tiempoDeUnDiaSegundos) * 360f);
        transform.localEulerAngles = new Vector3(grados, -300f, 0f);

        if (transform.localEulerAngles.x >= 180f && directionalLight.enabled)
        {
            directionalLight.enabled = false;
        }

        if (transform.localEulerAngles.x <= 0f && !directionalLight.enabled)
        {
            directionalLight.enabled = true;
        }
    }
}

using UnityEngine;

public class DayCicle : MonoBehaviour
{

    void Update()
    {
        float tiempoDelJuego = Clock.tiempoDelJuego;
        float grados = ((tiempoDelJuego / Clock.tiempoDeUnDiaSegundos) * 360f);
        transform.localEulerAngles = new Vector3(grados, -120f, 0f);
    }
}

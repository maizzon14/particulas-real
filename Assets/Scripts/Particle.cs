using UnityEngine;

public class Particle : MonoBehaviour
{
    public float velocidadInicial;
    public float anguloInicial;
    public float tiempoVidaMax;
    public float tiempoActiva;
    public float gravedad;

    public void SetParameters(float velocidad, float vida, float anguloInicialM)
    {
        velocidadInicial = vida;
        tiempoVidaMax = vida;
        anguloInicial = anguloInicialM * Mathf.Deg2Rad;
    }
}

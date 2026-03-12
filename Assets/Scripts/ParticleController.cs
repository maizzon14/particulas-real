using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Jobs;
using Mono.Cecil.Cil;
using UnityEngine.InputSystem;

public class ParticleController : MonoBehaviour
{
    public int numeroParticulas;
    public float velocidadInicialM;
    public float velocidadInicialMRango;
    public float anguloInicialM;
    public float anguloInicialMRango;
    public float tiempoVidaM;
    public float tiempoVidaMRango;
    public float gravedadParticulasM;

    public GameObject particula;
    public List<GameObject> particulas = new List<GameObject>();
    Particle particulaSc;

    private void Start()
    {
        particulaSc = particula.GetComponent<Particle>();
        CreateParticleExplotion(numeroParticulas);
    }

    public void CreateParticleExplotion(int numeroparticulasreal)
    {
        for(int i = 0; i < numeroparticulasreal; i++)
        {
            float velRandom = velocidadInicialM + Random.Range(-velocidadInicialMRango, velocidadInicialMRango);
            float vidaRandom = tiempoVidaM + Random.Range(-tiempoVidaMRango, tiempoVidaMRango);

            float anguloRandomY = anguloInicialM + Random.Range(-anguloInicialMRango, anguloInicialMRango);
            float anguloRandomXZ = Random.Range(0f, 360f);

            float anguloYRAD = anguloRandomY * Mathf.Deg2Rad;
            float anguloXZRAD = anguloRandomXZ * Mathf.Deg2Rad;

            Vector3 direccion = new Vector3(Mathf.Cos(anguloYRAD) * Mathf.Cos(anguloXZRAD), Mathf.Sin(anguloYRAD), Mathf.Cos(anguloYRAD) * Mathf.Sin(anguloXZRAD));
            
            GameObject particulanueva = Instantiate(particula, Vector3.zero, Quaternion.identity);
            Particle p = particulanueva.GetComponent<Particle>();
            p.SetParameters(velRandom, vidaRandom, anguloRandomY);
            particulas.Add(particulanueva);

            particulanueva.transform.forward = direccion;
        }
    }

    public void UpdateParticlePosition(Particle p, float time, Vector3 direccion)
    {
        p.tiempoActiva += time;
        float tiempoTotal = p.tiempoActiva;

        Vector3 velocity = direccion * p.velocidadInicial;

        float x = velocity.x * tiempoTotal;
        float y = velocity.y * tiempoTotal + ((p.gravedad * tiempoTotal * tiempoTotal) / 2);
        float z = velocity.z * tiempoTotal;

        Vector3 posicionFinal = new Vector3(x, y, z);
        p.transform.position = posicionFinal;
    }
    void Update()
    {
        for (int i = particulas.Count - 1; i >= 0; i--)
        {
            GameObject particula = particulas[i];

            if (particula == null)
            {
                particulas.RemoveAt(i);
                continue;
            }

            Particle p = particula.GetComponent<Particle>();
            if (p != null)
            {
                Transform child = particula.transform;
                Vector3 direccion = child.forward;
                UpdateParticlePosition(p, Time.deltaTime, direccion);

                if (p.tiempoActiva > p.tiempoVidaMax)
                {
                    particulas.RemoveAt(i);
                    Destroy(particula);
                    CreateParticleExplotion(1);
                }
            }
        }
    }
}

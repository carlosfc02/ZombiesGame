using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject zombiePrefab; // El molde del zombie
    public Transform[] puntosDeSpawn; // Lugares donde pueden nacer
    
    public float tiempoEntreOlas = 3f; // Segundos entre zombies
    private float tiempoProximoSpawn = 0f;

    void Update()
    {
        // Si el tiempo actual supera el tiempo programado...
        if (Time.time >= tiempoProximoSpawn)
        {
            SpawnZombie();
            tiempoProximoSpawn = Time.time + tiempoEntreOlas;
        }
    }

    void SpawnZombie()
    {
        // 1. Elegir un punto aleatorio
        int indiceAleatorio = Random.Range(0, puntosDeSpawn.Length);
        Transform puntoElegido = puntosDeSpawn[indiceAleatorio];

        // 2. Crear el zombie
        Instantiate(zombiePrefab, puntoElegido.position, puntoElegido.rotation);
    }
}

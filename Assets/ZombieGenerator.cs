using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] puntosDeSpawn;
    
    public float tiempoEntreSpawns = 3f;
    public float tiempoMinimoSpawn = 0.5f;
    public float reduccionPorSpawn = 0.1f;

    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoEntreSpawns;
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            SpawnZombie();
            
            if (tiempoEntreSpawns > tiempoMinimoSpawn)
            {
                tiempoEntreSpawns -= reduccionPorSpawn;
            }

            tiempoRestante = tiempoEntreSpawns;
        }
    }

    void SpawnZombie()
    {
        if (puntosDeSpawn.Length == 0) return;

        int indice = Random.Range(0, puntosDeSpawn.Length);
        Instantiate(zombiePrefab, puntosDeSpawn[indice].position, Quaternion.identity);
    }
}
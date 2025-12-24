using UnityEngine;
using UnityEngine.AI; // Necesario para usar la IA

public class ZombieAI : MonoBehaviour
{
    public Transform objetivo; // A quién persigue
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        
        // Buscamos al jugador automáticamente por su nombre
        // Asegúrate de que tu cápsula de jugador se llame "Jugador"
        GameObject jugador = GameObject.Find("Player");
        if (jugador != null)
        {
            objetivo = jugador.transform;
        }
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Le decimos al GPS: "Ve a la posición del jugador"
            agente.SetDestination(objetivo.position);
        }
    }
}
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera camaraJugador;
    public float rango = 100f;

    public GameObject balaPrefab;
    public float velocidadBala = 50f;
    public float tiempoVidaBala = 3f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(
            balaPrefab,
            camaraJugador.transform.position,
            camaraJugador.transform.rotation
        );

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.linearVelocity = camaraJugador.transform.forward * velocidadBala;

        Destroy(bala, tiempoVidaBala);

        RaycastHit hit;
        if (Physics.Raycast(camaraJugador.transform.position,
                            camaraJugador.transform.forward,
                            out hit,
                            rango))
        {
            Debug.Log("He impactado en: " + hit.transform.name);

            if (hit.transform.CompareTag("Enemy"))
            {
                GameManager.instancia.ZombieMuerto();

                ZombieAI zombieAI = hit.transform.GetComponent<ZombieAI>();
                if (zombieAI != null)
                {
                    zombieAI.Morir(); 
                }
                else
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}

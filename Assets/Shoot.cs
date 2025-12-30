using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera camaraJugador;
    public float rango = 100f;

    // 🔹 NUEVO
    public GameObject balaPrefab;
    public float velocidadBala = 50f;
    public float tiempoVidaBala = 3f;

    void Update()
    {
        // Clic izquierdo
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // =========================
        // 1️⃣ DISPARO VISUAL (BALA)
        // =========================
        GameObject bala = Instantiate(
            balaPrefab,
            camaraJugador.transform.position,
            camaraJugador.transform.rotation
        );

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.linearVelocity = camaraJugador.transform.forward * velocidadBala;

        Destroy(bala, tiempoVidaBala);

        // =========================
        // 2️⃣ RAYCAST (LÓGICA)
        // =========================
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
                Destroy(hit.transform.gameObject);
            }
        }
    }
}

using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera camaraJugador;
    public float rango = 100f;

    void Update()
    {
        // Si hacemos clic izquierdo (Boton 0)
        if (Input.GetButtonDown("Fire1"))
        {
            DispararRaycast();
        }
    }

    void DispararRaycast()
    {
        RaycastHit hit;
        // Lanza una línea desde el centro de la cámara hacia adelante
        if (Physics.Raycast(camaraJugador.transform.position, camaraJugador.transform.forward, out hit, rango))
        {
            Debug.Log("He impactado en: " + hit.transform.name);

            // Verificamos si lo que golpeamos tiene el tag "Enemy"
            if (hit.transform.CompareTag("Enemy"))
            {
                // Destruimos el objeto golpeado
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
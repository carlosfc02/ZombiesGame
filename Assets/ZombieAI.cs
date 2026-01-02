using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieAI : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agente;
    private Animator animator;
    private Rigidbody rb;
    private Collider col;

    public float distanciaAtaque = 2f;
    public bool estaMuerto = false; 

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        GameObject jugador = GameObject.Find("Player");
        if (jugador != null)
            objetivo = jugador.transform;
    }

    void Update()
    {
        if (estaMuerto) return; 

        if (objetivo != null)
        {
            float distancia = Vector3.Distance(transform.position, objetivo.position);

            if (distancia <= distanciaAtaque)
            {
                agente.isStopped = true;
                animator.SetBool("Atacando", true);
            }
            else
            {
                agente.isStopped = false;
                agente.SetDestination(objetivo.position);
                animator.SetBool("Atacando", false);
            }
        }
    }

    public void Morir()
    {
        estaMuerto = true;
        agente.isStopped = true;
        animator.SetTrigger("Muerto");

        if (rb != null) rb.isKinematic = true;
        if (col != null) col.isTrigger = true;

        StartCoroutine(DestruirAlFinal());
    }

    private IEnumerator DestruirAlFinal()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}

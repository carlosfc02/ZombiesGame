using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public int zombiesMuertos = 0;
    public TMP_Text textoZombies;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ActualizarTexto();
        textoZombies.gameObject.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            textoZombies.gameObject.SetActive(true);
        }
        else
        {
            textoZombies.gameObject.SetActive(false);
        }
    }

    public void ZombieMuerto()
    {
        zombiesMuertos++;
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        textoZombies.text = "Zombies: " + zombiesMuertos;
    }
}

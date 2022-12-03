using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;

    private int pontos = 0;
    private int level = 1;

    private float esperaInimigo = 0f;
    [SerializeField] private float tempoEspera = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();

    }

    private void GeraInimigos()
    {
        //Timer pra gerar inimigos------------------------
        esperaInimigo -= Time.deltaTime;

        if (esperaInimigo <= 0f)
        {
            //Criando um inimigo
            Instantiate(inimigos[0], transform.position, transform.rotation);
            Instantiate(inimigos[1], new Vector2(5f, 6f), transform.rotation);

            Instantiate(inimigos[1], new Vector2(5f, 0f), transform.rotation);

            esperaInimigo = tempoEspera;
        }
    }
}

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
    //checando se a espera ja zerou
    private void GeraInimigos()
    {
        //Timer pra gerar inimigos------------------------
        esperaInimigo -= Time.deltaTime;

        if (esperaInimigo <= 0f)
        {
            //Criando um inimigo
            Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 16f), 0f);
            Instantiate(inimigos[0], posicao, transform.rotation);


            esperaInimigo = tempoEspera;
        }
    }
}

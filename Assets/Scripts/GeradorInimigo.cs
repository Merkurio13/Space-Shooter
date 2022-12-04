using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;

    private int pontos = 0;
    [SerializeField]private int level = 1;

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

            GameObject inimigoCriado;

            //Deciddindo qual inimigo vai ser cirado com base no level
            float chance = Random.Range(0, level);

            if (chance > 2)
            {
                inimigoCriado = inimigos[1];
            }
            else
            {
                inimigoCriado = inimigos[0];
            }


            //Criando um inimigo
            Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 16f), 0f);
            Instantiate(inimigoCriado, posicao, transform.rotation);


            esperaInimigo = tempoEspera;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    //Pegando o meu Rigidbody 
    private Rigidbody2D meuRB;

    [SerializeField] private GameObject tiroInimigo;
    //Pegando o transform da posição do meu tiro
    [SerializeField] private Transform posicaoTiro;

    [SerializeField] private float yMax = 2.5f;

    private bool possoMover = true;

  

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();


        //Dando a valocidade para o meu RB
        var praBaixo = meuRB.velocity = new Vector2(0f, -velocidade);

        //Deixando a espera aleatória
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yMax && possoMover)
        {
            Debug.Log("eu");



            if (transform.position.x > 0f)
            {
                Debug.Log("direita");
                //indo pra direita
                 meuRB.velocity = new Vector2(-velocidade, -velocidade);

                possoMover = false;
            }
            if(transform.position.x <= 0f)
            {
                Debug.Log("esquerda");
                 meuRB.velocity = new Vector2(+velocidade, -velocidade);

                possoMover = false;
            }




        }

        Atirando();
    }
        //Vou checar se o meu sprite enderer esta visivel


        //Pegando informações do meus "filhos"
    private void Atirando()
    {
        if (GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            //encontrando o player na cena
            var player = FindObjectOfType<PlayerController>();

            // diminuir a minha espera, e se ela fr menor ou igaul a zero então eu atiro
            //só fazer qualquer coisa se meu player existir
            if (player)
            {

                esperaTiro -= Time.deltaTime;
                if (esperaTiro <= 0)
                {

                    //instanciando o meu tiro
                    var tiro = Instantiate(tiroInimigo, posicaoTiro.position, transform.rotation);


                    //Encontrando o valor da direção
                    Vector2 direcao = player.transform.position - tiro.transform.position;
                    //normalizando a velocidade do tiro
                    direcao.Normalize();
                    //dando a direção velocidade do meu tiro
                    tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                    //Dando o angulo que o tiro tem que estar
                    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

                    //passando o angulo
                    tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);


                    //reiniciando tempo de espera
                    esperaTiro = Random.Range(1.5f, 2f);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : InimigoPai
{
    //Pegando o meu Rigidbody 
    private Rigidbody2D meuRB;
    

    [SerializeField] private GameObject tiroInimigo;

    

    //Pegando o transform da posição do meu tiro
    [SerializeField] private Transform posicaoTiro;

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        //Dando a valocidade para o meu RB
        meuRB.velocity = new Vector2(0f, -velocidade);

        //Deixando a espera aleatória
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {


        Atirando();

    }
        //Vou checar se o meu sprite enderer esta visivel


        //Pegando informações do meus "filhos"
    private void Atirando()
    {
        if (GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            // diminuir a minha espera, e se ela fr menor ou igaul a zero então eu atiro
            esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0)
            {

                //instanciando o meu tiro
                var tiro = Instantiate(tiroInimigo, posicaoTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeTiro;

                //reiniciando tempo de espera
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
    }
}

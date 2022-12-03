using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject meuTiro;

    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;


    //Pegando o transform da ´posição do meu tiro
    [SerializeField] private Transform PosicaoTiro;

    //Vida do inimigo
    [SerializeField] private int vida = 2;

    [SerializeField] private float velocidadeTiro = 7;
    
    // minha explosão
    [SerializeField] private GameObject explosao;



    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();
        Atirando();

    }

    private void Movendo()
    {
        //pegando o input horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);

        //normalizando a diagonal
        minhaVelocidade.Normalize();


        //Passando a minha velocidade para o meuRB
        meuRB.velocity = minhaVelocidade * velocidade;
    }

    private void Atirando()
    {
        // tertando para ver se funcionou a mudan
        if (Input.GetButtonDown("Fire1"))
        {

            var tiro =Instantiate(meuTiro, PosicaoTiro.position, transform.rotation);

            //dar a doreção e velocidade para o RB do tiro
            tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
            
        }
    }

    //Criar um método perde vida que recebe a quantidade de vida que ele deve perder (dano)
    public void PerdeVida(int dano)
    {
        //Perdendo a minha vida com base no dano
        vida -= dano;

        Debug.Log(vida);

        if (vida <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
}

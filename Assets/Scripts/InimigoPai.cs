using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called before the first frame update


    //Atributos que TODOS inimigos devem ter
    [SerializeField] protected float velocidade;
    [SerializeField] protected int vida;
    [SerializeField] protected GameObject explosao;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected float velocidadeTiro = 5f;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Criando o método perde vida
    public void PerdeVida(int dano)
    {

        vida -= dano;

        if(vida <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checando se o outro cara é o destruidor

        if (collision.CompareTag("destruidor"))
        {
            Destroy(gameObject);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);

            //tirando vida do player
            other.gameObject.GetComponent<PlayerController>().PerdeVida(1);
        }
    }
}

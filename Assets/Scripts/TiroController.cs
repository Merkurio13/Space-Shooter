using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D tiroRB;
    [SerializeField] private GameObject inimigo;
    

    [SerializeField] private GameObject impacto;

    // Start is called before the first frame update
    void Start()
    {
        tiroRB = GetComponent<Rigidbody2D>();

        //tiroRB.velocity = new Vector2(0, 1f) * velTiro;
    }

    // Update is called once per frame
    void Update()
    {

  
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        //Pegar o mátodo perde vida e aplicar nele o dano (other)
        //Isso só deve rodar se ele colidiu om alguem que tem o script inimigo01
        //Checando se a tag de quem eu estou colidindo é "inimigo01
        if (collision.CompareTag("Inimigo") && transform.position.y < 5f)
        {
            collision.GetComponent<InimigoPai>().PerdeVida(1);

            
        }
        if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<PlayerController>().PerdeVida(1);

            
            
        }
        //tiro sendo destruido
        Destroy(gameObject);
        if (collision)
        {
            Instantiate(impacto, transform.position, transform.rotation);



        }
        
    }
  
}

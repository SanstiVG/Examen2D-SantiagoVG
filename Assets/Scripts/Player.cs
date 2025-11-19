using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D rb2d;
    public float movimientoX;
    public float velocidad = 3.0f;
    public float radioEsferaTocaSuelo = 0.1f;
    public float fuerzaSalto = 6.0f;
    private bool estaEnSuelo;
    public Transform compruebaSuelo;
    public LayerMask layerSuelo;
    private Animator animator;
    public Transform puntoInicio;
    public Transform playerTransform;
    public AudioClip sonidoMoneda;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        estaEnSuelo = Physics2D.OverlapCircle(compruebaSuelo.position, radioEsferaTocaSuelo, layerSuelo);
        rb2d.linearVelocity = new Vector2(movimientoX * velocidad,rb2d.linearVelocity.y);
        if (movimientoX == 0)
        {
            animator.Play("Idle");
        }

    }
    private void OnMove(InputValue inputValue)
    {
        movimientoX = inputValue.Get<Vector2>().x;
        if (movimientoX!=0)
        {
            animator.Play("Run");
            transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
        }
    }

    private void OnJump(InputValue inputValue)
    {
        if (estaEnSuelo)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            gameManager.QuitarVida();
            playerTransform.position = puntoInicio.position;
        }
        if (collision.gameObject.CompareTag("Moneda"))
        {
            audioSource.PlayOneShot(sonidoMoneda);
            gameManager.SumarPuntos();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Final"))
        {
            gameManager.LlegarFinal();
        }
    }
}

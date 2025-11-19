using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float movimientoX;
    public float velocidad = 3.0f;
    public float radioEsferaTocaSuelo = 0.1f;
    public Transform compruebaSuelo;
    public LayerMask layerSuelo;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(movimientoX * velocidad,rb2d.linearVelocity.y);

    }
    public void OnMove(InputValue inputValue)
    {
        movimientoX = inputValue.Get<Vector2>().x;
        if (movimientoX!=0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
        }
    }
}

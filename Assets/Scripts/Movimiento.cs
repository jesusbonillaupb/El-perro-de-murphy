using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public bool isAlive = true;
    public float deathCooldown = 1f;

    [Header("Movimiento")]
    private float inputX;
    [SerializeField] private float velocidadDeMovimiento = 5f;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto = 5f;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCajaSuelo;
    [SerializeField] private bool enSuelo;
    [SerializeField] private float coyoteTime = 0.2f;
    private float tiempoEnElAire;
    private bool salto = false;

    [Header("Animator")]
    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Moving", Mathf.Abs(inputX * velocidadDeMovimiento));

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCajaSuelo, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);

        if (enSuelo)
        {
            tiempoEnElAire = 0;
        }
        else
        {
            tiempoEnElAire += Time.deltaTime;
        }

        Mover(inputX, salto);

        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        if (isAlive)
        {
            // Aplica la velocidad horizontal constante
            rb2D.velocity = new Vector2(mover * velocidadDeMovimiento, rb2D.velocity.y);

            if ((mover > 0 && !mirandoDerecha) || (mover < 0 && mirandoDerecha))
            {
                Girar();
            }

            if (enSuelo && saltar)
            {
                Salto();
            }
            else if (!enSuelo && saltar && tiempoEnElAire < coyoteTime)
            {
                Salto();
            }
        }
    }

    private void Salto()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, fuerzaDeSalto);
        tiempoEnElAire = 1f;
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCajaSuelo);
    }

    public void Muerte()
    {
        if (isAlive)
        {
            isAlive = false;

            StartCoroutine(ReloadSceneAfterCooldown());
        }
    }

    private IEnumerator ReloadSceneAfterCooldown()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        yield return new WaitForSeconds(deathCooldown);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

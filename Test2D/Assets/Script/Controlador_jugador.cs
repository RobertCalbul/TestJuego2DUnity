using UnityEngine;

public class Controlador_jugador : MonoBehaviour
{

    // Use this for initialization
    public float Velocidad = 5f;
    public float VelocidadMaxima = 10f;
    public float FuerzaSalto = 8f;
    public bool EnSuelo = true;
    public Transform comprobadorSuelo;
    float comprobadorRadio = 0.07f;
    public LayerMask MascaraSuelo;
    public bool DobleSalto = false;

    Rigidbody2D Jugador;
    Animator Animador;
    private void Awake()
    {

        Jugador = GetComponent<Rigidbody2D>();
        Animador = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((EnSuelo || !DobleSalto) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jugador.velocity = new Vector2(Jugador.velocity.x, FuerzaSalto);
            Jugador.AddForce(new Vector2(0, FuerzaSalto));
            if (!DobleSalto && !EnSuelo)
            {
                DobleSalto = true;
            }
        }
    }

    private void FixedUpdate()
    {
        float direccion = Input.GetAxis("Horizontal");
        Jugador.AddForce(Vector2.right * Velocidad * direccion);
        float LimiteVel = Mathf.Clamp(Jugador.velocity.x, -VelocidadMaxima, VelocidadMaxima);

        Jugador.velocity = new Vector2(LimiteVel, Jugador.velocity.y);

        EnSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, MascaraSuelo);
        if (EnSuelo)
        {
            DobleSalto = false;
        }
    }

}

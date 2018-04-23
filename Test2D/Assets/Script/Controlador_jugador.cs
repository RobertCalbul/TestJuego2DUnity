using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_jugador : MonoBehaviour {

    // Use this for initialization
    public float Velocidad = 5f;
    public float VelocidadMaxima = 10f;

    Rigidbody2D Jugador;
    Animator Animador;
    private void Awake()
    {

        Jugador = GetComponent<Rigidbody2D>();
        Animador = GetComponent<Animator>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float direccion = Input.GetAxis("Horizontal");
        Jugador.AddForce(Vector2.right * Velocidad * direccion);

        float LimiteVel = Mathf.Clamp(Jugador.velocity.x, -VelocidadMaxima, VelocidadMaxima);

        Jugador.velocity = new Vector2(LimiteVel, Jugador.velocity.y);
    }

}

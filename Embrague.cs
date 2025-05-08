using UnityEngine;

public class Embrague : Simulator
{
    private enum EstadoEmbrague { Presionado, Suelto }

    // Asignamos directamente a Santino Sabatini como creador predeterminado
    [SerializeField] private Creadores creadores = Creadores.Sabatini_Cialone_Santino;

    private EstadoEmbrague estadoActual = EstadoEmbrague.Suelto;

    [SerializeField]
    private bool estaPresionado;

    public bool EstaPresionado => estaPresionado;
    private void Awake()
    {
        creadores = Creadores.Sabatini_Cialone_Santino;
    }
    private void Start()
    {
        AsignarCreador(creadores);
        Describir();
    }

    public override void Describir()
    {
        Debug.Log($"Soy el hijo de simulator, creado por: {CreadoresSimulator}");
    }

    public override void AsignarCreador(Creadores creador)
    {
        CreadoresSimulator = creador;
        Debug.Log($"Creador asignado: {creador}");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (estadoActual != EstadoEmbrague.Presionado)
            {
                estadoActual = EstadoEmbrague.Presionado;
                estaPresionado = true;
                Presionar();
            }
        }
        else
        {
            if (estadoActual != EstadoEmbrague.Suelto)
            {
                estadoActual = EstadoEmbrague.Suelto;
                estaPresionado = false;
                Soltar();
            }
        }
    }

    private void Presionar()
    {
        Debug.Log("Embrague presionado.");
    }

    private void Soltar()
    {
        Debug.Log("Embrague soltado.");
    }
}

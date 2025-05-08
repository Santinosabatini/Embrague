using UnityEngine;

public class Acelerador : Simulator
{
    [SerializeField] private float aceleracion;
    private const float MaxAceleracion = 1.0f;
    private const float MinAceleracion = 0.0f;
    private const float TasaIncremento = 0.5f; // Por segundo
    private const float TasaDecremento = 1.0f; // Por segundo
    [SerializeField] private Creadores creadores = Creadores.Diaz_Corvalan_Matias_Federico;
    private void Awake()
    {
        creadores = Creadores.Diaz_Corvalan_Matias_Federico;
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

    void Update()
    {
        Actualizar(Time.deltaTime);
    }

    public void Actualizar(float deltaTime)
    {
        bool presionado = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float valorAnterior = aceleracion;

        if (presionado)
        {
            aceleracion += TasaIncremento * deltaTime;
            if (aceleracion > MaxAceleracion)
                aceleracion = MaxAceleracion;
        }
        else
        {
            aceleracion -= TasaDecremento * deltaTime;
            if (aceleracion < MinAceleracion)
                aceleracion = MinAceleracion;
        }

        if (valorAnterior != aceleracion)
        {
            Debug.Log($"[DEBUG] Aceleracion: {aceleracion:F2}");
        }
    }

    public float GetAceleracion()
    {
        return aceleracion;
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//By Javier Garcia Palacio
public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text J1;
    [SerializeField] private TMP_Text J2;

    [SerializeField] private Transform jugador1Transform;
    [SerializeField] private Transform jugador2Transform;
    [SerializeField] private Transform bolaTransform;

    private int jugador1Puntuacion;
    private int jugador2Puntuacion;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void jugador1Puntua()
    {
        jugador1Puntuacion++;
        J1.text = jugador1Puntuacion.ToString();

        if (jugador1Puntuacion >= 5)
        {
            CargarEscenaFinal();
        }
    }

    public void jugador2Puntua()
    {
        jugador2Puntuacion++;
        J2.text = jugador2Puntuacion.ToString();

        if (jugador2Puntuacion >= 5)
        {
            CargarEscenaFinal();
        }
    }

    public void Restart()
    {
        jugador1Transform.position = new Vector2(jugador1Transform.position.x, 0);
        jugador2Transform.position = new Vector2(jugador2Transform.position.x, 0);
        bolaTransform.position = new Vector2(0, 0);
    }

    private void CargarEscenaFinal()
    {
        SceneManager.LoadScene("Final");
    }
}
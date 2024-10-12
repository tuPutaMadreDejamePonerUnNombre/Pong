using UnityEngine;
using UnityEngine.SceneManagement;

//By Javier Garcia Palacio
public class CambiarEscena : MonoBehaviour
{
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
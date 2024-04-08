using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    int numCaramelitos = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            numCaramelitos = LoadScore();
            UIManager.Instance.CambiarTexto(numCaramelitos);
            Instance = this;
        }
    }

    public void RecogerCaramelito()
    {
        numCaramelitos++;
        UIManager.Instance.CambiarTexto(numCaramelitos);
        CaneSpawner.Instance.CrearUnCaramelito();
        // TODO: Cambiar esta función de lugar, asociarla a un botón.
        // TODO: Añadir una función llamada DeleteScore(), para poner la puntuación a 0.
        //SaveScore(numCaramelitos);

    }


    void SaveScore(int score)
    {
        PlayerPrefs.SetInt("NumCaramelos", numCaramelitos);
        PlayerPrefs.Save();
        // TODO: Usar el PlayerPrefs para guardar la puntuación
    }

    int LoadScore()
    {
        return PlayerPrefs.GetInt("NumCaramelos", 0);
        // TODO: Leer del PlayerPrefs la puntuación, y devolverla.
    }

    public void guardar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SaveScore(numCaramelitos);
            Debug.Log("Guardado");
        }
    }

    public void deleteScore(InputAction.CallbackContext context)
    {
        numCaramelitos = 0;
        //PlayerPrefs.SetInt("NumCaramelos", numCaramelitos);
        //PlayerPrefs.Save();
        SaveScore(numCaramelitos);
        // o tambien hacer
        //PlayerPrefs.DeleteKey("NumCaramelos");
        //PlayerPrefs.Save();
        UIManager.Instance.CambiarTexto(numCaramelitos);
    }
}

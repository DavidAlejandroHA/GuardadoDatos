using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{

    public TMP_Text tmpTextComponent; // Assign this in the inspector
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {

            Instance = this;
        }
    }

    // Update is called once per frame
    public void CambiarTexto(int cuantosCaramelitos)
    {
        tmpTextComponent.text = "Numero de caramelitos = " + cuantosCaramelitos;
    }
}

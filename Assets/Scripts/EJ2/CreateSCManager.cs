using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class CreateSCManager : MonoBehaviour
{
    public GameObject SantaClaus;
    public Toggle toggleBailecito;
    public TMP_Dropdown dropdownColor;
    public static CreateSCManager Instance { get; private set; }
    bool bailecito;
    Color color;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Debug.Log(Application.persistentDataPath);
            Instance = this;
            LeerDatos();
            InicializarValoresUI();

        }
    }

    public void InicializarValoresUI()
    {
        toggleBailecito.isOn = bailecito;
        dropdownColor.value = obtenerItem(color);
        SantaClaus.GetComponentInParent<Animator>().SetBool("bailecito", bailecito);
    }


    public void CambiarColor(int opcion)
    {
        if(opcion == 1)
        {
            color = Color.red;
        }
        else if(opcion == 2)
        {
            color = Color.blue;
        }
        else
        {
            
            color = Color.white;
        }
        SantaClaus.GetComponent<Renderer>().material.color = color;
    }


    public void Bailecito(bool nuevoBaile)
    {
        bailecito = nuevoBaile;
        SantaClaus.GetComponentInParent<Animator>().SetBool("bailecito", bailecito);
    }

    public void GuardarDatos()
    {
        SaveManager.Instance.GuardarJuego(bailecito, color);
    }

    public void LeerDatos()
    {
        PlayerSettings leido = SaveManager.Instance.CargarJuego();
        bailecito = leido.bailecito;
        color = leido.color;
    }

    

    public int obtenerItem(Color color)
    {
        if (Color.red == color) return 1;
        else if (Color.blue == color) return 2;
        else return 0;
    }
}

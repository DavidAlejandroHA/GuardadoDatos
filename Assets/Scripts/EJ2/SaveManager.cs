using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    PlayerSettings settings;

    string fichero;
    public static SaveManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            settings = new PlayerSettings();
            fichero = Application.persistentDataPath + "/datos.json";
            settings.color = Color.white;
            settings.bailecito = false;
            Instance = this;
        }
    }
  

    public  void GuardarJuego(bool bailecito, Color color)
    {

        settings.color = color;
        settings.bailecito = bailecito;
        string jsonTexto = JsonUtility.ToJson(settings);
        File.WriteAllText(fichero, jsonTexto);
        // Modificar los campos de la variable settings

        // Pasar la variable settings a Json con la funcion ToJson

        // Guardar dicho string con la función WriteAllText

    }

    public PlayerSettings CargarJuego()
    {
        if (File.Exists(fichero))
        {
            // Leer del fichero con la funcion ReadAllText

            // Modificar la variable settings con el método FromJson
            string textoJson = File.ReadAllText(fichero);
            settings = JsonUtility.FromJson<PlayerSettings>(textoJson);
        }
        return settings;
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(fichero))
        {
            File.Delete(fichero);
        }
       
    }
} 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    //Variables publicas
    public Text resourceText;
    //Variables privadas
    private float currentResources;
    // Start is called before the first frame update
    void Start()
    {
        currentResources = 0f;
        UpdateUI();
    }

    //Funcion para agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }
    //Funcion para quitar recursos
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }
    //Funcion para devolver los recursos actuales
    public float CurrentResources()
    {
        return currentResources;
    }
    //Funcion para actualizar el UI
    public void UpdateUI()
    {
        resourceText.text = "Cash: $" + currentResources;
    }
}

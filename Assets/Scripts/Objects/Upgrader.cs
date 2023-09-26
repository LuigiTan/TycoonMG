using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    //Variables publicas
    public ResourceManager resourceManager;
    public float cost;
    public string text;

    public UnityEvent OnActivated;

    //Variables privadas
    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializando variables
        textMesh = GetComponentInChildren<TextMesh>();

        //Ponemos el texto y el costo
        textMesh.text = text + " $" + cost;


    }

    //Si un objeto entra en el collider

    private void OnTriggerEnter(Collider other)
    {
        //Si el obketo que colisiona con el trigger es el player
        if(other.gameObject.CompareTag("Player"))
        {
            //Si tenemos suficientes recursos
            if(resourceManager.CurrentResources() >= cost) 
            {
                //Quitamos el costo de la mejora, activamos el evento y nos destruimos
                resourceManager.RemoveResources(cost);
                OnActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }
}

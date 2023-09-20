using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    public ResourceManager resourceManager;

    //Si entra un objeto en el trigger
    private void OnTriggerEnter (Collider other)
    {
        //Si el objeto es un recurso
        if(other.gameObject.GetComponent<Resource>())
        {
            //Agregamos el valor del recurso y destruimos el objeto
            resourceManager.AddResources(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }
}

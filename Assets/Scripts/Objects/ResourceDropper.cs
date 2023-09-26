using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    //Variables Publicas
    public GameObject[] resources;
    public float spawnTime;

    //Variables Privadas
    private int dropperTier;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        dropperTier = 1;
        InvokeRepeating("DropResource",spawnTime, 1f);
    }

    //Funcion para instanciar un recurso
    void DropResource()
    {
        if (resources[dropperTier - 1] != null || dropperTier <= resources.Length)
        {
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
        }
    }

    //Funcion para mejorar el dropper
    public void UpgradeDropper()
    {
        dropperTier++;
    }
    
}

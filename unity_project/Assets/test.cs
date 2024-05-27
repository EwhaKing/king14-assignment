using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    [SerializeField]
    private GameObject go;

    private void Awake()
    {
        Debug.Log(message: "Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "Start") ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(message: "A°¡ ´­·È¾î!");
        }
    }
}

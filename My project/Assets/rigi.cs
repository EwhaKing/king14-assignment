using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigi : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject go;

    void Awake()
    {
        Debug.Log(message: "Awake");
        //DISingleton.Instance.Ex.
    }
    void Start()
    {
        Debug.Log(message: "Start");

    }

    // Update is called once per frame
    void Update() //계속 반복하면서 매시간 작동
    {
        Debug.Log(message: "Update");
        if (Input.GetKeyDown(KeyCode.A))    //input을 입력받는 방법
        {
            Debug.Log("A가 눌렸어!");
        }
    }
}

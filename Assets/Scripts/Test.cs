using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }

    private void OnEnable() {
        Debug.Log("OnEnable");
    }

    // Update is called once per frame
    void Update()
    {
    }
}

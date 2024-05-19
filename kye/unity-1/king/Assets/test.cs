using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message: "start");   
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(message: "update");
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(message: "A 누름");
        }

    }
}

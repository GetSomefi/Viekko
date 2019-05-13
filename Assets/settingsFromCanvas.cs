using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsFromCanvas : MonoBehaviour
{
    public bool useMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useMouseInGame() {
        useMouse = !useMouse;
        //Debug.Log("Use mouse " + useMouse);
    }
}

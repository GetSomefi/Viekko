using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGameManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject ball;
    public GameObject secondBall;

    // Start is called before the first frame update
    void Start()
    {
        StartPositions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartPositions() {
        p1.transform.position = new Vector3(-8, 2, 0);
        p2.transform.position = new Vector3(8, 2, 0);
        ball.transform.position = new Vector3(0, 4.90f, 0);
        secondBall.transform.position = new Vector3(0.08f, 10.5f, -5.9f);
        secondBall.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

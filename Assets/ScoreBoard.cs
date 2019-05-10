using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public int scoreTotalP1 = 0;
    public int scoreTotalP2 = 0;
    public TextMeshPro scores;
    public GameObject TheGameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scores.SetText(scoreTotalP1 + " - " + scoreTotalP2);

        //Debug.Log("Score" + scoreTotalP1 + " - " + scoreTotalP2);
    }

    public void ResetSceneAfterGoal() {
        Debug.Log("Reset scene after goal");
        TheGameManager.GetComponent<TheGameManager>().StartPositions();
    }
}

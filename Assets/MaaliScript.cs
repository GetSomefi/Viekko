using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaaliScript : MonoBehaviour
{
    AudioSource audioSource;
    public int playerNumber;
    private ScoreBoard Scores;

    public GameObject B;
    private ScoreBoard ScoreBoard;

    public TextMeshPro CheerText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Scores = GetComponent<ScoreBoard>();
        ScoreBoard = B.GetComponent<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScoreBoard.scoreTotalP1 + "-" + ScoreBoard.scoreTotalP2);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pelivaline") {
            Debug.Log("He scores! " + playerNumber);
            CheerText.SetText("Player " + playerNumber + " scores!");

            audioSource.Play();

            if (playerNumber == 1)
            {
                Debug.Log("P1 teki");
                ScoreBoard.scoreTotalP1++;


            }
            else {
                Debug.Log("P2 teki");
                ScoreBoard.scoreTotalP2++;
               
            }

            StartCoroutine(AfterGoal());
           // ScoreBoard.ResetSceneAfterGoal();
        }

    }

    IEnumerator AfterGoal() {
        yield return new WaitForSeconds(1);
        StartCoroutine( AfterGoalPhase2());
    }

    IEnumerator AfterGoalPhase2()
    {
        audioSource.pitch = 2.6f;
        audioSource.Play();

        CheerText.SetText("Get ready! 3");
        yield return new WaitForSeconds(1f);
        StartCoroutine(AfterGoalPhase3());
    }

    IEnumerator AfterGoalPhase3()
    {
        audioSource.pitch = 2.2f;
        audioSource.Play();

        CheerText.SetText("Get ready! 2");
        yield return new WaitForSeconds(1f);
        StartCoroutine(AfterGoalPhase4());
    }

    IEnumerator AfterGoalPhase4()
    {
        audioSource.pitch = 1.8f;
        audioSource.Play();

        CheerText.SetText("Get ready! 1");
        yield return new WaitForSeconds(1f);
        StartCoroutine(AfterGoalPhase5());
    }

    IEnumerator AfterGoalPhase5()
    {
        audioSource.pitch = 1.4f;
        audioSource.Play();
        CheerText.SetText("Go!");
        yield return new WaitForSeconds(1f);
        ScoreBoard.ResetSceneAfterGoal();
        CheerText.SetText("Viekko!");

        audioSource.pitch = 1.2f;
        audioSource.Play();
    }
}

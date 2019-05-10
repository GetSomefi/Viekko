using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Reset : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject TheGameManager;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Restarted");
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene("perusSetti");
    }

    public void ResetScene()
    {
        Debug.Log("Reset scene");
        TheGameManager.GetComponent<TheGameManager>().StartPositions();
        audioSource.Play();
    }
}

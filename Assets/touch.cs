using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject projectile;
    public GameObject clone;

    //drag UseMouseToggle here
    public GameObject inheritSettings;
    private bool useMouse = false;

    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        useMouse = inheritSettings.GetComponent<settingsFromCanvas>().useMouse;
        bool touchDown = false;
        for (int i = 0; i < Input.touchCount; ++i)
        {
            /*
            Vector3 newObjectPos = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            */
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                touchDown = true;

            }

            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                touchDown = false;

            }

            if (Input.GetTouch(i).phase == TouchPhase.Moved) {
               
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                // Create a particle if hit
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //transform.position = hit.point;

                    if(hit.transform.tag == "vasen")
                    {
                        hit.transform.position = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);
                        hit.transform.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 0.1f);
                    }
                    if(hit.transform.tag == "oikea")
                    {
                        hit.transform.position = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);
                        hit.transform.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0.1f);
                    }
                }
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
        }

    }



    //hiirelle
    void OnMouseDown()
    {
        if (useMouse)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }
    void OnMouseDrag()
    {
        if (useMouse)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pelivaline")
        {
            Debug.Log("Hit");
            audioSource.Play();
        }
    }
}

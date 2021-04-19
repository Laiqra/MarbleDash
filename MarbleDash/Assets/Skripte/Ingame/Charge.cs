using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Charge : MonoBehaviour
{
    public GameObject Bumper;
    Renderer rend;

    public GameObject Indicator;
    public GameObject GameManager;
    public float pushForce;
    public float maxForce;

    private Camera m_camera;
    private GameObject m_GO = null;
    private Vector3 initMousePosition;
    private Vector3 endMousePosition;

    private bool bluesTurn = true;
    private bool lockInput = false;


    void toggleTurn()
    {
        if (GameManager.GetComponent<InitialiserGOs>().checkForMovement())
        {
            Invoke("toggleTurn", 0.2f);
        }
        else
        {
            if (bluesTurn)
            {
                bluesTurn = false;
                rend.material.SetColor("_Color", Color.red);
            }
            else
            {
                bluesTurn = true;
                rend.material.SetColor("_Color", Color.blue);
            }
            lockInput = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Indicator.SetActive(false);
        m_camera = Camera.main;
        rend = Bumper.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.blue);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !lockInput)
        {

            RaycastHit hit;
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if ((hit.transform.CompareTag("Blue") && bluesTurn) || (hit.transform.CompareTag("Red") && !bluesTurn))
                {
                    m_GO = hit.transform.gameObject;
                    initMousePosition = m_GO.transform.position;
                    initMousePosition.y = 0;

                    Indicator.SetActive(true);
                    lockInput = true;

                    Debug.Log("initMousePosition" + initMousePosition);
                }
            }
        }

        if (Input.GetMouseButton(0) && m_GO != null)
        {
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    endMousePosition = hit.point;
                    endMousePosition.y = 0;
                }

                Indicator.transform.position = initMousePosition;
                Vector3 force = (initMousePosition - endMousePosition) * pushForce;
                float scaling = force.magnitude;
                if(scaling > 5)
                {
                    scaling = 5;
                }

                Indicator.transform.localScale = new Vector3(0.2f, 0.2f, scaling);
                Indicator.transform.LookAt(endMousePosition);
                Indicator.transform.Translate(new Vector3(0.0f,0.0f,-(scaling/2)), Space.Self);

            }
            Debug.Log("endMousePosition" + endMousePosition);
        }


        if (Input.GetMouseButtonUp(0) && m_GO != null)
        {
            Vector3 force = (initMousePosition - endMousePosition) * pushForce;
            if(force.magnitude > maxForce)
            {
                force = force.normalized * maxForce;
            }
            initMousePosition.Set(0, 0, 0);
            endMousePosition.Set(0, 0, 0);

            Debug.Log("force" + force);
            m_GO.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
            m_GO = null;
            Invoke("toggleTurn", 1.0f);
            Indicator.SetActive(false);
        }

    }
}

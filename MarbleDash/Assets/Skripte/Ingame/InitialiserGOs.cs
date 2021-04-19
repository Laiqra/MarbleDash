using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialiserGOs : MonoBehaviour
{
    public GameObject m_KugelPrefabRed;
    public GameObject m_KugelPrefabBlue;

    public Transform[] firstPositionLayout = new Transform[10];
    public Transform[] secondPositionLayout = new Transform[10];
    public Transform[] thirdPositionLayout = new Transform[10];
    public Transform[] fourthPositionLayout = new Transform[10];
    public Transform[] fifthPositionLayout = new Transform[10];

    private Transform[][] layouts = new Transform[5][];
    public GameObject[] Kugel = new GameObject[20];


    private int nextLayout = 0;
    public float movementSpeedThreshold;


    public bool checkForMovement()
    {
        bool movement = false;
        for(int i = 0; i < 20; i++)
        {
            if(Kugel[i] == null)
            {
                continue;
            }

            Rigidbody rig = Kugel[i].GetComponent<Rigidbody>();

            if (rig.velocity.magnitude > 0)
            {
                movement = true;
                if (rig.velocity.magnitude < movementSpeedThreshold)
                {
                    rig.velocity = new Vector3(0, 0, 0);
                    movement = false;
                }
                else
                {
                    return movement;
                }
            }
        }
        return movement;
    }
    public void Initialize()
    {
        InitializeKugeln(layouts[nextLayout]);
        nextLayout++;

    }
    private void InitializeKugeln(Transform[] transforms)
    {
        for(int i = 0; i < 20; i++)
        {
            if(Kugel[i] != null)
            {
                Destroy(Kugel[i]);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            Kugel[i] = Instantiate(m_KugelPrefabBlue, transforms[i]);
            Kugel[i].tag = "Blue";
        }

        for (int i = 10; i < 20; i++)
        {
            Kugel[i] = Instantiate(m_KugelPrefabRed, transforms[i - 10]);
            Kugel[i].transform.position = new Vector3(-Kugel[i].transform.position.x, Kugel[i].transform.position.y, -Kugel[i].transform.position.z);
            Kugel[i].tag = "Red";
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        layouts[0] = firstPositionLayout;
        layouts[1] = thirdPositionLayout;
        layouts[2] = secondPositionLayout;       
        layouts[3] = fourthPositionLayout;
        layouts[4] = fifthPositionLayout;
        //start
        Initialize();
    }
    // Update is called once per frame
    void Update()
    {

    }
}

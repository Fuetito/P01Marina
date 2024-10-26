using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio_cam : MonoBehaviour
{
    // Start is called before the first frame update

    public bool tPerson = true;
    public Transform tpTarget;
    public Transform fpTarget;
    [Header("Objetivos de cámara")]
    private new Camera camera;
    private Vector2 nearPlaneSize;
    private Transform follow;
    private float defaultDistance;

    [Header("Visibilidad de Jugador")]
    public bool disablePlayerMesh = true;
    [Space(2)]
    public GameObject playerMesh;


    public KeyCode keyCode = KeyCode.F;

    void Start()
    {
        ChangePerspective(tPerson);


    }
    void ChangePerspective(bool ThirdPerson)
    {
        if (ThirdPerson)
        {
            follow = tpTarget;

            if (disablePlayerMesh)
                playerMesh.SetActive(true);


            tPerson = true;
        }
        else if (!ThirdPerson)
        {
            follow = fpTarget;

            if (disablePlayerMesh)
                playerMesh.SetActive(false);

            tPerson = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (tPerson)
                ChangePerspective(false);
            else
                ChangePerspective(true);
        }
    }
}

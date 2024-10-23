using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveUpDown();
    }

    private void MoveUpDown()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(x, y, 0) * Speed;

        transform.Translate(velocity * Time.deltaTime);
    }
}

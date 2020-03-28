using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shot_Master : MonoBehaviour
{
    public Rigidbody RB;
    bool IsShot;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShot)
        {

            transform.Translate(new Vector3(0, 0f, .2f));
        }
    }

    public void OnShot(){
        IsShot = true;

    }

}

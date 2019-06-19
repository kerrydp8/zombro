﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnController : MonoBehaviour
{
    public float speed;
    public static bool johnActive;
    public Transform Lee;
    public Transform Chris;

    void Start()
    {
        johnActive = false; //John is not active when the scene begins.
    }

    void Update()
    {
            JohnMovement();

        if (Input.GetKeyDown(KeyCode.Alpha1)) //Player switches to Lee.
        {
            johnActive = false;
            LeeController.leeActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Player switches to Chris
        {
            johnActive = false;
            ChrisController.chrisActive = true;
        }

    }

    void JohnMovement()
    {
        if (johnActive)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            //transform.Rotate(0, Input.GetAxis("Rotate") * 60 * Time.deltaTime, 0);
            Vector3 johnMovement = new Vector3(hor, 0, ver);
            johnMovement = Vector3.ClampMagnitude(johnMovement, 1) * speed * Time.deltaTime;
            transform.Translate(johnMovement, Space.World);
            //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(johnMovement), 15f);

            /*
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            Vector3 johnMovement = new Vector3(hor, 0, ver);
            johnMovement = Vector3.ClampMagnitude(johnMovement, 1) * speed * Time.deltaTime;
            transform.Translate(johnMovement, Space.World);
            */
        }

        if (!johnActive)
        {

            if (LeeController.leeActive)
            {
                //rotate to look at the player
                transform.LookAt(Lee.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, Lee.position) > 10f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }

            if (ChrisController.chrisActive)
            {
                //rotate to look at the player
                transform.LookAt(Chris.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


                //move towards the player
                if (Vector3.Distance(transform.position, Chris.position) > 10f)
                {//move if distance from target is greater than 1
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
            }
        }
    }
}

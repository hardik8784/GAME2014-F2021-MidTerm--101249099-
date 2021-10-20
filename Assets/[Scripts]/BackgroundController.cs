/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : BackgroundController.cs
 * Description : This is the background Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything
 *                    v0.2 > Background movement changed to Horizontally(Landscape view)
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    public float horizontalSpeed;
    public float horizontalBoundary;


    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        //transform.position = new Vector3(0.0f, verticalBoundary);
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    private void _Move()
    {
        //transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        //// if the background is lower than the bottom of the screen then reset
        //if (transform.position.y <= -verticalBoundary)
        //{
        //    _Reset();
        //}

        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}

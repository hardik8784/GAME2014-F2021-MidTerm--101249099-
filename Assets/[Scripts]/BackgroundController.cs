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

    public float horizontalSpeed;                                   // This variable is used for Horizontal Speed for the Background
    public float horizontalBoundary;                                //This variable is used to see the Bound for the Background


    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        //transform.position = new Vector3(0.0f, verticalBoundary);
        transform.position = new Vector3(horizontalBoundary, 0.0f);             //It will reset with the position with HorizontalBoundary variable, so everytime it reset with that position
    }

    private void _Move()
    {
        //transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;          //This will move the Background in Horizontal direction with Time.deltaTime
    }

    private void _CheckBounds()
    {
        //// if the background is lower than the bottom of the screen then reset
        //if (transform.position.y <= -verticalBoundary)
        //{
        //    _Reset();
        //}

        if (transform.position.x <= -horizontalBoundary)                                //This will check the Bounds for the Background, if it is less than or equal to Horizontal boundary then it go into reset function
        {
            _Reset();
        }
    }
}

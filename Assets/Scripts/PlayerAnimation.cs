using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float takeOffRotation, landingRotation;

    private float rotZ;

    public void ApplyRotation(float velocityY)
    {
        if (rotZ > landingRotation)
        {
            float offset = 1f;
            velocityY = Math.Abs(velocityY);
            if (velocityY>0.5f) offset = velocityY;
            offset = Math.Abs(offset);
            rotZ -= rotationSpeed * Time.deltaTime / offset;
            transform.localEulerAngles = new Vector3(0, 0, rotZ);
        }
    }

    public void StartRotation()
    {
        rotZ = takeOffRotation;
    }
}

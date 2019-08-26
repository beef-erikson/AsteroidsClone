using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies thrust, rotation, and screen-wrapping to the game object
/// </summary>
public class Ship : MonoBehaviour
{
    #region Fields

    const float ThrustForce = 3f;
    const float RotateDegreesPerSecond = 60f;

    // Forward declares
    Rigidbody2D rigidbody;
    Vector2 thrustDirection = new Vector2(1, 0);

    #endregion

    #region Methods

    /// <summary>
    /// Initializations
    /// </summary>
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Rotates the ship using the rotate input axis and sets thrustDirection based on rotation
    /// </summary>
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");

        if (rotationInput != 0)
        {
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
                rotationAmount *= -1;
            transform.Rotate(Vector3.forward, rotationAmount);

            float rotationRadians = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(rotationRadians);
            thrustDirection.y = Mathf.Sin(rotationRadians);
        }
    }

    /// <summary>
    /// Increases thrust to the game object with the appropriate button press
    /// </summary>
    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
            rigidbody.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
    }

    #endregion
}

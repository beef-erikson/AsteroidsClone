using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    #region Fields

    float colliderRadius;

    #endregion

    #region Methods

    /// <summary>
    /// Gets the collider radius for bounds testings
    /// </summary>
    void Start()
    {
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Wraps object when it has left the screen.
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        if (position.x - colliderRadius > ScreenUtils.ScreenRight ||
            position.x + colliderRadius < ScreenUtils.ScreenLeft)
        {
            position.x *= -1;
        }
        if (position.y + colliderRadius < ScreenUtils.ScreenBottom ||
            position.y - colliderRadius > ScreenUtils.ScreenTop)
        {
            position.y *= -1;
        }

        transform.position = position;
    }

    #endregion
}

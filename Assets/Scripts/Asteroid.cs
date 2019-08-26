using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for the movement and selection of asteroids.
/// </summary>
public class Asteroid : MonoBehaviour
{
    #region Fields

    const float MinImpulseForce = 3f;
    const float MaxImpulseForce = 5f;

    [SerializeField]
    Sprite asteroid1;
    [SerializeField]
    Sprite asteroid2;
    [SerializeField]
    Sprite asteroid3;

    Rigidbody2D rigidbody;      // new added here to stop Unity from bitching
    SpriteRenderer spriteRenderer;

    #endregion

    #region Methods

    /// <summary>
    /// Stars moving a random asteroid in a random direction with impulse
    /// </summary>
    void Start()
    {
        // Grabs components
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Moves the asteroid
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        rigidbody.AddForce(direction * magnitude, ForceMode2D.Impulse);

        // Sets random asteroid sprite
        int choice = Random.Range(0, 3);
        if (choice == 0)
            spriteRenderer.sprite = asteroid1;
        if (choice == 1)
            spriteRenderer.sprite = asteroid2;
        if (choice == 2)
            spriteRenderer.sprite = asteroid3;
    }

    #endregion
}

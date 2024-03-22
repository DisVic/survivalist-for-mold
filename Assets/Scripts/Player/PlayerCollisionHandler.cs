using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;

    private BoxCollider2D _boxCollider;


    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    public bool CheckGround()
    {
        Vector2 colliderCenter = (Vector2)transform.position + _boxCollider.offset;
        float distanceToGround = 0.01f;

        Vector2[] raysPositions = new Vector2[3]
        {
            colliderCenter - _boxCollider.size / 2f, // Левый угол.
            new Vector2 (colliderCenter.x, colliderCenter.y - _boxCollider.size.y / 2f), // Центр.
            new Vector2 (colliderCenter.x + _boxCollider.size.x / 2f, colliderCenter.y - _boxCollider.size.y / 2f), // Правый угол
        };

        foreach (Vector2 position in raysPositions)
        {
            Collider2D hit = Physics2D.Raycast(position, -transform.up, distanceToGround, _ground).collider;

            if (hit != null) return true;
        }
        return false;
    }

}

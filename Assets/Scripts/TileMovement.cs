using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public GameObject Tile;
    void OnCollisionEnter (Collision collision)
    {
        Tile = collision.gameObject;
    }
}

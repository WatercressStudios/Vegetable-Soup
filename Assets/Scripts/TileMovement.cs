using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public GameObject Tile;

    void OnCollisionEnter (Collision collision)
    {
        Tile = collision.gameObject;

        /*
        var GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (Tile.GetComponent<TileBehaviour>().GoldOffset)
        {
            GameManager.Gold += 10;
        }
        else if (Tile.GetComponent<TileBehaviour>().DropOffset)
        {
            GameManager.Gold -= 10;
        }
        else if (Tile.GetComponent<TileBehaviour>().EnemyTrigger)
        {
            GameManager.Gold += 5;
        }
        else if (Tile.GetComponent<TileBehaviour>().TeleportTrigger)
        {
            //TODO
        }
        else if (Tile.GetComponent<TileBehaviour>().GoalCheckTrigger)
        {
            //TODO
        }
        */
    }
}

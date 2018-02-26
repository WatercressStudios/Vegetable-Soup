using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public GameObject Tile;
    void OnTriggerEnter (Collider other)
    {
        // <remarks>
        // I eventually want to remove 'Tile' and get that information from our Collider.
        // </remarks>

        GameObject Player = other.gameObject;

        if (Tile.GetComponent<TileBehaviour>().TopRight)
        {
            Vector3 moveValue = new Vector3(0,0,1.1f);
            Player.transform.position += moveValue;
            Debug.Log("You can move to the TopRight");
        }
        else if (Tile.GetComponent<TileBehaviour>().TopLeft)
        {
            Vector3 moveValue = new Vector3(1.1f, 0, 0);
            Player.transform.position -= moveValue;
            Debug.Log("You can move to the TopLeft");
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomRight)
        {
            Vector3 moveValue = new Vector3(1.1f, 0, 0);
            Player.transform.position += moveValue;
            Debug.Log("You can move to the BottomRight");
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomLeft)
        {
            Vector3 moveValue = new Vector3(0, 0, 1.1f);
            Player.transform.position -= moveValue;
            Debug.Log("You can move to the BottomLeft");
        }
        else
        {
            Debug.Log("You apparently can't move anywhere!");
        }

    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Object is within trigger");
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Object exited the trigger");
    }
}

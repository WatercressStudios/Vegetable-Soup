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

        StartCoroutine(MovementWait());

        GameObject Player = other.gameObject;

        if (Tile.GetComponent<TileBehaviour>().TopRight)
        {
            StartCoroutine(MovementWait());
            Vector3 moveValue = new Vector3(0,0,1.1f);
            Player.transform.position += moveValue;
        }
        else if (Tile.GetComponent<TileBehaviour>().TopLeft)
        {
            StartCoroutine(MovementWait());
            Vector3 moveValue = new Vector3(1.1f, 0, 0);
            Player.transform.position -= moveValue;
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomRight)
        {
            StartCoroutine(MovementWait());
            Vector3 moveValue = new Vector3(1.1f, 0, 0);
            Player.transform.position += moveValue;
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomLeft)
        {
            StartCoroutine(MovementWait());
            Vector3 moveValue = new Vector3(0, 0, 1.1f);
            Player.transform.position -= moveValue;
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

    IEnumerator MovementWait()
    {
        yield return new WaitForSeconds(1);
    }
}

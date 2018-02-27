using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _turnCounter = 0;
    private int _moveRoll;
    public int frame;

    void Start ()
    {
        StartCoroutine(Example());
	}

    void Update()
    {
        if (frame <= 10)
        {
            Debug.Log("Frame: " + frame);
            frame++;
        }
    }

    public void GameSequence()
    {
        _turnCounter++;
        _moveRoll = GenerateRandomNumber();
        Debug.Log(_moveRoll);

        for (int movements = 0; movements < _moveRoll; movements++)
        {
            Debug.Log("Making a movement!");
            MoveCharacter();
        }
    }

    IEnumerator Example()
    {
        yield return new WaitUntil(() => frame >= 10);
        GameSequence();
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(1, 6);
    }

    public void MoveCharacter()
    {
        var Player = GameObject.Find("Character");
        var Tile = GameObject.Find("Character").GetComponent<TileMovement>().Tile;

        Debug.Log("Tile is: " + Tile.name);

        if (Tile.GetComponent<TileBehaviour>().TopRight)
        {
            Debug.Log("Top right");
            Vector3 moveValue = new Vector3(0, 0, 1.1f);
            Player.transform.position += moveValue;
        }
        else if (Tile.GetComponent<TileBehaviour>().TopLeft)
        {
            Debug.Log("Top left");
            Vector3 moveValue = new Vector3(1.1f, 0, 0);
            Player.transform.position -= moveValue;
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomRight)
        {
            Debug.Log("Bottom right");
            Vector3 moveValue = new Vector3(1.1f, 0, 0);
            Player.transform.position += moveValue;
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomLeft)
        {
            Debug.Log("Bottom left");
            Vector3 moveValue = new Vector3(0, 0, 1.1f);
            Player.transform.position -= moveValue;
        }
        else
        {
            Debug.Log("You apparently can't move anywhere!");
        }
    }
}

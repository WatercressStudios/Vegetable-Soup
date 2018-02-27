using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _turnCounter;
    private int _moveRoll;
    private int _frame;
    private Vector3 _rightOffset = new Vector3(0, 0, 1.1f);
    private Vector3 _leftOffset = new Vector3(1.1f, 0, 0);
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Character");
        StartCoroutine(InitializeGame());
    }

    IEnumerator InitializeGame()
    {
        yield return new WaitUntil(() => _frame >= 10);
        GameSequence();
    }

    void Update()
    {
        if (_frame < 10)
        {
            _frame++;
        }
    }

    public void GameSequence()
    {
        _turnCounter++;
        _moveRoll = GenerateRandomNumber();

        for (int movements = 0; movements < _moveRoll; movements++)
        {
            MoveCharacter();
        }
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(1, 6);
    }

    public void MoveCharacter()
    {
        var Tile = GameObject.Find("Character").GetComponent<TileMovement>().Tile;

        if (Tile.GetComponent<TileBehaviour>().TopRight)
        {
            _player.transform.position += _rightOffset;
        }
        else if (Tile.GetComponent<TileBehaviour>().TopLeft)
        {
            _player.transform.position -= _leftOffset;
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomRight)
        {
            _player.transform.position += _leftOffset;
        }
        else if (Tile.GetComponent<TileBehaviour>().BottomLeft)
        {
            _player.transform.position -= _rightOffset;
        }
    }
}

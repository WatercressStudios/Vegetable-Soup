using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private int _turnCounter;
    private int _moveRoll;
    private int _frame;
    private Vector3 _rightOffset = new Vector3(0, 0, 1.1f);
    private Vector3 _leftOffset = new Vector3(1.1f, 0, 0);
    private GameObject _player;
    private GameObject _tile;

    public Text RollText;
    public Text TurnText;

    void Start()
    {
        _player = GameObject.Find("Character");
    }

    void Update()
    {
        if (_moveRoll == 0 && Input.GetKeyDown("r"))
        {
            GameSequence();
        }
        else if (_moveRoll > 0 && Input.GetKeyDown("m"))
        {
            MoveCharacter();
            _moveRoll--;
        }
    }

    public void GameSequence()
    {
        _turnCounter++;
        SetTurnText();
        _moveRoll = GenerateRandomNumber();
        SetRollText();
    }

    public void MoveCharacter()
    {
        _tile = GameObject.Find("Character").GetComponent<TileMovement>().Tile;

        if (_tile.GetComponent<TileBehaviour>().TopRight)
        {
            _player.transform.position += _rightOffset;
        }
        else if (_tile.GetComponent<TileBehaviour>().TopLeft)
        {
            _player.transform.position -= _leftOffset;
        }
        else if (_tile.GetComponent<TileBehaviour>().BottomRight)
        {
            _player.transform.position += _leftOffset;
        }
        else if (_tile.GetComponent<TileBehaviour>().BottomLeft)
        {
            _player.transform.position -= _rightOffset;
        }
        else
        {
            Debug.Log("Can't Move!");
        }
    }

    public int GenerateRandomNumber()
    {
        return UnityEngine.Random.Range(1, 6);
    }

    public void SetRollText()
    {
        RollText.text = "Current Roll: " + _moveRoll.ToString();
    }

    public void SetTurnText()
    {
        TurnText.text = "Current Turn: " + _turnCounter.ToString();
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        MoveCharacter();
    }
}

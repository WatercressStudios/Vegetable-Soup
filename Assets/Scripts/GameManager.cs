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
    private bool _tileEffectsFlag;

    public Text RollText;
    public Text TurnText;
    public Text CurrentOption;
    public Text GoldText;
    public Text WinText;
    public int Gold;

    void Start()
    {
        _player = GameObject.Find("Character");
        SetGoldText();
        SetGoalText();
    }

    void Update()
    {
        if (_tileEffectsFlag == true)
        {
            TileEffects();
            SetGoldText();
        }

        if (_moveRoll == 0)
        {
            SetCurrentOptionToRoll();
        }
        else
        {
            SetCurrentOptionToMove();
        }


        if (_moveRoll == 0 && Input.GetKeyDown("r"))
        {
            GameSequence();
        }
        else if (_moveRoll > 0 && Input.GetKeyDown("m"))
        {
            MoveCharacter();
            _moveRoll--;

            if (_moveRoll == 0)
            {
                _tileEffectsFlag = true;
            }
        }
    }

    public void GameSequence()
    {
        _turnCounter++;
        SetTurnText();
        _moveRoll = GenerateRandomNumber();
        SetRollText();
    }

    public void TileEffects()
    {
        _tile = GameObject.Find("Character").GetComponent<TileMovement>().Tile;

        if (_tile.GetComponent<TileBehaviour>().GoldOffset)
        {
            Gold += 15;
        }
        else if (_tile.GetComponent<TileBehaviour>().DropOffset)
        {
            if (Gold >= 10)
            {
                Gold -= 10;
            }
        }
        else if (_tile.GetComponent<TileBehaviour>().EnemyTrigger)
        {
            Gold += 5;
        }
        else if (_tile.GetComponent<TileBehaviour>().TeleportTrigger)
        {
            //TODO
        }
        else if (_tile.GetComponent<TileBehaviour>().GoalCheckTrigger)
        {
            if (Gold >= 40)
            {
                SetWinText();
            }
        }

        _tileEffectsFlag = false;
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

    public void SetCurrentOptionToRoll()
    {
        CurrentOption.text = "Press R to roll!";
    }

    public void SetCurrentOptionToMove()
    {
        CurrentOption.text = "Press M to move!";
    }

    public void SetGoldText()
    {
        GoldText.text = "Gold: " + Gold.ToString();
    }

    public void SetWinText()
    {
        WinText.text = "You win!";
    }

    public void SetGoalText()
    {
        WinText.text = "Collect 40 gold to win!";
    }
}

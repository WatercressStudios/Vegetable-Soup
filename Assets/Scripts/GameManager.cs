using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _turnCounter = 0;
    private int _moveRoll;

	void Start ()
    {
        GameSequence();
	}

    public void GameSequence()
    {
        _turnCounter++;
        _moveRoll = GenerateRandomNumber();
        Debug.Log(_moveRoll);
    }

    public int GenerateRandomNumber()
    {
        return Random.Range(1, 6);
    }
}

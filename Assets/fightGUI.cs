using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightGUI : MonoBehaviour {

    public static fightGUI _instance;
    public bool pressed = false;
    public int roll_button_width = 100;
    public int roll_button_height = 30;
    public int roll_button_x_coord = Screen.width - (Screen.width / 2) - 50;
    public int roll_button_y_coord = Screen.height - (Screen.height / 2) - 15;

    void OnGUI()
    {
        // Rect(*x-coord, *y-coord, *x-width, *y-width)
        if (GUI.Button(new Rect(roll_button_x_coord, roll_button_y_coord, roll_button_width, roll_button_height), "Click to Roll"))
        {
            pressed = !pressed;
        }
    }

	// Use this for initialization
	void Start () {
		if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(_instance);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

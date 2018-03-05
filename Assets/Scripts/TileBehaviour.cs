using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour {
    [SerializeField]
    public bool TopRight;
    [SerializeField]
    public bool TopLeft;
    [SerializeField]
    public bool BottomRight;
    [SerializeField]
    public bool BottomLeft;
    [SerializeField]
    public bool GoldOffset;
    [SerializeField]
    public bool DropOffset;
    [SerializeField]
    public bool EnemyTrigger;
    [SerializeField]
    public bool TeleportTrigger;
    [SerializeField]
    public bool GoalCheckTrigger;
}

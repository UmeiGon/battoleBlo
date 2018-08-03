using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : SingleTon<PlayerInfo> {
    public Army team;
    public bool IsOnline;
}

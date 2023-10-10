using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.OpenSoccerGame();
    }
}

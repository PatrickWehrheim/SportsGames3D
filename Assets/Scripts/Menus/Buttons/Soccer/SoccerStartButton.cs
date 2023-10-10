using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerStartButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowSoccerGameScene();
    }
}

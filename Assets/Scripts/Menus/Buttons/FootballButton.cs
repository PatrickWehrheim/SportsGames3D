using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.OpenFootballGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.OpenTennisGame();
    }
}

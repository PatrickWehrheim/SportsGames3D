using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBackToMenuButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.OnBackToSoccerMenu();
    }
}

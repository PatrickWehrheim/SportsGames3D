using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerTutorialButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowSoccerTutorialScene();
    }
}

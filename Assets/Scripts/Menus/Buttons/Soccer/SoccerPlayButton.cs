using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowSoccerSelectScene();
    }
}

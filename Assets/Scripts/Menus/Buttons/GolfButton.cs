using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.OpenGolfGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealSportsButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowRealSportsMenu();
    }
}

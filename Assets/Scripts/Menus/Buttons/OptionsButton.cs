using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowOptionsMenu();
    }
}

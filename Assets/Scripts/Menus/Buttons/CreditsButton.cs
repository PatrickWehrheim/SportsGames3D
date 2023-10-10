using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowCreditsMenu();
    }
}

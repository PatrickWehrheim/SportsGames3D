using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.OnBack();
    }
}

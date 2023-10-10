using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESportsButton : ButtonBase
{
    public override void OnClick()
    {
        _menuController.ShowESportsMenu();
    }
}

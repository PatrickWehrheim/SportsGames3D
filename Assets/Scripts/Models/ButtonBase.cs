using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    protected IMenuController _menuController;

    protected void Awake()
    {
        _menuController = MenuManager.Instance.MenuController;
    }

    /// <summary>
    /// Gets called f the button is clicked
    /// </summary>
    public abstract void OnClick();
}

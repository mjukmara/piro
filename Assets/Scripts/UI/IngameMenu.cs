using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenu : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        GameEvents.Instance.ExitToMainMenu();
    }
}

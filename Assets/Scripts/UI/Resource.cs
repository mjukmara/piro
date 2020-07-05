using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource : MonoBehaviour
{
    public ResourceData.TYPE type;
    public TextMeshProUGUI updateText;

    void Start()
    {
        
    }

    void Update() {
        if (!Game.Instance) return;
        if (Game.Instance.gameState == null) return;
        if (Game.Instance.gameState.resourceData == null) return;

        if (updateText != null) {
            updateText.text = Game.Instance.gameState.resourceData.GetResource(type).ToString("#,##0");
        }
    }
}

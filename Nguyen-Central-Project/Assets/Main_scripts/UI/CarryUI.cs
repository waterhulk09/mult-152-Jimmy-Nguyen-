using TMPro;
using UnityEngine;

public class CarryUI : MonoBehaviour
{
  public PlayerGrab playerGrab;

  public TextMeshProUGUI carryInfoText;

public PlayerJump playerJump;
    void Update()
    {
        carryInfoText.text = "Carrying: " + playerGrab.carriedItemName + "\nWeight: " + playerGrab.carriedWeight + "\nJump Force:" + playerJump.CurrentJumpForce.ToString("F1");
    } 

}

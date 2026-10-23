using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class UITest : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (EventSystem.current == null)
            {
                Debug.Log("No EventSystem in scene!");
                return;
            }

            var data = new PointerEventData(EventSystem.current)
            {
                position = Mouse.current.position.ReadValue()
            };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(data, results);

            Debug.Log(results.Count == 0
                ? "Click hit no UI at all"
                : "Top UI hit: " + results[0].gameObject.name);
        }
    }
}

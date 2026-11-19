using UnityEngine;
using UnityEngine.InputSystem;

public class SaveLoadInput : MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem;

    private InputAction saveAction;
    private InputAction loadAction;

    private void Awake()
    {
        var actions = InputSystem.actions;
        if (actions != null)
        {
            saveAction = actions.FindAction("Player/Save", throwIfNotFound: false);
            loadAction = actions.FindAction("Player/Load", throwIfNotFound: false);
        }
    }

    private void OnEnable()
    {
        if (saveAction != null)
        {
            saveAction.performed += OnSavePerformed;
        }

        if (loadAction != null)
        {
            loadAction.performed += OnLoadPerformed;
        }
    }

    private void OnDisable()
    {
        if (saveAction != null)
        {
            saveAction.performed -= OnSavePerformed;
        }

        if (loadAction != null)
        {
            loadAction.performed -= OnLoadPerformed;
        }
    }

    private void OnSavePerformed(InputAction.CallbackContext ctx)
    {
        Save();
    }

    private void OnLoadPerformed(InputAction.CallbackContext ctx)
    {
        Load();
    }

    public void Save()
    {
        if (saveSystem != null)
        {
            saveSystem.SaveGame();
        }
    }

    public void Load()
    {
        if (saveSystem != null)
        {
            saveSystem.LoadGame();
        }
    }
}
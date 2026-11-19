using System.IO;
using UnityEngine;
 
public class SaveSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Transform playerTransform;

    private string savePath;

private void Awake()
{
    savePath = Path.Combine(
    Application.persistentDataPath,
    "save.json");
}
private void Start()
{
LoadGame();
}

public void SaveGame()
{
    SaveData data = new SaveData();

    data.playerHealth = playerHealth.CurrentHealth;
    data.playerPosX = playerTransform.position.x;
    data.playerPosY = playerTransform.position.y;
    data.playerPosZ = playerTransform.position.z;
    string json = JsonUtility.ToJson(data, true);
    File.WriteAllText(savePath, json);
    Debug.Log($"Game Saved:\n{savePath}");
    }

    public void LoadGame()
{
    if (!File.Exists(savePath))
    {
        Debug.Log("No save file found.");
        return;
    }

    string json = File.ReadAllText(savePath);

    SaveData data = JsonUtility.FromJson<SaveData>(json);

    playerHealth.SetHealth(data.playerHealth);

    Vector3 loadedPosition = new Vector3(data.playerPosX, data.playerPosY, data.playerPosZ);

    CharacterController controller = playerTransform.GetComponent<CharacterController>();

    if (controller != null)
    {
        controller.enabled = false;
    }

    playerTransform.position = loadedPosition;

    if (controller != null)
    {
        controller.enabled = true;
    }

    Debug.Log("Game Loaded");
}

public void DeleteSave()
{
    if (File.Exists(savePath))
    {
        File.Delete(savePath);
   
        Debug.Log("Save Deleted");
    }
}
}
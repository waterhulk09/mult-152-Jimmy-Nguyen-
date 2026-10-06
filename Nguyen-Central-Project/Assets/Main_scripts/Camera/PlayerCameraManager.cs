using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraManager : MonoBehaviour
{

   [Header("Camera Objects")]
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;

[Header("Input Actions")]
public InputActionReference toggleCameraAction;
public InputActionReference aimAction;

public PlayerTargeting targeting;
public InputActionReference lockOnAction;

[Header("Current Mode")]
    public CameraMode currentMode = CameraMode.ThirdPerson;

    private CameraMode previousMode;

    private void OnEnable()
    {
        toggleCameraAction.action.Enable();
        aimAction.action.Enable();
        lockOnAction.action.Enable();
    }

    private void OnDisable()
    {
        toggleCameraAction.action.Disable();
        aimAction.action.Disable();
        lockOnAction.action.Disable();
    }

    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;

       UpdateCameraState();
    }

    void Update()
    {
       HandleToggleCamera();
       HandleAimMode();

       if(lock.action.triggered)
        {
            targeting.ToggleLock();
        }
    }

void HandleToggleCamera()
    {
        if (!toggleCameraAction.action.triggered)
        {
            return;
        }

        if (currentMode == CameraMode.FirstPerson)
        {
            currentMode = CameraMode.ThirdPerson;
        }
        else
        {
            currentMode = CameraMode.FirstPerson;
        }
       
        updateCameraState();
    }


void ToggleMode()
    {
        if (currentMode == CameraMode.FirstPerson)
        {
            currentMode = CameraMode.ThirdPerson;
           
        }
        else
        {
            currentMode = CameraMode.FirstPerson;
            
        }
        
        UpdateCameraMode();
    }
   
   
           Void HandleAimMode()
        {

            if (currentMode == CameraMode.FirstPerson)
            {
                return;
            
            }

            if (aimAction.action.IsPressed())
            {
                 if (currentMode = CameraMode.FocusAim);
                 {
                    currentMode = CameraMode.ThirdPerson;

                    updateCameraState();
                 }
            }
            else
            {
                currentMode = CameraMode.ThirdPerson;
            }


void UpdateCameraState()

        {
          switch(currentMode)
            {
                case CameraMode.FirstPerson:
                    firstPersonCamera.SetActive(true);
                    thirdPersonCamera.SetActive(false);
                    break;
               
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                break;

                case CameraMode.ThirdPerson:
                    firstPersonCamera.SetActive(false);
                    thirdPersonCamera.SetActive(true);
                    break;

                case CameraMode.FocusAim:
                    firstPersonCamera.SetActive(false);
                    thirdPersonCamera.SetActive(true);
                    break;
             }
        }
          }
        
        
        public bool IsFirstPerson()
           {
               return currentMode == CameraMode.FirstPerson;
           }

           public bool IsThirdPerson()
           {
               return currentMode == CameraMode.ThirdPerson;
           }

           public bool IsFocusAim()
           {
               return currentMode == CameraMode.FocusAim;
           }


           
        
        }
        
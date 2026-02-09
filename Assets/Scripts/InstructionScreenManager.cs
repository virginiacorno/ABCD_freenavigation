using UnityEngine;

public class InstructionScreenManager : MonoBehaviour
{
    public FreeNavigationCamera cameraManager;
    //public CameraManager cameraManager;
    public rewardManager rewardManager;
    public GameObject instructionPanel;
    public GameObject newSeqPanel; //V: screen signalling sequence change
    public GameObject endPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("InstructionScreenManager Start() called");
        ShowInstruction();
    }

    public void ShowInstruction()
    {
        Debug.Log("ShowInstruction() called");
        instructionPanel.SetActive(true);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);
        Time.timeScale = 0f; //V: pause everything else
    }

    public void OnStartButton()
    {
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);
        Time.timeScale = 1f;

        cameraManager.StartNewConfiguration(0); //V: actually start the game
    }

    public void NewSequenceInstructions()
    {
        
        Debug.Log("NewSequenceInstructions() called");
        newSeqPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnContinueButton()
    {
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        Time.timeScale = 1f; //V: resume the game
        CameraManager camManager = FindFirstObjectByType<CameraManager>();
        FreeNavigationCamera freeNavCam = FindFirstObjectByType<FreeNavigationCamera>();

        if (camManager != null && camManager.enabled)
        {
            rewardManager.StartNextConfiguration();
            
        } else if (freeNavCam != null && freeNavCam.enabled)
        {
            rewardManager.StartNextConfigForFreeNav();
        }
    }

    public void EndScreen()
    {
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(true);
    }
}

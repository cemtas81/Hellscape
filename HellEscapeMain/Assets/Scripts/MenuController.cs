using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	[SerializeField] private GameObject quitButton;
	MyController actions;
	public AudioMixer audioMixer;
	public GameObject optionsPanel,creditsPanel,quitPanel, storyPanel, controlPanel;
	public GameObject StartFirstB,optionsFirstB;
	Resolution[] resolutions;
	public TMP_Dropdown resolutionDropdown;
	private int currentResIndex = 0;
    // Use this for initialization
    private void Awake()
	{
		
		actions=new MyController();
		actions.MyGameplay.Submit.started+=sbm=>SubmitAct();
       
        actions.MyGameplay.Geri.started+=sbm=>Back();
	}
	private void OnEnable()
	{
		actions.Enable();
	}
	private void OnDisable()
	{
		actions.Disable();
	}
	void Start()
	{
//#if UNITY_STANDALONE || UNITY_EDITOR
//		quitButton.SetActive(true);
//#endif
        Time.timeScale = 1.0f;
        EventSystem.current.SetSelectedGameObject(StartFirstB);
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Back();
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (quitPanel.activeInHierarchy == false&&controlPanel.activeInHierarchy==false)
			{
                SubmitAct();
            }

        }
	}
	public void SetResolution(int resIndex)
	{
		Resolution resolution = resolutions[resIndex];
		Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
	}
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume",volume);
	}
	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);	
	}
	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen=isFullscreen;
	}
	public void Back()
	{
		if (!storyPanel.activeInHierarchy)
		{
            optionsPanel.SetActive(false);
            controlPanel.SetActive(false);
            creditsPanel.SetActive(false);
            quitPanel.SetActive(false);
        }
		EventSystem.current.SetSelectedGameObject(StartFirstB);
	}
	public void SubmitAct()
	{
	
		if (storyPanel.activeInHierarchy)
		{
            controlPanel.SetActive(true);
  
        }
		
		if (quitPanel.activeInHierarchy)
		{
			QuitGame();
		}
		if (controlPanel.activeInHierarchy )
		{
			PlayGame();
		}
		
	}
	
	public void PlayGame() 
	{

		//StartCoroutine(ChangeScene("Procedural game"));
		StartCoroutine(ChangeScene(1));
    }

	IEnumerator ChangeScene(int scene) {
		yield return new WaitForSeconds(.5f);
		SceneManager.LoadScene(scene);
	}

	public void QuitGame() 
	{
		StartCoroutine(Quit());
	}
	
	IEnumerator Quit () {
		yield return new WaitForSeconds(.2f);
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}

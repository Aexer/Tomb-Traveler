using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

	public void LoadBySceneName(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void LoadBySceneIndex(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void Quit()
	{
		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}
}
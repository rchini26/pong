using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class OpenSceneHelper : MonoBehaviour
{
  public string sceneToOpen;

  public void OpenScene()
  {
    SceneManager.LoadScene(sceneToOpen);
  }
}

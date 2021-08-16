using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour, ISceneController
{
    [Tooltip("Attach the action decoder object here")]
    [SerializeField] DirectorActionDecoder _directorActionDecoder;

    // Start is called before the first frame update
    void Start()
    {
        if (_directorActionDecoder == null)
        {
            Debug.LogError("Scene Controller doesn't have a action decoder to attach to");
        }
        else
        {
            _directorActionDecoder.SetSceneController(this);
        }

    }

    public void FadeIn(float seconds)
    {
        Debug.LogWarning("FadeIn not implemented");
    }

    public void FadeOut(float seconds)
    {
        Debug.LogWarning("FadeOut not implemented");
    }

    public void PanCamera(float seconds, int xEnd, int yEnd)
    {
        Debug.LogWarning("PanCamera not implemented");
    }

    public void SetBackground(string background)
    {
        Debug.LogWarning("SetBackground not implemented");
    }

    public void SetCameraPos(int x, int y)
    {
        Debug.LogWarning("SetCameraPos not implemented");
    }

    public void ShakeScreen(float intensity)
    {
        Debug.LogWarning("ShakeScreen not implemented");
    }

    public void ShowItem(string item, itemPosition pos)
    {
        Debug.LogWarning("ShowItem not implemented");
    }
}

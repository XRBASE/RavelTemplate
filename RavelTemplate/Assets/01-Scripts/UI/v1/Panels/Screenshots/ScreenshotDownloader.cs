using UnityEngine;
using UnityEngine.Events;

public class ScreenshotDownloader : MonoBehaviour
{
    [SerializeField] private string fileName = "ravel-screenshot";
    [SerializeField] private Transform _sizeMin, _sizeMax;
    [SerializeField] private UnityEvent _beforeScreenshot, _afterScreenshot;

    /// <summary>
    /// Take a screenshot and download it. (Downloads folder in webGL and Assets/Screenshots in editor).
    /// </summary>
    public void DownloadScreenshot() { }
}

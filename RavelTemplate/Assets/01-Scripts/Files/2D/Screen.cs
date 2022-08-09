using UnityEngine;

namespace Base.Ravel.Files
{
    public class Screen : FileLoader
    {
        [Tooltip("Canvas object for screen space, canvas will not be scaled, but content will be placed within the canvas bounds (PDF scales to width of canvas).")]
        [SerializeField] private Canvas _canvas;
    }
}
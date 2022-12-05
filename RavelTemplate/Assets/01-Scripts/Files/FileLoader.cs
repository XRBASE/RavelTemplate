using UnityEngine;

namespace Base.Ravel.Files
{
    public abstract class FileLoader : MonoBehaviour
    {
        /// <summary>
        /// Id, if it is higher than 0 the item will be marked as a persistent item. Otherwise the FileLoaderManager will generate an appopriate Id when needed.
        /// </summary>
        [Tooltip("Any screen or model should have this id set to anything that is not 0. No duplicate ids can be used within one scene.")]
        [SerializeField]
        protected int _id = 0;
        [Tooltip("A collider with the same size as the screen (Model auto scales). Selection visual will match given size and selection can only be performed on this collider.")]
        [SerializeField] protected BoxCollider _collider;
    }
}
using UnityEngine;

namespace PlateauToolkit.Sandbox
{
    /// <summary>
    /// The definition of a prop
    /// TODO: Delete this class after creating a new prop class.
    /// </summary>
    [SelectionBase]
    public class PlateauSandboxProp : MonoBehaviour, IPlateauSandboxPlaceableObject
    {
        public void SetPosition(in Vector3 position)
        {
            transform.position = position;
        }
    }
}
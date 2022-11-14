using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Base.Ravel.Unique
{
    public class TalentScanRegistrationService : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _firstName;
        [SerializeField] private TMP_InputField _lastName;
        [SerializeField] private TMP_InputField _email;
        [SerializeField] private TMP_InputField _phoneNumber;
        [SerializeField] private Toggle _permission;
        [SerializeField] private Button _submit;
    }
}

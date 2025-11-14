using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;

    private ISelectionResponse _selectionResponse;

    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        if (_selection != null)
        {
            _selectionResponse.OnSelect(_selection);
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        if (_selection != null)
        {
            _selectionResponse.OnDeselect(_selection);
        }
    }
}

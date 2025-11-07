using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;

    private HighlightSelectionResponse selectionResponse;

    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
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

internal class HighlightSelectionResponse : Monobehavior
{
    [SerializeField] public Material highlightMaterial;
    [SerializeField] public Material defaultMaterial;

    private void OnSelect(Transform selection)
    {
        var selectionRenderer = _selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = _selectionResponse.defaultMaterial;
        }
    }

    private void OnDeselect(Transfrom selection)
    {
        var selectionRenderer = _selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = _selectionResponse.highlightMaterial;
        }
    }
}
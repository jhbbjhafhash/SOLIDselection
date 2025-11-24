using System.Security.Cryptography;
//using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private Transform _currentSelection;
    private Transform _selection;
    private ISelectionResponse _selectionResponse;

    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        if (_currentSelection != null) _selectionResponse.OnSelect(_currentSelection);
  
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if (_currentSelection != null) _selectionResponse.OnDeselect(_currentSelection);
    }
}

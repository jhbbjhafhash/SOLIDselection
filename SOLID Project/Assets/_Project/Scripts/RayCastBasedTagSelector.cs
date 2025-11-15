using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBasedTagSelector : MonoBehaviour, ISelector
{
        [SerializeField] public string selectableTag = "Selectable";
        public Transform _selection;

          public void Check(Ray ray)
    {
        // Selection Determination
        this._selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(this.selectableTag))
            {
                this._selection = selection;
            }
        }
    }

        public Transform GetSelection()
    {
        return _selection;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public GameObject[] childButtons;
    public float expandDuration = 1f;
    public Vector3 expandedScale = new Vector3(1f, 1f, 1f);

    private Vector3[] originalScales;
    private bool isExpanded = false;

    private void Start()
    {
        originalScales = new Vector3[childButtons.Length];
        for (int i = 0; i < childButtons.Length; i++)
        {
            originalScales[i] = childButtons[i].transform.localScale;
            childButtons[i].SetActive(false);
        }
    }

    public void ToggleButtons()
    {
        if (isExpanded)
            CollapseButtons();
        else
            ExpandButtons();

        isExpanded = !isExpanded;
    }

    private void ExpandButtons()
    {
        for (int i = 0; i < childButtons.Length; i++)
        {
            childButtons[i].SetActive(true);
            LeanTween.scale(childButtons[i], expandedScale, expandDuration).setEaseOutBack();
        }
    }

    private void CollapseButtons()
    {
        for (int i = 0; i < childButtons.Length; i++)
        {
            LeanTween.scale(childButtons[i], originalScales[i], expandDuration).setEaseInBack();
        }
    }
}

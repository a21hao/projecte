using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonAnimation : MonoBehaviour
{
    public GameObject[] childButtons;
    public float expandDuration = 0.5f;
    public Vector3 expandedScale = new Vector3(1.5f, 1.5f, 1.5f);

    private Vector3[] originalScales;

    private void Start()
    {
        originalScales = new Vector3[childButtons.Length];
        for (int i = 0; i < childButtons.Length; i++)
        {
            originalScales[i] = childButtons[i].transform.localScale;
            childButtons[i].SetActive(false);
        }
    }

    public void ExpandButtons()
    {
        for (int i = 0; i < childButtons.Length; i++)
        {
            childButtons[i].SetActive(true);
            LeanTween.scale(childButtons[i], expandedScale, expandDuration).setEaseOutBack();
        }
    }

    public void CollapseButtons()
    {
        for (int i = 0; i < childButtons.Length; i++)
        {
            LeanTween.scale(childButtons[i], originalScales[i], expandDuration).setEaseInBack().setOnComplete(() =>
            {
                childButtons[i].SetActive(false);
            });
        }
    }
}

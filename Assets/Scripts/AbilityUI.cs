using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;

    public float Timer { get; set; }

    public void OnActivated()
    {
        image.fillAmount = 1;
        button.enabled = false;
    }

    private void Update()
    {
        if (image.fillAmount > 0)
            image.fillAmount -= 1 / Timer * Time.deltaTime;
        else
            button.enabled = true;
    }
}
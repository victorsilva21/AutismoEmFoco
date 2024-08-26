using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _releasedButtonText;
    [SerializeField] private GameObject _clickedButtonText;
    [SerializeField] private AudioSource _buttonSfx;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _releasedButtonText.SetActive(false);
        _clickedButtonText.SetActive(true);
        _buttonSfx.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _releasedButtonText.SetActive(true);
        _clickedButtonText.SetActive(false);
    }
}

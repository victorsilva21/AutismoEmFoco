using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private GameObject _disableHud, _activeHud;
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeActiveHud);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeActiveHud()
    {
        _disableHud.SetActive(false);
        _activeHud.SetActive(true);
    }
}

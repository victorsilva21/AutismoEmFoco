using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcDialogue : MonoBehaviour
{
    [SerializeField] private List<string> _strings = new List<string>();
    [SerializeField] private GameObject _dialogueHud, _expression1, _expression2, _floatingJoy;
    [SerializeField] private SceneAsset _sceneToCall;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private bool _destroySelf = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Time.timeScale = 0;
            StartCoroutine(DialogueCourotine());
        }

    }
    private IEnumerator DialogueCourotine()
    {
        _dialogueHud.SetActive(true);
        _expression1.SetActive(true);
        _floatingJoy.SetActive(false);

        foreach (var item in _strings)
        {
            _text.text = item;
            yield return new WaitUntil(() => Input.touchCount == 0);
            yield return new WaitUntil(() => Input.touchCount > 0);
            if (_expression1.activeInHierarchy)
            {
                _expression1.SetActive(false);
                _expression2.SetActive(true);
            }
            else
            {
                _expression1.SetActive(true);
                _expression2.SetActive(false);
            }
        }
        _floatingJoy.SetActive(true);
        _expression1.SetActive(false);
        _expression2.SetActive(false);
        _dialogueHud.SetActive(false);

        Time.timeScale = 1;

        if (_sceneToCall != null)
            SceneManager.LoadSceneAsync(_sceneToCall.name);

        if (_destroySelf == true)
            Destroy(this.gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<ObjectDrag> _puzzlePieces = new List<ObjectDrag>();
    [SerializeField] private int _piecesToVictory;
    [SerializeField] private SceneAsset _scene;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private AudioSource _audioSource;
    private int _correctPiecesCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in _puzzlePieces)
        {
            item.SubscribeToFinishedEvent(OnFinishedPiece);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnFinishedPiece(bool value)
    {
        if (value == true)
        {
            _correctPiecesCount++;
        }
        if (_correctPiecesCount >= _piecesToVictory)
        {

            Debug.Log("vitoria total");
            foreach (var item in _puzzlePieces)
            {
                item.UnsubscribeToFinishedEvent(OnFinishedPiece);
            }
            StartCoroutine(SceneChangeTimer());
        }
    }
    private IEnumerator SceneChangeTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        _victoryScreen.SetActive(true);
        _audioSource.Play();
        yield return new WaitUntil(() => Input.touchCount == 0);
        yield return new WaitUntil(() => Input.touchCount > 0);
        SceneManager.LoadSceneAsync(_scene.name);
    }
}

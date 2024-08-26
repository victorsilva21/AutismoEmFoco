using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets = new List<GameObject>();
    [SerializeField] private Vector3 _offset;
    [SerializeField] private GameObject _goalObject, _goalObject2;
    [SerializeField] private GameObject _vfx;
    [SerializeField] private GameObject _blockXImage;
    [SerializeField] private GameObject _blockYImage;
    [SerializeField] private AudioSource _audioSource;
    private bool _blockX = false;
    private bool _blockY = false;
    private bool _finished = false;
    public UnityAction<bool> FinishedEvent;


    public void SubscribeToFinishedEvent(UnityAction<bool> action)
    {

        FinishedEvent += action;

    }
    public void UnsubscribeToFinishedEvent(UnityAction<bool> action)
    {

        FinishedEvent -= action;

    }

    private void OnMouseDown()
    {
        if (Input.touchCount > 0 && !_finished)
        {
            Touch touch = Input.GetTouch(0);
            _offset = Camera.main.ScreenToWorldPoint(touch.position);

        }
        else if (!_finished)
        {
            _offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }
    private void OnMouseDrag()
    {
        if (Input.touchCount > 0 && !_finished)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector3 distBetweenAB = (touchPosition - _offset);
            if (Math.Abs(distBetweenAB.x) > Math.Abs(distBetweenAB.y) && (_blockX == false && _blockY == false))
            {
                _blockX = true;
                _blockXImage.transform.position = new Vector2(_blockXImage.transform.position.x, transform.position.y);
                _blockXImage.SetActive(true);

            }
            else if (Math.Abs(distBetweenAB.x) < Math.Abs(distBetweenAB.y) && (_blockX == false && _blockY == false))
            {
                _blockY = true;
                _blockYImage.transform.position = new Vector2(transform.position.x, _blockYImage.transform.position.y);
                _blockYImage.SetActive(true);
            }


            if (_blockX == true)
            {
                transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
            }
            else if (_blockY == true)
            {
                transform.position = new Vector3(transform.position.x, touchPosition.y, transform.position.z);
            }


        }
        else if (!_finished)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 distBetweenAB = (touchPosition - _offset);
            if (Math.Abs(distBetweenAB.x) > Math.Abs(distBetweenAB.y) && (_blockX == false && _blockY == false))
            {
                _blockX = true;
                _blockXImage.transform.position = new Vector2(_blockXImage.transform.position.x, transform.position.y);
                _blockXImage.SetActive(true);

            }
            else if (Math.Abs(distBetweenAB.x) < Math.Abs(distBetweenAB.y) && (_blockX == false && _blockY == false))
            {
                _blockY = true;
                _blockYImage.transform.position = new Vector2(transform.position.x, _blockYImage.transform.position.y);
                _blockYImage.SetActive(true);
            }


            if (_blockX == true)
            {
                transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
            }
            else if (_blockY == true)
            {
                transform.position = new Vector3(transform.position.x, touchPosition.y, transform.position.z);
            }
        }
    }
    private void OnMouseUp()
    {
        _blockY = false;
        _blockX = false;
        _blockYImage.SetActive(false);
        _blockXImage.SetActive(false);
        if (_targets.Count > 0 && !_finished)
        {
            GameObject _object = gameObject;
            Vector2 _destination = gameObject.transform.position;
            float _x = 5000;
            foreach (var item in _targets)
            {
                if (Vector2.Distance(gameObject.transform.position, item.transform.position) <= _x)
                {
                    _x = Vector2.Distance(gameObject.transform.position, item.transform.position);
                    _destination = item.transform.position;
                    _object = item;
                }
            }
            if (_object == _goalObject | (_goalObject2 != null && _object == _goalObject2))
            {
                Debug.Log("Vitoria");
                FinishedEvent?.Invoke(true);
                _finished = true;
                gameObject.transform.position = _destination;
                _vfx.SetActive(true);
                _audioSource.Play();
                Destroy(_object);
            }
            else
                gameObject.transform.position = _destination;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            _targets.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            _targets.Remove(other.gameObject);
        }
    }

}

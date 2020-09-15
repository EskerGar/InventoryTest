using System;
using UnityEngine;

public class BackPackSpot : MonoBehaviour
{
    [SerializeField] private ObjectTypes type;

    public ObjectTypes Type => type;

    private Transform _targetObj;
    private Vector3 _startTargetPosition;
    private bool _isSnap;
    private float _distance;
    private float _startTime;
    private ObjectBehaviour _objectBehaviour;
    
    private const float Speed = 1f;

    public void StartSnapping(Transform obj)
    {
        _targetObj = obj;
        _startTargetPosition = obj.position;
        _distance = Vector3.Distance(_startTargetPosition, transform.position);
        _startTime = Time.time;
        _isSnap = true;
        _objectBehaviour = obj.GetComponent<ObjectBehaviour>();
    }

    private void Update()
    {
        if(!_isSnap) return;
        var distCovered = (Time.time - _startTime) * Speed;
        var fracJourney = distCovered / _distance;
        _targetObj.position = Vector3.Lerp(_startTargetPosition, transform.position, fracJourney);
        if (!(Vector3.Distance(_targetObj.position, transform.position) < .1f)) return;
        _isSnap = false;
        _objectBehaviour.Put();
    }
}

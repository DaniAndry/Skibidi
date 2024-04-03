using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return _moveThreshold; } set { _moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float _moveThreshold = 1;

    protected override void Start()
    {
        MoveThreshold = _moveThreshold;
        base.Start();
        Background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        Background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > _moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - _moveThreshold) * radius;
            Background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}
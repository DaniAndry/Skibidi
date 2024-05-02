using UnityEngine;
using UnityEngine.UI;

public class FunDance : MonoBehaviour
{
    private readonly int DanceCamera = Animator.StringToHash("DanceCamera");
    private readonly int IdleState = Animator.StringToHash("Idle");

    [SerializeField] private Camera _danceCamera;

    private Animator _danceCameraAnimator;
    private PlayerMoverView _playerMoverView;

    private void Awake()
    {
        _danceCameraAnimator = _danceCamera.GetComponent<Animator>();
        _danceCamera.gameObject.SetActive(false);
    }

    public void Init(PlayerMoverView player)
    {
        _playerMoverView = player;
    }

    public void TurnOnDance()
    {
        AudioManager.Instance.Play("Skrillix");
        _playerMoverView.Dance();
        _danceCamera.gameObject.SetActive(true);
        _danceCameraAnimator.Play(DanceCamera);
    }

    public void TurnOffDance()
    {
        AudioManager.Instance.Stop("Skrillix");
        _playerMoverView.ResetMove();
        _danceCamera.gameObject.SetActive(false);
        _danceCameraAnimator.Play(IdleState);
    }
}

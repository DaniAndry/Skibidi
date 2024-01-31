using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private readonly int RunState = Animator.StringToHash("RunState");
    private readonly int CrashState = Animator.StringToHash("CrashState");
    private readonly int JumpState = Animator.StringToHash("JumpState");
    private readonly int LoseState = Animator.StringToHash("LoseState");
    private readonly int KickState = Animator.StringToHash("Kick");

    private Animator _animator;
    private PlayerMoverView _playerMoverView;

    private void OnDisable()
    {
        _playerMoverView.OnStarted -= Run;
        _playerMoverView.OnJumped -= Jump;
        _playerMoverView.OnKicked -= Kick;
        _playerMoverView.OnChangingSpeedCrash -= Crash;
        _playerMoverView.OnStoped -= Lose;
    }

    public void Init(PlayerMoverView playerMoverView, Animator animator)
    {
        _playerMoverView = playerMoverView;
        _animator = animator;

        _playerMoverView.OnStarted += Run;
        _playerMoverView.OnJumped += Jump;
        _playerMoverView.OnKicked += Kick;
        _playerMoverView.OnChangingSpeedCrash += Crash;
        _playerMoverView.OnStoped += Lose;
    }

    private void Run()
    {
        _animator.Play(RunState);
    }

    private void Jump()
    {
        _animator.Play(JumpState);
    }

    private void Kick()
    {
        _animator.Play(KickState);
    }

    private void Crash(float speed)
    {
        _animator.Play(CrashState);
    }

    private void Lose()
    {
        _animator.Play(LoseState);
    }
}

using UnityEngine;

public class WalkToPoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _point;
    private Vector3 direction;
    private bool reachedPoint = false;

    private void Start()
    {
        _animator.SetTrigger("Walk");
        direction = (_point.position - transform.position).normalized; 
    }

    private void Update()
    {
        if(reachedPoint)
            return;
        
        if (Vector2.Distance(_point.position, transform.position) > 0.1f)
        {
            transform.Translate(direction * (Time.deltaTime * 2f));
        }
        else
        {
            reachedPoint = true;
            _animator.SetTrigger("Idle");
        }
    }
}

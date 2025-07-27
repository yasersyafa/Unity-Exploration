using UnityEngine;
using DG.Tweening;
namespace Assets.Scripts.Objects
{
    public enum DoorPosition
    {
        LEFT,
        RIGHT
    }

    public class Door : MonoBehaviour
    {
        private Vector3 _startPosition;
        [SerializeField] private DoorPosition _doorPosition;
        [SerializeField] private float _animationSpeed = 1f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _startPosition = transform.localPosition;
        }

        public void OpenTheDoor()
        {
            Ease ease = Ease.InOutBack;
            switch (_doorPosition)
            {
                case DoorPosition.LEFT:
                    AnimateDoor(-1f, ease);
                    break;
                case DoorPosition.RIGHT:
                    AnimateDoor(1f, ease);
                    break;
                default:
                    Debug.Log("Please chose door position");
                    break;
            }
        }

        public void CloseTheDoor()
        {
            Ease ease = Ease.InBounce;
            AnimateDoor(0f, ease);
        }

        private void AnimateDoor(float value, Ease ease)
        {
            transform.DOLocalMoveZ(_startPosition.z + value, _animationSpeed).SetUpdate(true).SetEase(ease);
        }
    }
}

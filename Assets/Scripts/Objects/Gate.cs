using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private Door[] _doorList;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // DO ANIMATION
                foreach (Door door in _doorList)
                {
                    door.OpenTheDoor();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // DO ANIMATION CLOSE
                foreach (Door door in _doorList)
                {
                    door.CloseTheDoor();
                }
            }
        }
    }
}

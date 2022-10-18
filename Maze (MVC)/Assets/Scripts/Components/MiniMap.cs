using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class MiniMap : MonoBehaviour
    {
        [SerializeField] private RawImage _miniMap;

        private void Awake()
        {
            _miniMap.gameObject.SetActive(false);
            Debug.Log("Press M to ativate minimap");
        }

        private void Update()
        {
            MapActive();
        }

        private void MapActive()
        {
            if (Input.GetKey(KeyCode.M))
            {
                _miniMap.gameObject.SetActive(true);
            }
            else
            {
                _miniMap.gameObject.SetActive(false);
            }
        }
    }
}

using UnityEngine;

namespace Maze
{
    public class MiniMapCam : MonoBehaviour
    {
        public Shader replShader;
        private Camera _mapCamera;

        private void Awake()
        {
            replShader = Shader.Find("Unlit/Texture");
            _mapCamera = GetComponent<Camera>();

            if(replShader)
            {
                _mapCamera.SetReplacementShader(replShader, "RenderType");
            }
        }

        private void OnDisable()
        {
            _mapCamera.ResetReplacementShader();
        }
    }
}
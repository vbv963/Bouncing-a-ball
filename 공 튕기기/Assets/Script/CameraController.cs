using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Tilemap2D tilemap2D;       //�� ũ�� ������ ������ ���� Tilemap2D
    private Camera mainCamera;         //ī�޶� �þ� ������ ���� Camera

    private float wDelta = 0.4f;       //Width �þ� delta��
    private float hDelta = 0.6f;       //height �þ� delta ��

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void SetupCamera()
    {
        //���� ũ�� ����
        int width   = tilemap2D.Width;
        int height = tilemap2D.Height;

        //ī�޶� �þ� ���� (��ü ���� ȭ�� �ȿ� �������� ����)
        float size = (width > height) ? width * wDelta : height * hDelta;
        mainCamera.orthographicSize = size;

        //ī�޶� ��ġ ���� (y�� ��ǥ)
        if ( height > width )
        {
            //���� ����(height)�� �� Ŭ ��� ī�޶��� y�� ��ġ�� �Ϻ� ����
            Vector3 position = new Vector3(0, 0.05f, -10);
            position.y *= height;

            transform.position = position;
        }

    }
}

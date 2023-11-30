using UnityEngine;
using TMPro;

public class Tilemap2D : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;   //�ʿ� ��ġ�Ǵ� Ÿ�� ������

    [SerializeField]
    private TMP_InputField inputWidth;   //�ʿ� width ũ�⸦ ������ InputField
    [SerializeField]
    private TMP_InputField inputHeigth;   //�ʿ� heigth ũ�⸦ ������ InputField

    // �� x, y ũ�� ������Ƽ
    public int Width { private set; get; } = 10;
    public int Height { private set; get; } = 10;

    private void Awake()
    {
        //InputField�� ǥ�õǴ� �⺻ �� ����
        inputWidth.text     = Width.ToString();
        inputHeigth.text    = Height.ToString();

        //GenerateTilemap();
    }

    public void GenerateTilemap()
    {
        // out �Ǵ� ref Ű���带 ����� �� ������Ƽ ����� �Ұ����ϱ� ������ ���� ���� ����
        int width, height;

        // InputField�� �ִ� width, height ���ڿ��� width, height ������ ������ ����
        int.TryParse(inputWidth.text, out width);
        int.TryParse(inputHeigth.text, out height);

        // ������Ƽ Width, Height �� ����
        Width = width;
        Height = height;

        for ( int y = 0; y < Height; ++ y )
        {
            for (int x = 0; x < Width; ++ x )
            {
                // �����Ǵ� Ÿ�ϸ��� �߾��� (0, 0, 0)�� ��ġ
                Vector3 position = new Vector3((-Width*0.5f+0.5f)+x, (Height*0.5f-0.5f)-y, 0);

                SpawnTile(TileType.Empty, position);
            }
        }
    }

    private void SpawnTile(TileType tileType, Vector3 position)
    {
        GameObject clone = Instantiate(tilePrefab, position, Quaternion.identity);
                                                
        clone.name = "Tile";                      // Tile ������Ʈ�� �̸��� "Tile"�� ����
        clone.transform.SetParent(transform);     // Tilemap2D ������Ʈ�� Tile ������Ʈ�� �θ�� ����

        Tile tile = clone.GetComponent<Tile>();   //��� ������ Ÿ��(clone) ������Ʈ�� Tile.Setup() �޼ҵ� ȣ��
        tile.Setup(tileType);
    }
}
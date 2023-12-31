using UnityEngine;
using TMPro;

public class Tilemap2D : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;   //맵에 배치되는 타일 프리팹

    [SerializeField]
    private TMP_InputField inputWidth;   //맵에 width 크기를 얻어오는 InputField
    [SerializeField]
    private TMP_InputField inputHeigth;   //맵에 heigth 크기를 얻어오는 InputField

    // 맵 x, y 크기 프로퍼티
    public int Width { private set; get; } = 10;
    public int Height { private set; get; } = 10;

    private void Awake()
    {
        //InputField에 표시되는 기본 값 설정
        inputWidth.text     = Width.ToString();
        inputHeigth.text    = Height.ToString();

        //GenerateTilemap();
    }

    public void GenerateTilemap()
    {
        // out 또는 ref 키워드를 사용할 때 프로퍼티 사용이 불가능하기 때문에 지역 변수 선언
        int width, height;

        // InputField에 있는 width, height 문자열을 width, height 변수에 정수로 저장
        int.TryParse(inputWidth.text, out width);
        int.TryParse(inputHeigth.text, out height);

        // 프로퍼티 Width, Height 값 설정
        Width = width;
        Height = height;

        for ( int y = 0; y < Height; ++ y )
        {
            for (int x = 0; x < Width; ++ x )
            {
                // 생성되는 타일맵의 중앙이 (0, 0, 0)인 위치
                Vector3 position = new Vector3((-Width*0.5f+0.5f)+x, (Height*0.5f-0.5f)-y, 0);

                SpawnTile(TileType.Empty, position);
            }
        }
    }

    private void SpawnTile(TileType tileType, Vector3 position)
    {
        GameObject clone = Instantiate(tilePrefab, position, Quaternion.identity);
                                                
        clone.name = "Tile";                      // Tile 오브젝트의 이름을 "Tile"로 설정
        clone.transform.SetParent(transform);     // Tilemap2D 오브젝트를 Tile 오브젝트의 부모로 설정

        Tile tile = clone.GetComponent<Tile>();   //방금 생성한 타일(clone) 오브젝트의 Tile.Setup() 메소드 호출
        tile.Setup(tileType);
    }
}
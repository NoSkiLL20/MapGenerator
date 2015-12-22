using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour
{

    public GameObject mapPlayer;
    public GameObject tile4x4;
    private MapPrefab mapPlayerPrefab;
    private Color contructItem = Color.white;
    private GameObject objectToConstruc = null;
    // Use this for initialization
    void Awake()
    {
        if (mapPlayer == null)
            mapPlayer = GameObject.Find("Map");

        if (mapPlayer == null)
            Debug.LogError("add map prefab on scene");

        if (mapPlayer != null)
            mapPlayerPrefab = mapPlayer.GetComponent<MapPrefab>();
    }

    public void ContructHouse()
    {
        objectToConstruc = tile4x4;
        objectToConstruc = Instantiate(objectToConstruc);
    }

    public void ContructCastle()
    {
        objectToConstruc = tile4x4;
        objectToConstruc = Instantiate(objectToConstruc);
    }

    public void ContructHuman()
    {
        objectToConstruc = null;
    }

    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider
    public void OnMouseOver()
    {
        Debug.Log("JSUIS DSUS");
        if (objectToConstruc != null)
        {
            Vector3 posObjToConstruct = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = Mathf.FloorToInt(posObjToConstruct.x);
            int y = Mathf.FloorToInt(posObjToConstruct.y);
            
            
        }

    }

    public void Update()
    {
       
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, transform.position);

        if (hit.collider != null)
        {
            int x = Mathf.FloorToInt(pos.x  + mapPlayerPrefab.tilePrototype.widthTile / 2);
            int y = Mathf.FloorToInt(pos.y + mapPlayerPrefab.tilePrototype.heigthTile / 2);

            if (objectToConstruc != null)
                objectToConstruc.transform.position = new Vector3(x, y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                TilePrefab test = mapPlayerPrefab.GetTilPrefeb(new Vector2(x, y));
                if (test.IsBuildable() && test.IsAvailable())
                {
                    Debug.Log("YES WE CAN");
                }
            }
        }
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Example01 : MonoBehaviour
{
    public Material material = null;
    public float zoom = 1.0f;
    public Text txt = null;
    public Grid grid = null;
    public Camera cam = null;
    public bool ListenPointEvent = false;
    private Mesh mesh = null;
    private Vector3 size = Vector3.zero;    //set through event when grid is ready
    private Vector3 orgCamPos;
    private Quaternion orgCamRot;
    

    private void Start()
    {
        GameObject go = this.gameObject;
        mesh = MarchingCube.GetMesh(ref go, ref material);
        MarchingCube.Clear();

        Transform t = cam.transform;
        orgCamPos = new Vector3(t.position.x, t.position.y, t.position.z);
        orgCamRot = new Quaternion(t.rotation.x, t.rotation.y, t.rotation.z, t.rotation.w);
    }
    private void OnEnable()
    {
        Grid.OnGridCreated += OnGridCreated;
        GridPoint.OnGridPointChange += OnGridPointChanged;
    }
    private void OnDisable()
    {
        Grid.OnGridCreated -= OnGridCreated;
        GridPoint.OnGridPointChange += OnGridPointChanged;
    }
    private void NoiseClear()
    {
        for (float z = 0; z < size.z; z++)
        {
            for (float y = 0; y < size.y; y++)
            {
                for (float x = 0; x < size.x; x++)
                {
                    GridPoint pt = MarchingCube.grd[(int)x, (int)y, (int)z];
                    pt.On = false;
                }
            }
        }
    }
    private void Noise2D()
    {
        NoiseClear();
        for (float z = 0; z < size.z; z++)
        {
            for (float x = 0; x < size.x; x++)
            {
                float height = Mathf.PerlinNoise(zoom * (x / size.x), zoom * (z / size.z)) * (size.y * 0.5f);
                for (int y = 0; y < height; y++)
                {
                    GridPoint pt = MarchingCube.grd[(int)x, y, (int)z];
                    pt.On = true;
                }
            }
        }
    }
    private void Noise3D()
    {
        NoiseClear();
        for (float z = 0; z < size.z; z++)
        {
            for (float y = 0; y < size.y; y++)
            {
                for (float x = 0; x < size.x; x++)
                {
                    float nx = (x / size.x) * zoom;
                    float ny = (y / size.y) * zoom;
                    float nz = (z / size.z) * zoom;
                    float noise = MarchingCube.PerlinNoise3D(nx, ny, nz);
                    if (noise > 0.5f)
                    {
                        GridPoint pt = MarchingCube.grd[(int)x, (int)y, (int)z];
                        pt.On = true;
                    }
                }
            }
        }
    }
    private void MarchInstant()
    {
        MarchingCube.Clear();
        MarchingCube.MarchCubes();
        MarchingCube.SetMesh(ref mesh);
    }
    private void MarchSlow()
    {
        MarchingCube.Clear();
        StartCoroutine(SlowStep());
    }
    private IEnumerator SlowStep()
    {
        for (int z = (int)(size.z - 2); z >= 0; z--)
        {
            for (int y = 0; y < (int)(size.y - 1); y++)
            {
                for (int x = 0; x < (int)(size.x - 1); x++)
                {
                    Vector3 p = new Vector3(x, y, z);
                    int config = MarchingCube.SetCubeToConfig(p);

                    grid.HighlightOutline(p);

                    MoveCamera(p);

                    txt.text = string.Format("{0} {1}", Bits.BinaryForm(config), config);

                    yield return new WaitForSeconds(0.07f);
                    if (config != 0 && config != 255)
                    {
                        yield return new WaitForSeconds(0.12f);
                        MarchingCube.SetMesh(ref mesh);
                        yield return new WaitForSeconds(0.18f);
                    }
                }
            }
        }

        cam.transform.position = orgCamPos;
        cam.transform.rotation = orgCamRot;
    }
    private void OnGridCreated(Vector3 sz)
    {
        size = new Vector3(sz.x, sz.y, sz.z);
    }
    private void OnGridPointChanged(bool on, Vector3 position)
    {
        if (ListenPointEvent == true)
        {
            btnInstant();
        }
    }
    private void MoveCamera(Vector3 p)
    {
        cam.transform.position = new Vector3(p.x + 0.5f, p.y + 6, p.z - 1.5f);
        cam.transform.LookAt(new Vector3(p.x + 0.5f, p.y + 0.5f, p.z + 0.5f));
    }
    public void btnInstant()
    {
        MarchInstant();
    }
    public void btnSlow()
    {
        MarchSlow();
    }
    public void btn2D()
    {
        Noise2D();
    }
    public void btn3D()
    {
        Noise3D();
    }
}

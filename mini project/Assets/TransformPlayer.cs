using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    private MeshFilter msh;
    private MeshRenderer mshrnd;
    private BoxCollider bc;
    public Transform tf;
    private float playerHeight;
    private Vector3 playerDimensions;
    [Header ("Objects")]
    public Mesh staplerMesh;
    public Material staplerMaterial;
    public float staplerHeight;
    
    public Mesh sofaPillowMesh;
    public Material sofaPillowMaterial;
    public float sofaPillowHeight;
    
    public Mesh tableMesh;
    public Material tableMaterial;
    public float tableHeight;
    
    public Mesh keyboardMesh;
    public Material keyboardMaterial;
    public float keyboardHeight;
    
    public Mesh officeChairMesh;
    public Material officeChairMaterial;
    public float officeChairHeight;
    
    public Mesh wineBottleMesh;
    public Material wineBottleMaterial;
    public float wineBottleHeight;
    
    public Mesh trashcanMesh;
    public Material trashcanMaterial;
    public float trashcanHeight;
    
    public Mesh deskMesh;
    public Material deskMaterial;
    public float deskHeight;
    
    public Mesh beanBagMesh;
    public Material beanBagMaterial;
    public float beanBagHeight;
    
    public Mesh toiletMesh;
    public Material toiletMaterial;
    public float toiletHeight;
    
    private string currentPlayerMesh;
    // Creating a dictionary
    //Dictionary<int, string> sub = new Dictionary<int, string>();

    // Adding elements
    //sub.Add(1, "Trash Can");
    //sub.Add(2, "Monitor");
    //sub.Add(3, "Book");

    // Displaying dictionary
    // Start is called before the first frame update
    void Start()
    {
        msh = GetComponent<MeshFilter>();
        mshrnd = GetComponent<MeshRenderer>();
        bc = GetComponent<BoxCollider>();
        //tf = GetComponent<Transform>();
        playerHeight = bc.center.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerMesh = PlayerPrefs.GetString("PlayerModel");
        if (currentPlayerMesh == "Stapler") //doesnt work
        {   msh.mesh = staplerMesh;
            mshrnd.material = staplerMaterial;
            playerHeight = staplerHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Sofa Pillow")
        {   msh.mesh = sofaPillowMesh;
            mshrnd.material = sofaPillowMaterial;
            playerHeight = sofaPillowHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Table")//doesnt work
        {   msh.mesh = tableMesh;
            mshrnd.material = tableMaterial;
            playerHeight = tableHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Keyboard")
        {   msh.mesh = keyboardMesh;
            mshrnd.material = keyboardMaterial;
            playerHeight = keyboardHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Office Chair")//doesnt work
        {   msh.mesh = officeChairMesh;
            mshrnd.material = officeChairMaterial;
            playerHeight = officeChairHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Wine Bottle")
        {   msh.mesh = wineBottleMesh;
            mshrnd.material = wineBottleMaterial;
            playerHeight = wineBottleHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "TrashCan")
        {
            msh.mesh = trashcanMesh;
            mshrnd.material = trashcanMaterial;
            playerHeight = trashcanHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Desk")//doesnt work
        {
            msh.mesh = deskMesh;
            mshrnd.material = deskMaterial;
            playerHeight = deskHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "BeanBag")
        {
            msh.mesh = beanBagMesh;
            mshrnd.material = beanBagMaterial;
            playerHeight = beanBagHeight;
            playerDimensions = new Vector3(1, 1, 1);
        }
        if (currentPlayerMesh == "Toilet")
        {
            msh.mesh = toiletMesh;
            mshrnd.material = toiletMaterial;
            playerHeight = toiletHeight;
            playerDimensions = new Vector3(2, 2, 2);
        }
        bc.center = new Vector3(bc.center.x, playerHeight, bc.center.z);
        tf.localScale = playerDimensions;
        
    }
}

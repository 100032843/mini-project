using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    private MeshFilter msh;
    private MeshRenderer mshrnd;
    [Header ("Objects")]
    public Mesh trashcanMesh;
    public Material trashcanMaterial;
    public Mesh deskMesh;
    public Material deskMaterial;
    public Mesh fanMesh;
    public Material fanMaterial;
    public Mesh beanBagMesh;
    public Material beanBagMaterial;
    public Mesh toiletMesh;
    public Material toiletMaterial;
    public Mesh bookMesh;
    public Material bookMaterial;
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
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerMesh = PlayerPrefs.GetString("PlayerModel");
        if (currentPlayerMesh == "TrashCan")
        {
            msh.mesh = trashcanMesh;
            mshrnd.material = trashcanMaterial;
        }
        if (currentPlayerMesh == "Desk")
        {
            msh.mesh = deskMesh;
            mshrnd.material = deskMaterial;
        }
        if (currentPlayerMesh == "Fan")
        {
            msh.mesh = fanMesh;
            mshrnd.material = fanMaterial;
        }
        if (currentPlayerMesh == "BeanBag")
        {
            msh.mesh = beanBagMesh;
            mshrnd.material = beanBagMaterial;
        }
        if (currentPlayerMesh == "Toilet")
        {
            msh.mesh = toiletMesh;
            mshrnd.material = toiletMaterial;
        }
        if (currentPlayerMesh == "Book")
        {
            msh.mesh = bookMesh;
            mshrnd.material = bookMaterial;
        }
    }
}

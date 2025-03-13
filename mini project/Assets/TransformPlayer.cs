using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    private MeshFilter msh;
    private MeshRenderer mshrnd;
    public Mesh trashcanMesh;
    public Material trashcanMaterial;
    public Mesh fanMesh;
    public Material fanMaterial;
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
        if (currentPlayerMesh == "Fan")
        {
            msh.mesh = fanMesh;
            mshrnd.material = fanMaterial;
        }
    }
}

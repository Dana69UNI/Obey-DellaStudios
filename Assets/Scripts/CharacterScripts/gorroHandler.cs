using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gorroHandler : MonoBehaviour
{
    
    public int GorroIndex;
    private MeshFilter meshOBJ;
    private Mesh[] Gorros;
    private Mesh sinGorro = null;
    [field: Header("Gorro1")]
    [field: SerializeField] public Mesh Gorro1 { get; private set; }

    [field: Header("Gorro2")]
    [field: SerializeField] public Mesh Gorro2 { get; private set; }

    private void Start()
    {
        meshOBJ = GetComponent<MeshFilter>();
        Gorros = new Mesh[] {sinGorro,Gorro1, Gorro2};
    }
    public int getHatIndex()
    { return GorroIndex; }

    public void changeHat(int index)
    {
        if(index == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            meshOBJ.mesh = Gorros[index];
            GorroIndex = index;
        }
      
      
    }
}

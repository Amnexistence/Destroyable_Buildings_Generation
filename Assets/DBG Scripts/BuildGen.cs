using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGen : MonoBehaviour
{
	//building destruction boolean
	[HideInInspector]
	public bool isFall = false; 
	
	//public fields for configuration of building (size x and y, floors and windows count)
	public int sizeX_low;
	public int sizeX_up;
	private int sizeX;
	
	public int sizeZ_low;
	public int sizeZ_up;
	private int sizeZ;
	
	public int floors_low;
	public int floors_up;
	private int floors;
	
	public int windows_low;
	public int windows_up;
	private int windows;
	
	//all public fields below to indicate used objects in the inspector
	//+ lists of objects for random selection
	public GameObject window1;
	public GameObject window2;
	public GameObject window3;
	public GameObject window4;
	
	List <GameObject> windowModules = new List<GameObject>(){};
	
	
	public GameObject quoin1;
	public GameObject quoin2;
	public GameObject quoin3;
	public GameObject quoin4;
	public GameObject quoin5;

	List <GameObject> quoinModules = new List<GameObject>(){};

	
	public GameObject wall;
	public GameObject wall_border;
	
	//a variable that specifies the type of wall section
	private GameObject buildWall;

	
	public GameObject balcony;
	
	//variables that specifies the type of windows and quoins
	private GameObject randomWindow;
	private GameObject randomQuoin;
	
	public GameObject cornice;
	
	public GameObject roof_flat;
	
	//variable for random spawn objects on roof space
	private int roofItem;
	
	public GameObject windowGlass;
	
	public GameObject ventSmall;
	
	//mesh renderer component (needed to randomize building colors)
	MeshRenderer _build_mod_col;
	
	//an array to change the colors of materials obtained with _build_mod_col.materials
	Material[] mats;
	
	
    // Start is called before the first frame update
    void Start()
    {
      
	//determining the configuration of the building, filling in the object sheets and choosing a random objects in them
	sizeX = Random.Range(sizeX_low, sizeX_up);
	sizeZ = Random.Range(sizeZ_low, sizeZ_up);
	floors = Random.Range(floors_low, floors_up);
	windows = Random.Range(windows_low, windows_up);
	  
	windowModules.Add(window1);
	windowModules.Add(window2);
	windowModules.Add(window3);
	windowModules.Add(window4);
	  
	GameObject randomWindow = windowModules[Random.Range(0,3)];
	
	
	quoinModules.Add(quoin1);
	quoinModules.Add(quoin2);
    quoinModules.Add(quoin3);
	quoinModules.Add(quoin4);
	quoinModules.Add(quoin5);
	  
	GameObject randomQuoin = quoinModules[Random.Range(0,4)];
	  
	  //building construction section (x-axis)
	  for(int floor = 0; floor < floors; floor++)
        {
		for(int x = 0; x < sizeX; x++)
        {

		buildWall = wall;
		if (floor == 0)
		{
		buildWall = wall_border;
		}
		
		if ((floor > 0) && ((x % 2) == 0))
		{
			buildWall = randomWindow;
			
			if (Random.Range(0, 2) == 0)
			{
			GameObject balcony_inst = Instantiate(balcony, new Vector3(x, floor, -1) + gameObject.transform.position, Quaternion.Euler(0f, 180f, 0f), gameObject.transform);	
			}
			if (Random.Range(0, 2) == 0)
			{
			GameObject balcony_inst = Instantiate(balcony, new Vector3(x, floor, sizeZ) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);	
			}

		}
		
		GameObject wall_inst = Instantiate(buildWall, new Vector3(x, floor, 0) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
		wall_inst = Instantiate(buildWall, new Vector3(x, floor, sizeZ) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
		
		if (x == 0)
		{
		GameObject quoin_inst = Instantiate(randomQuoin, new Vector3(sizeX - 1, floor, sizeZ - 1) + gameObject.transform.position, Quaternion.Euler(0f, 90f, 0f), gameObject.transform);
		}
		
		if (x == (sizeX - 1))
		{
		GameObject quoin_inst = Instantiate(randomQuoin, new Vector3(sizeX - 1, floor, 0) + gameObject.transform.position, Quaternion.Euler(0f, 180f, 0f), gameObject.transform);
		}
		
		if (floor == (floors - 1))
		{
			GameObject cornice_inst = Instantiate(cornice, new Vector3(x, floor + 0.25f, -1) + gameObject.transform.position, Quaternion.Euler(0f, 180f, 0f), gameObject.transform);
			cornice_inst = Instantiate(cornice, new Vector3(x, floor + 0.25f, sizeZ) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
		}
		
		}
		//z-axis construction section
		for(int z = 0; z < sizeZ; z++)
		{
		buildWall = wall;
		if (floor == 0)
		{
		buildWall = wall_border;
		}
		if ((floor > 0) && ((z % 2) == 0))
		{
			buildWall = randomWindow;
		}
		GameObject wall_inst = Instantiate(buildWall, new Vector3(0, floor, z) + gameObject.transform.position, Quaternion.Euler(0f, 90f, 0f), gameObject.transform);
		wall_inst = Instantiate(buildWall, new Vector3(sizeX, floor, z) + gameObject.transform.position, Quaternion.Euler(0f, 90f, 0f), gameObject.transform);
		if (z == 0)
		{
		GameObject quoin_inst = Instantiate(randomQuoin, new Vector3(0, floor, z) + gameObject.transform.position, Quaternion.Euler(0f, -90f, 0f), gameObject.transform);
		}
		if (z == (sizeZ - 1))
		{
		GameObject quoin_inst = Instantiate(randomQuoin, new Vector3(0, floor, z) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
		}
		if (floor == (floors - 1))
		{
			GameObject cornice_inst = Instantiate(cornice, new Vector3(-1, floor + 0.25f, z) + gameObject.transform.position, Quaternion.Euler(0f, -90f, 0f), gameObject.transform);
			cornice_inst = Instantiate(cornice, new Vector3(sizeX, floor + 0.25f, z) + gameObject.transform.position, Quaternion.Euler(0f, 90f, 0f), gameObject.transform);
		}
		
		}
		
		}  
	  //roof construction section
	  for(int x = 0; x < sizeX; x++)
        {
		for(int z = 0; z < sizeZ; z++)
		{
		GameObject roof_flat_inst = Instantiate(roof_flat, new Vector3(x, floors, z) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
		roofItem = Random.Range(0, 10);
		if(roofItem == 0)
		{
		GameObject windowGlass_inst = Instantiate(windowGlass, new Vector3(x, floors + 0.1f, z) + gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
		}
		if(roofItem == 1)
		{
		GameObject ventSmall_inst = Instantiate(ventSmall, new Vector3(x, floors + 0.1f, z) + gameObject.transform.position, Quaternion.Euler(0f, Random.Range(0, 360), 0f), gameObject.transform);
		}
		}
	  
	  
		}
	  //add building parts to array to change colors
	  Transform[] build_modules = new Transform[gameObject.transform.childCount];
	  
	  for(int i = 0; i < gameObject.transform.childCount; i++) 
	  {
	  build_modules[i] = gameObject.transform.GetChild(i);
	  }
	  
	  //list of random colors
	       List<Color> MColors = new List<Color>()
     {
         new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1),
         new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1),
         new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1),
         new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1),
		 new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1),
         new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1),
         new Color(Random.Range(0f,1f),Random.Range(0f,1f), Random.Range(0f,1f), 1)
     };
	  
	  //changing the color of building materials
	  for(int i = 0; i < build_modules.Length; i++)
	  {
		
	  _build_mod_col = build_modules[i].GetComponentInChildren(typeof(MeshRenderer)) as MeshRenderer;

	  mats = _build_mod_col.materials;
	  
	  for(int j = 0; j < mats.Length; j++)
	  {
	    if(mats[j].name == "stone(Clone) (Instance)")
		{
		mats[j].color = MColors[0];
		}
		else if(mats[j].name == "stoneLight(Clone) (Instance)")
		{
		mats[j].color = MColors[1];
		}
		else if(mats[j].name == "stoneDark(Clone) (Instance)")
		{
		mats[j].color = MColors[2];
		}
		else if(mats[j].name == "glass(Clone) (Instance)")
		{
		mats[j].color = MColors[3];
		}
		else if(mats[j].name == "metal(Clone) (Instance)")
		{
		mats[j].color = MColors[4];
		}
		else if(mats[j].name == "metalDark(Clone) (Instance)")
		{
		mats[j].color = MColors[5];
		}
		else if(mats[j].name == "dark(Clone) (Instance)")
		{
		mats[j].color = MColors[6];
		}
	  }
	  
	  
	  _build_mod_col.materials = mats;
	  
	  }
	  
    }

}

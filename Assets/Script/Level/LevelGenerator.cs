using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public enum DEPTH {
        A,
        B
    }

    public DEPTH _depth;

    private readonly int EACH_POOL_SIZE = 5;
    public static LevelGenerator instance;

    public int levelNumber;
    private int height;

    private bool colliderChecker;

    [SerializeField]
	private List<GameObject> levelPoolEven;
    [SerializeField]
    private List<GameObject> levelPoolOdd;
    [SerializeField]
    private List<NoWallSector> noWallSectorEven;
    [SerializeField]
    private List<NoWallSector> noWallSectorOdd;
    [SerializeField]
    private List<WallSector> wallSectorEven;
    [SerializeField]
    private List<WallSector> wallSectorOdd;
    public GameObject[] sectors;


    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
		levelPoolEven = new List<GameObject>();
        levelPoolOdd = new List<GameObject>();
        noWallSectorEven = new List<NoWallSector>();
        wallSectorEven = new List<WallSector>();
        noWallSectorOdd = new List<NoWallSector>();
        wallSectorOdd = new List<WallSector>();
		levelPoolEven.Clear();
        levelPoolOdd.Clear();
        noWallSectorEven.Clear();
        wallSectorEven.Clear();
        noWallSectorOdd.Clear();
        wallSectorOdd.Clear();

        colliderChecker = false;
        height = 0;
        levelNumber = 0;
        _depth = DEPTH.A;

        MakePool();
        CheckLevel();
    }

    private void MakePool()
    {
        for (int i = 0; i < sectors.Length; i++)
        {
            for (int j = 0; j < EACH_POOL_SIZE; j++){
                var oddGo = Instantiate(sectors[i]);
                var evenGo = Instantiate(sectors[i]);
                //levelPoolOdd.Add(Instantiate(sectors[i]));
                //levelPoolEven.Add(Instantiate(sectors[i]));
                levelPoolOdd.Add(oddGo);
                levelPoolEven.Add(evenGo);

                // Wall
                if(i == 0){
                    wallSectorOdd.Add(oddGo.GetComponent<WallSector>());
                    wallSectorEven.Add(evenGo.GetComponent<WallSector>());
                }
                // No Wall
                else if(i == 1){
                    noWallSectorOdd.Add(oddGo.GetComponent<NoWallSector>());
                    noWallSectorEven.Add(evenGo.GetComponent<NoWallSector>());
                }
            }
        }

        MoveToVoidAndGetScripts();
    }

    private void MoveToVoidAndGetScripts(){
        foreach(GameObject _level in levelPoolOdd){
            _level.transform.position = Vector3.one * 10000;
        }
        foreach (GameObject _level in levelPoolEven)
        {
            _level.transform.position = Vector3.one * 10000;
        }
    }

    public void CheckLevel(){
        if(levelNumber % 2 == 0){
            levelPoolEven.Shuffle();
            Generate(levelPoolEven);
            NotifyEven();
        }
        else {
            levelPoolOdd.Shuffle();
            Generate(levelPoolOdd);
            NotifyOdd();
        }
        levelNumber = levelNumber + 1;
    }


    private void Generate(List<GameObject> pool){
        foreach(GameObject _level in pool){
            _level.GetComponent<BoxCollider>().enabled = false;
            if(!colliderChecker){
                _level.GetComponent<BoxCollider>().enabled = true;
                colliderChecker = true;
            }

            _level.transform.position = new Vector3(0, height, 0);
            height = height + 10;
        }
        colliderChecker = false;
    }

    private void NotifyOdd(){
        foreach(WallSector ws in wallSectorOdd){
            ws.OnNotify();
        }


        foreach(NoWallSector nws in noWallSectorOdd){
            nws.OnNotify();
        }
       
    }
    private void NotifyEven(){
        foreach (WallSector ws in wallSectorEven)
        {
            ws.OnNotify();
        }
        foreach (NoWallSector nws in noWallSectorEven)
        {
            nws.OnNotify();
        }
    }

}

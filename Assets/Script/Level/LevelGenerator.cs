using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    private readonly int EACH_POOL_SIZE = 5;
    public static LevelGenerator instance;

    public int levelNumber;
    private int height;

    private bool colliderChecker;

    [SerializeField]
	private List<GameObject> levelPoolEven;
    private List<GameObject> levelPoolOdd;
    public GameObject[] sectors;


    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
		levelPoolEven = new List<GameObject>();
        levelPoolOdd = new List<GameObject>();
		levelPoolEven.Clear();
        levelPoolOdd.Clear();

        colliderChecker = false;
        height = 0;
        levelNumber = 0;

        MakePool();
        CheckLevel();
    }

    private void MakePool()
    {
        for (int i = 0; i < sectors.Length; i++)
        {
            for (int j = 0; j < EACH_POOL_SIZE; j++){
                levelPoolOdd.Add(Instantiate(sectors[i]));
                levelPoolEven.Add(Instantiate(sectors[i]));
            }
        }
        levelPoolOdd.Shuffle();
        levelPoolEven.Shuffle();
        MoveToVoid();
    }

    private void MoveToVoid(){
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
            Generate(levelPoolEven);
        }
        else {
            Generate(levelPoolOdd);
        }
        levelNumber = levelNumber + 1;
    }

    private void Generate(List<GameObject> pool){
        foreach(GameObject _level in pool){
            if(!colliderChecker){
                _level.GetComponent<BoxCollider>().enabled = true;
                colliderChecker = true;
            }

            _level.transform.position = new Vector3(0, height, 0);
            height = height + 10;
        }
        colliderChecker = false;
    }
}

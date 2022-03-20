using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private GameObject _exampleObject;
    [SerializeField] private GameObject _walkingPersonObject;


    private PlayerChoices _playerChoices;

    private int _actNumber;


    private void Awake()
    {

        //_playerChoices = new PlayerChoices();

        SceneManager.sceneLoaded += SceneLoaded;
        GameEvents.OnActOver += LoadBossOfficeScene;
    
        //DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        GameEvents.OnActOver -= LoadBossOfficeScene;
    }


    void Start()
    {
        //ActivateWalkingPerson();
        //_actNumber++;
        GameEvents.StartAct(_actNumber);

        //Invoke("BobVisit1", 6f);
        // Invoke(nameof(CallPhone), 4f);


    }

    public void LoadAct()
    {

        SceneManager.LoadScene(1);

        GameEvents.StartAct(_actNumber);

    }

    private void LoadBossOfficeScene()
    {

        SceneManager.LoadSceneAsync(2);

        // transition...

    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // set num possible actions
        //_actActions = 10;

    }




    //private void WateredPlant()
    //{
    //    int wateredCount = _playerChoices.WateredPlant();
    //    _actActions--;
    //    _viewManager.UpdateDebug(wateredCount.ToString());
    //}




    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }




    public void ActivateWalkingPerson()
    {
        _walkingPersonObject.SetActive(true);
    }



    public void CallPhone()
    {

        GameEvents.PhoneRings(1);

    }




    private IEnumerator DelayBy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using gameManager = GameManagerScript;
using System;
public class GeneratorMiniGame : MonoBehaviour
{
    [SerializeField]private Animator anim;
    private GeneratorManager genManager;

    #region Note section
    [SerializeField]private int _rounds;//How many turns there are in the song
    [SerializeField]private List<float> _roundSpeed;
    private int _currentRound;
    [SerializeField]private GameObject[] _leftNotes;
    [SerializeField]private GameObject[] _rightNotes;
    [SerializeField]private Slider _electricitySlider;
    private bool _isSliderFilling;
    #endregion

    private IEnumerator _spaceCoolDown;
    private bool _isSpacePressed;
    private bool isNoteRunning;
    private bool resetNotes;
    private float noteTimer;
    public bool hasGameStarted = false;
    private int accuracyDifficulty;
    [HideInInspector]public int NotesSuceeded;
    private bool gameFinished;
    private bool didPlayerwin;

    #region Customizable Aspect

    [Tooltip("MaxGen should be a 1 decimal(0.1) and MinGen should be 3 decimals(0.0003)")]
    [SerializeField]private float _MaxGenTime, _MinGenTime;//The max & min amount of time given to the player to press space

    [SerializeField]private int _notesNeededToPass;
    [Range(0, 5)][SerializeField]private float _Timedifficulty;
    [SerializeField]private float _songBPM;
    [SerializeField]private float _secPerBeat;
    #endregion

    #region End Game
    [SerializeField]private TMP_Text accuracyDifficultyText;
    [SerializeField]private TMP_Text notesSuccededText;
    [SerializeField]private TMP_Text endResultText;
    [SerializeField]private Animation endGameAnim;
    [SerializeField]private GameObject endGamePanel;
    [SerializeField] L1LightManager l1lightManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //songTime = song.length;
        _secPerBeat = _songBPM / 60f;
        isNoteRunning = false;
        hasGameStarted = true;

        anim = GetComponent<Animator>();
        l1lightManager = GameObject.Find("Level1Manager").GetComponent<L1LightManager>();
        //noteAnim = GetComponent<Animation>();
    }

    private void OnEnable() {
        try//this will first try to find the script but if it doesnt it will return and keep running the script
        {
            genManager = GameObject.Find("GeneratorManager").GetComponent<GeneratorManager>();

            _rounds = genManager.curgGenScriptable.rounds;
            _roundSpeed = genManager.curgGenScriptable.roundSpeed;
            _notesNeededToPass = genManager.curgGenScriptable.notesNeededToPass;
            _MaxGenTime = genManager.curgGenScriptable.MaxGenTime;
            _MinGenTime = genManager.curgGenScriptable.MinGenTime;
            _Timedifficulty = genManager.curgGenScriptable.Timedifficulty;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("Reset", resetNotes);
        anim.SetBool("CanPress", isNoteRunning);
        
        //If a note is being played counts down the timer for the player to press space. If they do press space notesSuceeded goes up. Then notes completed goes up and timer is reset
        if (hasGameStarted)
        {
            _electricitySlider.maxValue = _rounds;//this will equal the max amount of 
            if (_isSliderFilling)
            {
                FillSlider(NotesSuceeded);
            }
            
            if (_currentRound != _rounds)
            {
                GeneratorFunc();
            }
            else if (_currentRound == _rounds)
            {
                gameFinished = true;
                if (NotesSuceeded >= _notesNeededToPass)
                {
                    didPlayerwin = true;
                }
                else
                {
                    didPlayerwin = false;
                }
                StartCoroutine(EndGamePanel());
            }
        }
    }

    void FillSlider(float amountToFill)
    {
        if (_electricitySlider.value < amountToFill)
        {
            _electricitySlider.value += Time.deltaTime * 3;
        }
        else if (_electricitySlider.value >= amountToFill)
        {
            _electricitySlider.value = amountToFill;
            _isSliderFilling = false;
        }
    }

    /* still working on this
    IEnumerator MiddleNoteNotifier()
    {
        energyNotifier.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        energyNotifier.SetActive(false);
        StopCoroutine(_Notifier);
    }
    */

    void GeneratorFunc()
    {
        for (int i = _currentRound; i < _rounds;)
        {
            StopCoroutine(ActivateButton());
            anim.SetFloat("AnimSpeed", _roundSpeed[_currentRound]);
            break;
        }

        if (IsAllNotesActivated())
        {
            isNoteRunning = true;
        }
        else
        {
            noteTimer = 0;
            isNoteRunning = false;
            resetNotes = false;
        }

        if (isNoteRunning)
        {
            noteTimer += Time.deltaTime;

            if (noteTimer >= _Timedifficulty)
            {
                _currentRound++;
                _isSliderFilling = true;
                resetNotes = true;
                noteTimer = 0;
            }
        }

        if (!_isSpacePressed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               // _spaceCoolDown = ActivateButton();
                StartCoroutine(ActivateButton());
            }
        }
    }

    bool IsAllNotesActivated()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!_leftNotes[i].activeInHierarchy && !_rightNotes[i].activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator ActivateButton()
    {
        _isSpacePressed = true;
        if (isNoteRunning)
        {
            if (noteTimer <= _MaxGenTime || noteTimer >= _MinGenTime)
            {
                _currentRound++;
                NotesSuceeded++;
                _isSliderFilling = true;
                resetNotes = true;

            }
        }
        yield return new WaitForSeconds(1.5f);
        _isSpacePressed = false;
    }

    IEnumerator EndGamePanel()
    {   
        
        yield return new WaitForSeconds(3);
        endGamePanel.SetActive(true);
        notesSuccededText.text = NotesSuceeded.ToString();
        accuracyDifficultyText.text = accuracyDifficulty.ToString();
        if (didPlayerwin)
        {
            //Display win or lose
            endResultText.text = "PASSED";
            genManager.isGeneratorPuzzleCompleted[genManager.curGenNumID - 1] = true;
        }
        else
        {
            //idk flash all the lights or something to show you goofed
            endResultText.text = "FAILED \n try again next time!";
        }
        yield return new WaitForSeconds(1.5f);
        endGameAnim.Play();
        yield return new WaitForSeconds(5);
        //Need to change to load the first level
        hasGameStarted = false;

        l1lightManager.checkLights();
        gameManager.UnLoadPuzzle("Generator1Scene");
    }
}

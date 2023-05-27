using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GeneratorMiniGame : MonoBehaviour
{
    [SerializeField]private Animator anim;

    #region Note section
    [SerializeField]private int _rounds;//How many turns there are in the song
    [SerializeField]private List<float> _roundSpeed;
    private int _currentRound;
    [SerializeField]private GameObject[] _leftNotes;
    [SerializeField]private GameObject[] _rightNotes;
    [SerializeField]private Slider _electricitySlider;
    private bool _isSliderFilling;
    #endregion
    
    private bool isNoteRunning;
    private bool resetNotes;
    private float noteTimer;
    public bool hasGameStarted = false;
    private int accuracyDifficulty;
    [HideInInspector]public int NotesSuceeded;
    private bool gameFinished;
    private bool didPlayerwin;

    #region Customizable Aspect
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

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //songTime = song.length;
        _secPerBeat = _songBPM / 60f;
        isNoteRunning = false;
        hasGameStarted = true;

        anim = GetComponent<Animator>();
        //noteAnim = GetComponent<Animation>();
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

    void GeneratorFunc()
    {
        for (int i = _currentRound; i < _rounds;)
        {
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (noteTimer <= 0.1 && noteTimer >= 0.001)
                {
                    _currentRound++;
                    NotesSuceeded++;     
                    _isSliderFilling = true;  
                    resetNotes = true;
                }
                else if(noteTimer <= 0.3 && noteTimer >= 0.003)
                {
                    
                    _currentRound++;
                    NotesSuceeded++;
                    _isSliderFilling = true;
                    resetNotes = true;
                }
                else if(noteTimer <= 0.6 && noteTimer >= 0.006)
                {
                    
                    _currentRound++; 
                    _isSliderFilling = true;
                    resetNotes = true;
                }
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
        SceneManager.LoadScene(0);
    }
}

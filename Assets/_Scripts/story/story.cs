using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using TMPro;

public enum ActionType
{
    move,
    playDialog,
    playAudio
}

[Serializable]
public class CustomAction
{
    public ActionType type;
    public GameObject target;
    public Vector3 moveTo;
    public float moveSpeed;
    public AudioClip dialogToPlay;
    public AudioClip musicToPlay;

    public AudioSource musicAudioSource;
    public AudioSource dialogAudioSource;

    public TMP_Text dialogTextCanva;
    public TMP_Text dialogPersonCanva;

    public string dialogText;
    public string dialogPerson;

    public bool callNext;
    public float delayCallNext;

    public IEnumerator Resolve(Action callback = null)
    {
        if (type == ActionType.move) { yield return MoveTo(); };
        if (type == ActionType.playDialog) { yield return PlayDialog(); };
        if (type == ActionType.playAudio) { yield return PlayMusic(); };
        if (delayCallNext != 0) yield return new WaitForSeconds(delayCallNext);
        callback?.Invoke();
    }

    public IEnumerator MoveTo()
    {
        target.transform.DOMove(moveTo, moveSpeed);

        dialogTextCanva.text = "";
        dialogPersonCanva.text = "";
        yield return null;
    }

    public IEnumerator PlayDialog()
    {
        dialogAudioSource.Stop();
        while (dialogAudioSource.isPlaying)
        {
            yield return null;
        };
        dialogAudioSource.clip = dialogToPlay;
        dialogAudioSource.Play();
        dialogTextCanva.text = dialogText;
        dialogPersonCanva.text = dialogPerson;
    }

    public IEnumerator PlayMusic()
    {
        musicAudioSource.Stop();
        while (musicAudioSource.isPlaying)
        {
            yield return null;
        };
        musicAudioSource.clip = musicToPlay;
        musicAudioSource.Play();
    }

}

public class Story : MonoBehaviour
{
    public List<Vector3> _positionCam;
    public List<CustomAction> customActions;
    public int _step = 0;

    public Coroutine actualCoroutine;

    // Start is called before the first frame update
    void OnEnable()
    {
        Main.Instance.CameraManager.mainCamera.gameObject.SetActive(false);
        Main.Instance.CameraManager.UICamera.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        Main.Instance.CameraManager.mainCamera.gameObject.SetActive(true);
        Main.Instance.CameraManager.UICamera.gameObject.SetActive(true);
    }

    void Start()
    {
    }



    public void NextStep()
    {
        if (_step > customActions.Count)
        {
            Main.Instance.GameManager.CinematicDone();
            return;
        }
        if (actualCoroutine != null)
        {
            StopCoroutine(actualCoroutine);
        }
        if (customActions[_step].callNext)
        {
            actualCoroutine = StartCoroutine(customActions[_step].Resolve(NextStep));
            _step++;
            return;
        }
        actualCoroutine = StartCoroutine(customActions[_step].Resolve());
        _step++;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

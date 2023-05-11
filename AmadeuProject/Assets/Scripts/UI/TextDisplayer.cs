using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// UI that will display a Dialog asset
/// </summary>
public class TextDisplayer : MonoBehaviour
{
    /// <summary>
    /// Is this UI visible to the user
    /// </summary>
    private bool isDisplaying;

    /// <summary>
    /// Is the text currently on transition to the UI
    /// </summary>
    private bool isWriting;

    private PermissionStatus permission;

    private new AudioSource audio;

    [SerializeField, Tooltip("Sfx that will play while writing the text")]
    private AudioClip textSfx;

    [SerializeField, Tooltip("Sfx that will play when user send an input")]
    private AudioClip nextSfx;

    /// <summary>
    /// UI item that will display the text
    /// </summary>
    [SerializeField, Tooltip("UI item that will display the text")]
    private TextMeshProUGUI uiText;

    /// <summary>
    /// Delay to display the next letter, of the current text
    /// </summary>
    [SerializeField, Tooltip("Delay to display the next letter, of the current text")]
    private float letterInterval = 0.03f;

    /// <summary>
    /// Image that will be displayed, when the text is waiting for user input
    /// </summary>
    [SerializeField, Tooltip("Image that will be displayed, when the text is waiting for user input")]
    private Image imageFeedback;

    private DialogAsset currentDialog;

    private GameObject currentAsker;

    /// <summary>
    /// Event that will be raised when the current dialog is finished
    /// </summary>
    public UnityEvent onEndDisplay;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Display a dialog, with the responsible of this query
    /// </summary>
    /// <param name="dialog"></param>
    /// <param name="asker"></param>
    public void Display(DialogAsset dialog, GameObject asker)
    {
        if (!isDisplaying)
        {
            currentDialog = dialog;
            currentAsker = asker;
            isDisplaying = true;
            Show();
            imageFeedback.enabled = false;
            permission = PermissionStatus.Undefined;

            //NextStep();
            StartCoroutine(DisplayRoutine(currentDialog.Talk.entryText));
        }
    }

    public void Hide ()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void Show ()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void NextStep ()
    {
        // No text found
        if (isWriting || !isDisplaying)
        {
            return;
        }

        currentDialog.Talk.onNextStep?.Invoke();

        audio.PlayOneShot(nextSfx);
        onEndDisplay.Invoke();
        Hide();
        isDisplaying = false;

        

        if (currentDialog.Talk.conditional != null)
        {

        }
        else
        {
            
        }

return;
        // decide if we start showing the next text, if we close or if we open the next dialog
        switch (permission)
        {
            case PermissionStatus.Undefined:
                break;
            case PermissionStatus.Waiting:
                break;
            case PermissionStatus.Allowed:
                break;
            case PermissionStatus.Denied:
                break;
            default:
                break;
        }

        if (permission == PermissionStatus.Undefined)
        {
            if (currentDialog.Talk.entryText != "")
            {
                permission = PermissionStatus.Waiting;
                StartCoroutine(DisplayRoutine(currentDialog.Talk.entryText));
            }
            else
            {
                // no entry text found, so we jump right at the conditional
                //if (CheckConditional)
            }
        }

        if (permission == PermissionStatus.Waiting && currentDialog.Talk.conditional != null)
        {
            if (currentDialog.Talk.conditional.GetPermission(currentAsker))
            {
                permission = PermissionStatus.Allowed;
                StartCoroutine(DisplayRoutine(currentDialog.Talk.textAllowed));
            }
            else
            {
                permission = PermissionStatus.Denied;
                StartCoroutine(DisplayRoutine(currentDialog.Talk.textDenied));
            }
        }
        else
        {
            // no conditional after reading entry text
            // close the display

            //if (currentDialog.Talk.entryText != "")
            //{
            //    permission = PermissionStatus.Waiting;
            //    StartCoroutine(DisplayRoutine(currentDialog.Talk.entryText));
            //}
        }
        //else
        //{
            
        //        // No text found
        //    }
        //}
        //if (isWriting || !isDisplaying)
        //{
        //    return;
        //}

        //if (currentDialog.Talk.conditional != null)
        //{

        //}
        //else
        //{
        //    onEndDisplay.Invoke();
        //    gameObject.SetActive(false);
        //    isDisplaying = false;
        //}
    }

    private PermissionStatus CheckConditional ()
    {
        if (currentDialog.Talk.conditional != null)
        {
            if (currentDialog.Talk.conditional.GetPermission(currentAsker))
            {
                permission = PermissionStatus.Allowed;
                StartCoroutine(DisplayRoutine(currentDialog.Talk.textAllowed));
                return PermissionStatus.Allowed;
            }
            else
            {
                permission = PermissionStatus.Denied;
                StartCoroutine(DisplayRoutine(currentDialog.Talk.textDenied));
                return PermissionStatus.Denied;
            }
        }
        else
        {
            return PermissionStatus.Undefined;
        }
    }

    private IEnumerator DisplayRoutine (string text)
    {
        uiText.text = "";
        isWriting = true;
        audio.clip = textSfx;
        audio.Play();
        // audio delay to start
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < text.Length; i++)
        {
            uiText.text += text[i];
            yield return new WaitForSeconds(letterInterval);
        }

        yield return null;
        audio.Stop();
        isWriting = false;
        StartCoroutine(WaitPlayerRoutine());
    }

    private IEnumerator WaitPlayerRoutine ()
    {
        while (gameObject.activeInHierarchy)
        {
            imageFeedback.enabled = !imageFeedback.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }
}

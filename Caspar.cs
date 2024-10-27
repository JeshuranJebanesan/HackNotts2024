using NUnit.Framework.Constraints;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Caspar : MonoBehaviour
{
    public Button[] exit;
    public Button enter;

    Vector3 exitPos = new Vector3 (-555, -100, -4050);
    Vector3 enterPos = new Vector3 (-270, -100, -4050);

    float duration = 1.5f;
    float journey;

    private void Start() {
        StartCoroutine(EnterScreen());
        enter.onClick.AddListener(Enter);
        foreach (Button button in exit) {
            button.onClick.AddListener(Exit);
        }
    }

    public void Enter() {
        StartCoroutine (EnterScreen());
    }

    public void Exit() {
        StartCoroutine(ExitScreen());
    }

    private IEnumerator EnterScreen() {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration) {
            journey = elapsedTime / duration;
            journey = Mathf.SmoothStep(0, 1, journey);
            transform.localPosition = Vector3.Slerp(exitPos, enterPos, journey);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = enterPos;
    }

    private IEnumerator ExitScreen() {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration) {
            journey = elapsedTime / duration;
            journey = Mathf.SmoothStep(0, 1, journey);
            transform.localPosition = Vector3.Slerp(enterPos, exitPos, journey);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = exitPos;
    }
}

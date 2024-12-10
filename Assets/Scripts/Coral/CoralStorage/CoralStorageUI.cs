using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoralStorageUI : MonoBehaviour
{
    [SerializeField] CoralStorage owner;
    [SerializeField] GameObject babyParent;
    [SerializeField] TMP_Text babyText;
    [SerializeField] GameObject juvenileParent;
    [SerializeField] TMP_Text juvenileText;
    [SerializeField] float maxScale = 1.5f;
    [SerializeField] float lerpMag = 0.5f;
    RectTransform babyRect;
    RectTransform juvenileRect;

    private void Start() {
        owner.OnGainFragment.AddListener(GainBabyCoralUI);
        owner.OnUseFragment.AddListener(UseBabyCoralUI);
        owner.OnGainJuvenile.AddListener(GainJuvenileCoralUI);
        owner.OnUseJuvenile.AddListener(UseJuvenileCoralUI);

        babyRect = babyParent.GetComponent<RectTransform>();
        juvenileRect = juvenileParent.GetComponent<RectTransform>();
    }

    private void Update() {
        UpdateUI();
        ScaleEffectUpdate();
    }
    private void UpdateUI() {
        babyText.text = owner.GetFragmentCount().ToString();
        juvenileText.text = owner.GetJuvenileCount().ToString();
    }

    private void ScaleEffectUpdate() {
        babyRect.localScale = Vector3.Lerp(babyRect.localScale, Vector3.one, lerpMag);
        juvenileRect.localScale = Vector3.Lerp(juvenileRect.localScale, Vector3.one, lerpMag);
    }

    public void GainBabyCoralUI() {
        babyRect.localScale = new Vector3(1+maxScale, 1+maxScale, 1+maxScale);
    }
    public void UseBabyCoralUI() {
        babyRect.localScale = new Vector3(1-maxScale, 1-maxScale, 1-maxScale);
    }
    public void GainJuvenileCoralUI() {
        juvenileRect.localScale = new Vector3(1+maxScale, 1+maxScale, 1+maxScale);
    }
    public void UseJuvenileCoralUI() {
        juvenileRect.localScale = new Vector3(1-maxScale, 1-maxScale, 1-maxScale);
    }

}

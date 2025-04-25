using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class JuvenileCoralUI : MonoBehaviour {
    [SerializeField] JuvenileCoral owner;
    [SerializeField] Sprite hammerIcon;
    [SerializeField] Sprite coralIcon;
    [SerializeField] Image iconImage;
    [SerializeField] float size;

    private void Update() {
        UpdateUI();
        PointToCamera();
    }

    private void PointToCamera() {
        Vector3 pointToCam = Camera.main.gameObject.transform.position - transform.position;
        transform.forward = -pointToCam.normalized;
    }

    private void UpdateUI() {
        bool enableIcon = false;
        float ratio = 1;

        if (owner.OnNursury()) {
            iconImage.sprite = coralIcon;
            ratio = coralIcon.rect.width / coralIcon.rect.height;
            enableIcon = true;
        }
        else if(owner.OnReefAndHammerable()) {
            iconImage.sprite = hammerIcon;
            ratio = hammerIcon.rect.width / hammerIcon.rect.height;
            enableIcon = true;
        }

        iconImage.rectTransform.sizeDelta = new Vector2(ratio*size, (1/ratio)*size);
        iconImage.gameObject.SetActive(enableIcon);
    }
}

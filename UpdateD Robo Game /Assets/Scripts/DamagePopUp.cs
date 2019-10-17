using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamagePopUp : MonoBehaviour
{

    // Creating DamagePopup

    public static DamagePopUp Create(Vector3 postion , int damageAmount)
    {
        var damagePopTransform = Instantiate(PlayerHealth.instance.damagePopUpText,postion,
            Quaternion.identity);

        DamagePopUp damagePop = damagePopTransform.GetComponent<DamagePopUp>();
        damagePop.Setup(damageAmount);

        return damagePop;
    }

    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }

    private void Update()
    {
        float moveYSpeed = 20f;
        transform.position += new Vector3(0, moveYSpeed, 0f) * Time.deltaTime;
    }
}

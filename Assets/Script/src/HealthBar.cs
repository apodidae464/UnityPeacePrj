using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	enum faceOfPeace
    {
		HAPPY = 0,
		NORMAL,
		UNHAPPY,
		CRYING
    }

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	float currentHeal;

    private void Start()
    {
		slider = this.GetComponent<Slider>();
		slider.maxValue = Constaint.MaxHeal;
		slider.value = Constaint.MaxHeal;
		fill.color = gradient.Evaluate(1f);
		currentHeal = Constaint.MaxHeal;

		GameEvents.instance.OnIncreaseHealBarByCustomer += MoodIndexIncreaseByCustomer;
		GameEvents.instance.OnDecreaseHealBarByCustomer += MoodIndexDecreaseByCustomer;
		GameEvents.instance.onHealBarIncreasing += MoodIndexIncrease;
		GameEvents.instance.onHealBarDecreasing += MoodIndexDecrease;
	}

    public void SetHealth(float health)
	{
		currentHeal = health;
	}


    private void Update()
    {
		currentHeal = Constaint.MaxHeal;
		if (currentHeal <= 0)
		{
			GameEvents.instance.AlertGameOver();
			//GameOver BLOOM!
			//GameCore.Instance.Restart();
		} else 
		if (currentHeal > Constaint.MaxHeal)
		{
			currentHeal = Constaint.MaxHeal;
		} else if (currentHeal <= Constaint.UnHappyPoint)
        {
			GameEvents.instance.ChangePeaceFace((int)faceOfPeace.CRYING);
		} else if (currentHeal > Constaint.UnHappyPoint && currentHeal <= Constaint.NormalPoint)
        {
			GameEvents.instance.ChangePeaceFace((int)faceOfPeace.UNHAPPY);
		}
		else if (currentHeal > Constaint.NormalPoint && currentHeal <= Constaint.HappyPoint)
        {
			GameEvents.instance.ChangePeaceFace((int)faceOfPeace.NORMAL);
		}
		else
        {
			GameEvents.instance.ChangePeaceFace((int) faceOfPeace.HAPPY);
        }

		slider.value = currentHeal;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
	public void MoodIndexDecreaseByCustomer()
	{
		currentHeal -= Constaint.CustomerReduceHealt;
	}

	public void MoodIndexIncreaseByCustomer()
	{
		currentHeal += Constaint.CustomerIncreaseHealt;
	}

	public void MoodIndexIncrease(float value)
    {
		currentHeal += value;
    }

	public void MoodIndexDecrease(float value)
	{
		currentHeal -= value;
	}

	private void OnDestroy()
    {
		GameEvents.instance.OnIncreaseHealBarByCustomer -= MoodIndexIncreaseByCustomer;
		GameEvents.instance.OnDecreaseHealBarByCustomer -= MoodIndexDecreaseByCustomer;
		GameEvents.instance.onHealBarIncreasing -= MoodIndexIncrease;
		GameEvents.instance.onHealBarDecreasing -= MoodIndexDecrease;
	}
}

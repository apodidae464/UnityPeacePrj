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
		slider.maxValue = Consts.MaxHeal;
		slider.value = Consts.MaxHeal;
		fill.color = gradient.Evaluate(1f);
		currentHeal = Consts.MaxHeal;

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
		if (GameEvents.isPause)
			return;

		if (currentHeal <= 0)
		{
			GameEvents.instance.AlertGameOver();
		} 
		
		if (currentHeal > Consts.MaxHeal)
		{
			currentHeal = Consts.MaxHeal;
		}
		slider.value = currentHeal;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
	public void MoodIndexDecreaseByCustomer()
	{
		currentHeal -= Consts.CustomerReduceHealt;
	}

	public void MoodIndexIncreaseByCustomer()
	{
		currentHeal += Consts.CustomerIncreaseHealt;
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

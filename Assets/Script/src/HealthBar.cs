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
		slider.maxValue = AllTag.MaxHeal;
		slider.value = AllTag.MaxHeal;
		fill.color = gradient.Evaluate(1f);
		currentHeal = AllTag.MaxHeal;

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
		if (currentHeal <= 0)
		{
			GameEvents.instance.AlertGameOver();
			//GameOver BLOOM!
			//GameCore.Instance.Restart();
		} else 
		if (currentHeal > AllTag.MaxHeal)
		{
			currentHeal = AllTag.MaxHeal;
		} else if (currentHeal <= AllTag.UnHappyPoint)
        {
			GameEvents.instance.ChangePeaceFace((int)faceOfPeace.CRYING);
		} else if (currentHeal > AllTag.UnHappyPoint && currentHeal <= AllTag.NormalPoint)
        {
			GameEvents.instance.ChangePeaceFace((int)faceOfPeace.UNHAPPY);
		}
		else if (currentHeal > AllTag.NormalPoint && currentHeal <= AllTag.HappyPoint)
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
		currentHeal -= AllTag.CustomerReduceHealt;
	}

	public void MoodIndexIncreaseByCustomer()
	{
		currentHeal += AllTag.CustomerIncreaseHealt;
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

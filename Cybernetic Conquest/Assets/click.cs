using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    public CameraShake camerashake;

    public ParticleSystem particles_broken;
    public ParticleSystem particles_proto;

    public ParticleSystem particles_money;

    public ParticleSystem particles_workers_plus;
    public ParticleSystem particles_workers_minus;

    public ParticleSystem particles_scientists_plus;
    public ParticleSystem particles_scientists_minus;

    public ParticleSystem particles_army_plus;
    public ParticleSystem particles_army_minus;

    public Text workersText;
    public Text scientistsText;
    public Text armyText;

    public Text researchText;
    public Text dominationText;

    public Text humansUnassignedText;
    public Text humansAssignedText;

    public Text moneyText;
    public Text robotsText;
    public Text humansText;

    private int humansUnassigned;

    private int humansAssigned;

    private int robotsBrokenBuilt = 1;
    public Text brokenBuiltText;
    public Text BrokenCostText;
    private float brokenCost = 10f;

    private int robotsProtoBuilt;
    public Text protoBuiltText;
    public Text ProtoCostText;
    private float protoCost = 100f;

    private int money;
    private float decimalMoney;

    private int research;
    private float decimalResearch;

    private int domination;
    private float decimalDomination;

    private int humans;
    private float decimalHumans;

    private int robots = 1;

    private bool max = false;

    private int workers;
    private int scientists;
    private int army;

    public int DelayAmount;
    protected float Timer;

    public int DelayAmount2;
    protected float Timer2;

    public Button toggleButton;
    public Text maxText;

    private bool press = false;
    public Sprite imageOn;
    public Sprite imageOff;

    void Start()
    {
        toggleButton.image.sprite = imageOff;
    }

    private void Update()
    {
        decimalMoney += workers * Time.deltaTime;
        money = Mathf.RoundToInt(decimalMoney);

        var emission = particles_money.emission;
        emission.rateOverTime = workers/10;

        decimalResearch += scientists * Time.deltaTime;
        research = Mathf.RoundToInt(decimalResearch);

        decimalDomination += army * Time.deltaTime;
        domination = Mathf.RoundToInt(decimalDomination);

        Timer += Time.deltaTime;
        Timer2 += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            humansUnassigned += 1 * robots;
            humans += 1 * robots;
        }

        if (Timer2 >= DelayAmount2 && robotsProtoBuilt >= 1)
        {
            Timer2 = 0f;
            humansUnassigned += 1 * robots;
            humans += 1 * robots;
        }

        brokenBuiltText.text = "Built: " + robotsBrokenBuilt.ToString();
        BrokenCostText.text = "Cost: " + brokenCost.ToString();

        protoBuiltText.text = "Built: " + robotsProtoBuilt.ToString();
        ProtoCostText.text = "Cost: " + protoCost.ToString();

        moneyText.text = money.ToString();
        humansUnassignedText.text = "Humans Unassigned: " + humansUnassigned.ToString();
        humansAssignedText.text = "Assigned: " + humansAssigned.ToString();
        humansText.text = humans.ToString();
        researchText.text = research.ToString();
        robotsText.text = robots.ToString();
        dominationText.text = domination.ToString();
        workersText.text = "Workers: " + workers.ToString();
        scientistsText.text = "Scientists: " + scientists.ToString();
        armyText.text = "Army: " + army.ToString();
    }

    public void CreateBroken()
    {
        if (money >= brokenCost)
        {
            robotsBrokenBuilt++;
            decimalMoney -= brokenCost;
            brokenCost = Mathf.RoundToInt(brokenCost * 1.3f);
            robots++;
            particles_broken.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }

    public void CreateProto()
    {
        if (money >= protoCost)
        {
            robotsProtoBuilt++;
            decimalMoney -= protoCost;
            protoCost = Mathf.RoundToInt(protoCost * 1.3f);
            robots += 10;
            particles_proto.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }

    public void IncrementWorkers()
    {
        if (0 < humansUnassigned)
        {
            if (max == true)
            {
                workers += humansUnassigned;
                humansAssigned += humansUnassigned;
                humansUnassigned -= humansUnassigned;
            }
            else
            {
                workers++;
                humansUnassigned--;
                humansAssigned++;
            }
            particles_workers_plus.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }   

    public void DecrementWorkers()
    {
        if (workers > 0)
        {
            if (max == true)
            {
                workers -= humansUnassigned;
                humansAssigned -= humansUnassigned;
                humansUnassigned += humansUnassigned;
            }
            else
            {
                workers--;
                humansUnassigned++;
                humansAssigned--;
            }
            particles_workers_minus.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }

    public void IncrementScientists()
    {
        if (0 < humansUnassigned)
        {
            if (max == true)
            {
                scientists += humansUnassigned;
                humansAssigned += humansUnassigned;
                humansUnassigned -= humansUnassigned;
            }
            else
            {
                scientists++;
                humansUnassigned--;
                humansAssigned++;
            }
            particles_scientists_plus.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }   

    public void DecrementScientists()
    {
        if (scientists > 0)
        {
            if (max == true)
            {
                scientists -= humansUnassigned;
                humansAssigned -= humansUnassigned;
                humansUnassigned += humansUnassigned;
            }
            else
            {
                scientists--;
                humansUnassigned++;
                humansAssigned--;
            }
            particles_scientists_minus.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }

    public void IncrementArmy()
    {
        if (0 < humansUnassigned)
        {
            if (max == true)
            {
                army += humansUnassigned;
                humansAssigned += humansUnassigned;
                humansUnassigned -= humansUnassigned;
            }
            else
            {
                army++;
                humansUnassigned--;
                humansAssigned++;
            }
            particles_army_plus.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }   

    public void DecrementArmy()
    {
        if (army > 0)
        {
            if (max == true)
            {
                army -= humansUnassigned;
                humansAssigned -= humansUnassigned;
                humansUnassigned += humansUnassigned;
            }
            else
            {
                army--;
                humansUnassigned++;
                humansAssigned--;
            }
            particles_army_minus.Play(true);
        }
        else
        {
            camerashake.Shake();
        }
    }

    public void OnToggleClick()
    {
        press = !press;

        if (press == false)
        {
            toggleButton.image.sprite = imageOff;
            maxText.text = "MAX: OFF";
            max = false;
        }
        else
        {
            toggleButton.image.sprite = imageOn;
            maxText.text = "MAX: ON";
            max = true;
        }
    }

    public void OnIncrementWorkersButtonClicked()
    {
        IncrementWorkers();
    }

    public void OnDecrementWorkersButtonClicked()
    {
        DecrementWorkers();
    }

    public void OnIncrementScientistsButtonClicked()
    {
        IncrementScientists();
    }

    public void OnDecrementScientistsButtonClicked()
    {
        DecrementScientists();
    }

    public void OnIncrementArmyButtonClicked()
    {
        IncrementArmy();
    }

    public void OnDecrementArmyButtonClicked()
    {
        DecrementArmy();
    }
}
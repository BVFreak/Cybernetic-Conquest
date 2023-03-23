using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    public CameraShake camerashake;

    public ParticleSystem particles_broken;
    public ParticleSystem particles_proto;

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

    private int workers;
    private int scientists;
    private int army;

    public int DelayAmount;
    protected float Timer;

    public int DelayAmount2;
    protected float Timer2;

    private void Update()
    {
        decimalMoney += workers * Time.deltaTime;
        money = Mathf.RoundToInt(decimalMoney);

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
            workers++;
            humansUnassigned--;
            humansAssigned++;
        }
    }   

    public void DecrementWorkers()
    {
        if (workers > 0)
        {
            workers--;
            humansUnassigned++;
            humansAssigned--;
        }
    }

    public void IncrementScientists()
    {
        if (0 < humansUnassigned)
        {
            scientists++;
            humansUnassigned--;
            humansAssigned++;
        }
    }   

    public void DecrementScientists()
    {
        if (scientists > 0)
        {
            scientists--;
            humansUnassigned++;
            humansAssigned--;
        }
    }

    public void IncrementArmy()
    {
        if (0 < humansUnassigned)
        {
            army++;
            humansUnassigned--;
            humansAssigned++;
        }
    }   

    public void DecrementArmy()
    {
        if (army > 0)
        {
            army--;
            humansUnassigned++;
            humansAssigned--;
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
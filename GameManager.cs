using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI speechBubble;
    public TextMeshProUGUI coinLabel;
    public TextMeshProUGUI error;
    public TextMeshProUGUI ratio;
    public TextMeshProUGUI investLabel;
    public TMP_InputField investInput;
    public Button next;

    public Queue<Event> events;
    Event currentEvent;
    Event win;
    Event lose;

    int lineCounter = 0;
    int coins = 5000;
    public int eventNum = 3;
    int eventCounter = 1;

    public Equities currentEquity;
    public Equities[] equities;
    public Equities g;
    public Equities n;
    public Equities p;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        g = equities[0];
        n = equities[1];
        p = equities[2];

        string[] startLines = { "Hey I'm Caspar, your grandfather.", "I squandered my wealth and now my pride and joy, my mansion on Wall Street has been...", "REPOSSESSED!!!", "I've left you whats left of my wealth, a measly 5000 dead man's gold.", "Buy back the house I lost by getting to 7000!", "Your current gold is in the top left", "And you can access equities to buy or sell on the right", "I'll tell you any premonitions I have that may be of help" };
        Event start = new Event(startLines);
        string[] ghoulgleLines1 = { "Ghougle hosts a global Hack-A-Thon!!", "Limbs fly everywhere in this whimsical competition, with a variety of challenges such as Skull Carving and Trick-O-Tricking.", "Notable appearances include Meve Wagley and Stax Bilson!", "The event generates immense excitement and engagement!" };
        Event ghoulgle1 = new Event(ghoulgleLines1);
        string[] ghoulgleLines2 = { "OH NOOO!!!", "Meve and Stax' not-so-evil twins: Beve Stagley and Wax Milson also showed up to the Ghoulgle hackathon. They are bringing down the mood talking about real estate and toilets??" };
        Event ghoulgle2 = new Event(ghoulgleLines2);
        string[] plagLines1 = { "Plaguezer unveils its latest vaccine \"The Phantom Panacea\" for new virus strain, stocks soar.", "It is too early to tell if there may be any side effects." };
        Event plag1 = new Event(plagLines1);
        string[] plagLines2 = { "Reports surface that some who receive the vaccine experience ghostly “echoes” of themselves, known as Wraith Syndrome", "People claim they see fleeting glimpses of themselves in mirrors or feel a double presence. Stock prices wobble as the public grows wary of this uncanny side effect." };
        Event plag2 = new Event(plagLines2);
        string[] necroLines1 = { "NecroVIDIA desperate to combat Arcane Machine Dominion call upon ancient spoo-oooo-oooky magic to counterract AMD's pesky curses", "Unfortunately, AMD has had too much of a headstart. If only some conveniently timed distractions could occur..." };
        Event necro1 = new Event(necroLines1);
        string[] necroLines2 = { "Somehow", "Someway", "THEY'VE DONE IT AGAIN!!!", "NecroVIDIA has pulled it out of the bag, soaring over AMD for now", "Some are calling it the RTX Revolution!!!" };
        Event necro2 = new Event(necroLines2);


        string[] winLines = { "Well done!", "You managed the information you had well", "Don't get too cocky now! That's how I got got.", "Enjoy your wealth, I shall be taking my leave now." };
        win = new Event(winLines);
        string[] loseLines = { "Nice try", "You can always try again with the information you have learnt.", "Think about the outcomes of each event and try your best!", "Goodbye now!" };
        lose = new Event(loseLines);

        events = new Queue<Event>();
        events.Enqueue(start);
        events.Enqueue(plag1);
        events.Enqueue(ghoulgle1);
        events.Enqueue(necro1);
        events.Enqueue(ghoulgle1);
        events.Enqueue(plag2);
        events.Enqueue(necro2);
        currentEvent = events.Dequeue();
        speechBubble.text = currentEvent.actions[lineCounter];
    }

    public void Next() {
        if (currentEvent != win && currentEvent != lose) {            
            if (coins >= 7000) {
                currentEvent = win;
                lineCounter = -1;
            }

            lineCounter++;

            if (lineCounter == currentEvent.actions.Length) {
                if (events.Count == 0) {
                    currentEvent = lose;
                    lineCounter = 0;
                    speechBubble.text = currentEvent.actions[lineCounter];
                    return;
                }
                NextEvent();
                currentEvent = events.Dequeue();
                lineCounter = 0;
            }
            speechBubble.text = currentEvent.actions[lineCounter];
        } else { 

            lineCounter++;

            if (lineCounter == currentEvent.actions.Length) {
                Application.Quit();
            }

            speechBubble.text = currentEvent.actions[lineCounter];
        }
    }

    public void NextEvent() {
        eventCounter++;
        
        switch (eventCounter) {
            case 0:
                p.value += 1;
                n.value += 2;
                g.value += 1;
                break;
            case 1:
                p.value += 1;
                n.value += 2;
                g.value += 2;
                break;
            case 2:
                p.value += 2;
                n.value += -3;
                g.value += 5;
                break;
            case 3:
                p.value += 2;
                n.value += -4;
                g.value += -2;
                break;
            case 4:
                p.value -= 3;
                n.value += -5;
                g.value += -5;
                break;
            case 5:
                p.value -= 5;
                n.value += 6;
                g.value += -1;
                break;
        }
    }

    public void EventCommentary() {
        if (currentEquity == g) {
            switch (eventCounter) {
                case 0:
                    speechBubble.text = "Some news on a great Ghoulgle event coming up!";
                    break;
                case 1:
                    speechBubble.text = "Sure am thriving with Ghoulgle right now!";
                    break;
                case 2:
                    speechBubble.text = "Dont those 2 over there look suspicious? I'm getting a weird feeling...";
                    break;
                case 3:
                    speechBubble.text = "Feels like the calm before the storm...";
                    break;
                case 4:
                    speechBubble.text = "What a downer... Maybe It'll be over quick";
                    break;
                case 5:
                    speechBubble.text = "Ghoulgle back to normal";
                    break;
            }
        } else if(currentEquity == n) {
            switch (eventCounter) {
                case 0:
                    speechBubble.text = "Seems alright";
                    break;
                case 1:
                    speechBubble.text = "Competition is brewing";
                    break;
                case 2:
                    speechBubble.text = "I hope they can pull this one off. But it doesn't look good!";
                    break;
                case 3:
                    speechBubble.text = "They're in the thick of it right now!";
                    break;
                case 4:
                    speechBubble.text = "On the bright side, the Arcane Machine Dominion gained sentience and abandoned competition against NecroVIDIA!";
                    break;
                case 5:
                    speechBubble.text = "Nice!!!";
                    break;
            }
        } else if (currentEquity == p) {
            switch (eventCounter) {
                case 0:
                    speechBubble.text = "Sounds good";
                    break;
                case 1:
                    speechBubble.text = "Hmmm, I've been hearing rumors";
                    break;
                case 2:
                    speechBubble.text = "I'd be wary around Plaguezer. The market is in a very volatile state";
                    break;
                case 3:
                    speechBubble.text = "Now is when side effects might show up!";
                    break;
                case 4:
                    speechBubble.text = "Be wary";
                    break;
                case 5:
                    speechBubble.text = "Alright!";
                    break;
            }
        }
    }

    public void SetCurrentEquity(Equities equity) {
        Debug.Log("1");
        currentEquity = equity;
        Debug.Log("2");
        investLabel.text = $"{equity.investment}";
        Debug.Log(currentEquity.name);
        ratio.text = $"Coins : {equity.equityName} = 1 : {equity.value}";
    }

    public void Buy() {
        if(int.TryParse(investInput.text, out int investments)) {
            if (coins < investments) {
                error.text = "Cannot afford!";
                return;
            }

            coins -= investments;
            currentEquity.investment += (int)(Mathf.Ceil(investments / currentEquity.value));
            coinLabel.text = $"{coins}";
            investLabel.text = $"{currentEquity.investment}";
        } else {
            error.text = "Enter a number!";
        }
    }

    public void Sell() {
        if (int.TryParse(investInput.text, out int divestments)) {
            if (currentEquity.investment < divestments) {
                error.text = $"Not enough {currentEquity} to proceed!";
                return;
            }

            coins += (int)Mathf.Ceil(divestments * currentEquity.value);
            currentEquity.investment -= divestments;
            coinLabel.text = $"{coins}";
            investLabel.text = $"{currentEquity.investment}";

        } else {
            error.text = "Enter a number!";
        }
    }

    public void EquityEnable() {
        foreach (Equities equity in equities) {
            if(equity.free) {
                equity.gameObject.SetActive(true);
            }
        }
    }

    public void EquityDisable() {
        foreach (Equities equity in equities) {
            currentEquity.free = false;
            equity.gameObject.SetActive(false);
        }
    }

    public void FreeEquity() {
        foreach(Equities equity in equities) {
            equity.free = true;
        }
    }

    public void DisableContinue() {
        next.gameObject.SetActive(false);
    }

    public void EnableContinue() {
        next.gameObject.SetActive(true);
    }
}
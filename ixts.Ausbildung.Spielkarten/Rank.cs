using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Spielkarten
{
    public class Rank
    {
        private readonly Hand hand;
        private readonly Boolean[] optionList;
        private readonly Boolean ichiNi;
        private readonly Boolean ichiSan;
        private readonly Boolean ichiYon;
        private readonly Boolean ichiGo;
        private readonly Boolean niSan;
        private readonly Boolean niYon;
        private readonly Boolean niGo;
        private readonly Boolean sanYon;
        private readonly Boolean sanGo;
        private readonly Boolean yonGo;

        public Rank(Hand hand)
        {
            this.hand = hand;
            ichiNi = hand.CardIchi.CardKind == hand.CardNi.CardKind;
            ichiSan = hand.CardIchi.CardKind == hand.CardSan.CardKind;
            ichiYon = hand.CardIchi.CardKind == hand.CardYon.CardKind;
            ichiGo = hand.CardIchi.CardKind == hand.CardGo.CardKind;
            niSan = hand.CardNi.CardKind == hand.CardSan.CardKind;
            niYon = hand.CardNi.CardKind == hand.CardYon.CardKind;
            niGo = hand.CardNi.CardKind == hand.CardGo.CardKind;
            sanYon = hand.CardSan.CardKind == hand.CardYon.CardKind;
            sanGo = hand.CardSan.CardKind == hand.CardGo.CardKind;
            yonGo = hand.CardYon.CardKind == hand.CardGo.CardKind;
            optionList = new[] { ichiNi, ichiSan, ichiYon, ichiGo, niSan, niYon, niGo, sanYon, sanGo, yonGo };

        }

        public String GetRank()
        {
            return CheckRank();
        }

        private String CheckRank()
        {
            if (hand.CardIchi.Equals(hand.CardNi) || hand.CardIchi.Equals(hand.CardSan) || hand.CardIchi.Equals(hand.CardYon) || hand.CardIchi.Equals(hand.CardGo) ||
                hand.CardNi.Equals(hand.CardSan) || hand.CardNi.Equals(hand.CardYon) || hand.CardNi.Equals(hand.CardGo) ||
                hand.CardSan.Equals(hand.CardYon) || hand.CardSan.Equals(hand.CardGo) || hand.CardYon.Equals(hand.CardGo))
            {
                throw new Exception("Es dürfen keine zwei Karten gleich sein");
            }

            if (CheckStraight())
            {
                if (CheckFlush())
                {
                    if (hand.CardIchi.CardKind == Kind.A || hand.CardNi.CardKind == Kind.A || hand.CardSan.CardKind == Kind.A ||
                        hand.CardYon.CardKind == Kind.A || hand.CardGo.CardKind == Kind.A)
                    {
                        return "Royal Flush";
                    }
                    return "Straight Flush";
                }
                return "Straight";
            }
            if (CheckFlush())
            {
                return "Flush";
            }

            if (CheckFourOfAKind())
            {
                return "Four of a Kind";
            }

            if (CheckThreeOfAKind())
            {
                return CheckFullHouse() ? "Full House" : "Three of a Kind";
            }

            if (CheckPair())
            {
                return CheckAnotherPair() ? "Two Pairs" : "One Pair";
            }

            return "High Card";
        }

        private Boolean CheckStraight()
        {
            var handList = new List<Card>{hand.CardNi,hand.CardSan,hand.CardYon,hand.CardGo};
            var goalList = new List<Card>{hand.CardIchi};

            while (goalList.Count != 5)
            {
                if (goalList.Count == 1)
                {
                    for (var i = 0; i < handList.Count; i++)
                    {
                        if (handList[i].CardKind - 1 == goalList[0].CardKind)
                        {
                            goalList.Add(handList[i]);
                            handList.RemoveAt(i);
                            break;
                        }

                        if (handList[i].CardKind + 1 == goalList[0].CardKind || handList[i].CardKind - 12 == goalList[0].CardKind)
                        {
                            goalList.Insert(0,handList[i]);
                            handList.RemoveAt(i);
                            break;
                        }
                    }

                    if (goalList.Count == 1)
                    {
                        return false;
                    }
                }
                else
                {
                    var count = goalList.Count;
                    for (var i = 0; i < handList.Count; i++)
                    {
                        if (handList[i].CardKind - 1 == goalList[0].CardKind)
                        {
                            return false;
                        }
                        if (handList[i].CardKind + 1 == goalList[0].CardKind || handList[i].CardKind - 12 == goalList[0].CardKind)
                        {
                            goalList.Insert(0,handList[i]);
                            handList.RemoveAt(i);
                            break;
                        }
                        if (handList[i].CardKind - 1 == goalList[goalList.Count - 1].CardKind)
                        {
                            goalList.Add(handList[i]);
                            handList.RemoveAt(i);
                            break;
                        }
                    }
                    if (goalList.Count == count)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Boolean CheckFlush()
        {
            return hand.CardIchi.CardSuit == hand.CardNi.CardSuit && hand.CardNi.CardSuit == hand.CardSan.CardSuit &&
                   hand.CardSan.CardSuit == hand.CardYon.CardSuit && hand.CardYon.CardSuit == hand.CardGo.CardSuit;
        }

        private Boolean CheckFourOfAKind()
        {
            var optionlist = new[] { ichiNi, ichiSan, ichiYon, ichiGo, niSan, niYon, niGo, sanYon, sanGo, yonGo };
            var count = 0;

            for (int i = 0; i < optionlist.Length; i++)
            {
                if (optionlist[i])
                {
                    count += 1;
                }
            }

            return count == 6;
        }

        private Boolean CheckThreeOfAKind()
        {

            var count = 0;

            for (var i = 0; i < optionList.Length; i++)
            {
                if (optionList[i])
                {
                    count += 1;
                }
            }

            return count == 3 || count == 4;
        }

        private Boolean CheckFullHouse()
        {
            var count = 0;

            for (var i = 0; i < optionList.Length; i++)
            {
                if (optionList[i])
                {
                    count += 1;
                }
            }

            return count == 4;
        }

        private Boolean CheckPair()
        {
            for (var i = 0; i < optionList.Length; i++)
            {
                if (optionList[i])
                {
                    return true;
                }
            }

            return false;
        }

        private Boolean CheckAnotherPair()
        {
            var count = 0;

            for (var i = 0; i < optionList.Length; i++)
            {
                if (optionList[i])
                {
                    count += 1;
                }
            }

            return count == 2;
        }
    }
}

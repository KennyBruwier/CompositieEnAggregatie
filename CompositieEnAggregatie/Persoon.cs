using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class Persoon
    {
        private const byte maxHoofd = 1;
        private const byte maxHanden = 2;
        private const byte maxBenen = 2;
        private Hand[] handen = new Hand[maxHanden];
        private Head[] hoofd = new Head[maxHoofd];
        private Leg[] benen = new Leg[maxBenen];

        public void HoofdToevoegen(Head hoofd)
        {
            if (this.hoofd != null)
                if (this.hoofd.GetLength(0) < maxHoofd)
                    this.hoofd[this.hoofd.GetLength(0)+1] = hoofd;
            else
                this.hoofd[0] = hoofd;
        }
        public void HandenToevoegen(Hand hand)
        {
            if (this.handen != null)
                if (this.handen.GetLength(0) < maxHanden)
                    this.handen[this.handen.GetLength(0) + 1] = hand;
            else
                this.handen[0] = hand;
        }
        public void BenenToevoegen(Leg been)
        {
            if (this.benen != null)
                if (this.benen.GetLength(0) < maxBenen)
                    this.benen[this.benen.GetLength(0) + 1] = been;
            else
                this.benen[0] = been;
        }
    }

    class Hand
    {

    }
    class Head
    {

    }
    class Leg
    {

    }
}

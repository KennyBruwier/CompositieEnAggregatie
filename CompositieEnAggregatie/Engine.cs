using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class Engine
    {
        private const byte maxCrankshaft = 1;
        private const byte maxPiston = 8;
        private const byte minPiston = 4; // niets met gedaan
        private Crankshaft[] crankshafts= new Crankshaft[maxCrankshaft];
        private Piston[] pistons = new Piston[maxPiston];

        public void CrankshaftToevoegen(Crankshaft crankshaft)
        {
            if (this.crankshafts != null)
                if (this.crankshafts.GetLength(0) < maxCrankshaft)
                    this.crankshafts[this.crankshafts.GetLength(0) + 1] = crankshaft;
                else
                    this.crankshafts[0] = crankshaft;
        }
        public void PistonToevoegen(Piston piston)
        {
            if (this.pistons != null)
                if (this.pistons.GetLength(0) < maxCrankshaft)
                    this.pistons[this.pistons.GetLength(0) + 1] = piston;
                else
                    this.pistons[0] = piston;
        }
    }
    class Crankshaft
    {

    }
    class Piston
    {

    }
    class Car
    {
        private const byte maxEngine = 1;
        private Engine[] engines = new Engine[maxEngine];
        private const byte maxWheel = 4;
        private Wheel[] wheels = new Wheel[maxWheel];
        public void EngineToevoegen(Engine engine)
        {
            if (this.engines != null)
                if (this.engines.GetLength(0) < maxEngine)
                    this.engines[this.engines.GetLength(0) + 1] = engine;
                else
                    this.engines[0] = engine;
        }
        public void WheelToevoegen(Wheel wheel)
        {
            if (this.wheels != null)
                if (this.wheels.GetLength(0) < maxEngine)
                    this.wheels[this.wheels.GetLength(0) + 1] = wheel;
                else
                    this.wheels[0] = wheel;
        }

    }
    class Wheel
    {

    }
    class Boat
    {
        private const byte maxEngine = 1;
        private const byte maxPropeller = 4;
        private Engine[] engines = new Engine[maxEngine];
        private Propeller[] propellers = new Propeller[maxPropeller];

        public void EngineToevoegen(Engine engine)
        {
            if (this.engines != null)
                if (this.engines.GetLength(0) < maxEngine)
                    this.engines[this.engines.GetLength(0) + 1] = engine;
                else
                    this.engines[0] = engine;
        }
        public void PropellerToevoegen(Propeller propeller)
        {
            if (this.propellers != null)
                if (this.propellers.GetLength(0) < maxPropeller)
                    this.propellers[this.engines.GetLength(0) + 1] = propeller;
                else
                    this.propellers[0] = propeller;
        }
    }
    class Propeller
    {

    }
}

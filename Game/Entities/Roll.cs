namespace BowlingGame
{
    public interface IRoll
    {
        public IRoll Roll(int pins, Frame frame);
    }

    public class FirstRoll : IRoll
    {
        public IRoll Roll(int pins, Frame frame)
        {
            frame.FirstRollPins += pins;
            if (frame.CheckStrike(pins))
            {
                frame.Counter = new ScoreCounterWithStrike();
                return null;
            }
            else
            {
                return new SecondRoll();
            }
        }
    }

    public class SecondRoll : IRoll
    {
        public IRoll Roll(int pins, Frame frame)
        {
            frame.SecondRollPins += pins;
            if (frame.CheckSpare())
            {
                frame.Counter = new ScoreCounterWithSpare();
            }
            return null;
        }
    }

    public class FirstRollTenthFrame : IRoll
    {
        public IRoll Roll(int pins, Frame frame)
        {
            frame.FirstRollPins += pins;
            if (frame.CheckStrike(pins))
            {
                return new FirstBonusRoll();
            }
            else
            {
                return new SecondRollTenthFrame();
            }
        }
    }

    public class SecondRollTenthFrame : IRoll
    {
        public IRoll Roll(int pins, Frame frame)
        {
            frame.SecondRollPins += pins;
            if (frame.CheckSpare())
            {
                return new SecondBonusRoll();
            }
            return null;
        }
    }

    public class FirstBonusRoll : IRoll
    {
        public IRoll Roll(int pins, Frame frame)
        {
            frame.FirstRollPins += pins;
            return new SecondBonusRoll();
        }
    }

    public class SecondBonusRoll : IRoll
    {
        public IRoll Roll(int pins, Frame frame)
        {
            frame.SecondRollPins += pins;
            return null;
        }
    }

}
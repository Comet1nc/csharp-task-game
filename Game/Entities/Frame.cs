namespace BowlingGame
{
    public class Frame
    {
        public int FirstRollPins { get; set; } = 0;
        public int SecondRollPins { get; set; } = 0;
        public virtual IRoll? CurrentRoll { get { return _currentRoll; } }
        public virtual IScoreCounter Counter { get; set; } = new ScoreCounterDefault();
        private IRoll? _currentRoll = new FirstRoll();
        public int GetRollsSum() => FirstRollPins + SecondRollPins;
        public bool CheckStrike() => FirstRollPins == 10 || SecondRollPins == 10;
        public bool CheckStrike(int pins) => pins == 10;
        public bool CheckSpare() => FirstRollPins + SecondRollPins > 9;

        public virtual void Roll(int pins)
        {
            var nextRoll = _currentRoll.Roll(pins, this);
            _currentRoll = nextRoll;
        }
    }
}
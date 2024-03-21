namespace BowlingGame
{
    public class TenthFrame : Frame
    {
        public override IRoll? CurrentRoll { get { return _currentRoll; } }
        private IRoll? _currentRoll = new FirstRollTenthFrame();

        public override void Roll(int pins)
        {
            var nextRoll = _currentRoll.Roll(pins, this);
            _currentRoll = nextRoll;
        }
    }
}
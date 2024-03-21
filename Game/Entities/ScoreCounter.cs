namespace BowlingGame
{
    public interface IScoreCounter
    {
        public int CountScore(int currentFrameIndex, List<Frame> frames);
    }

    public class ScoreCounterDefault() : IScoreCounter
    {
        public int CountScore(int currentFrameIndex, List<Frame> allFrames)
        {
            return allFrames[currentFrameIndex].GetRollsSum();
        }
    }

    public class ScoreCounterWithSpare() : IScoreCounter
    {
        public int CountScore(int currentFrameIndex, List<Frame> allFrames)
        {
            var currentFrame = allFrames[currentFrameIndex];
            return currentFrame.GetRollsSum() + allFrames[currentFrameIndex + 1].FirstRollPins;
        }
    }

    public class ScoreCounterWithStrike() : IScoreCounter
    {
        public int CountScore(int currentFrameIndex, List<Frame> allFrames)
        {
            var currentFrame = allFrames[currentFrameIndex];
            var nextFrame = allFrames[currentFrameIndex + 1];
            var nextFrameSum = nextFrame.GetRollsSum();

            if (nextFrame.CheckStrike())
            {
                int thirdFrameSum = 0;
                if (currentFrameIndex < 8)
                {
                    var thirdFrame = allFrames[currentFrameIndex + 2];
                    thirdFrameSum = thirdFrame.GetRollsSum() > 10 ? 10 : thirdFrame.GetRollsSum();
                }
                else if (currentFrameIndex == 8) nextFrameSum = nextFrameSum > 20 ? 20 : nextFrameSum;

                return currentFrame.GetRollsSum() + nextFrameSum + thirdFrameSum;
            }
            else
            {
                return currentFrame.GetRollsSum() + (nextFrameSum > 10 ? 10 : nextFrameSum);
            }
        }
    }


}
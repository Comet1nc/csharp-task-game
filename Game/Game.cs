namespace BowlingGame
{
  public class Game
  {
    private const int _framesCapacity = 10;
    private List<Frame> _frames = new List<Frame>(_framesCapacity);
    private int _currentFrameIndex = 0;
    private int _totalScore = 0;
    public bool Complete { get; private set; } = false;

    public Game()
    {
      setupInitGameState();
    }

    private void setupInitGameState()
    {
      for (int i = 0; i < 9; i++)
      {
        _frames.Add(new Frame());
      }
      _frames.Add(new TenthFrame());
    }

    public void Roll(int pins)
    {
      var currentFrame = _frames[_currentFrameIndex];

      currentFrame.Roll(pins);

      var frameScore = currentFrame.Counter.CountScore(_currentFrameIndex, _frames);

      _totalScore = CountTotalScore(_currentFrameIndex);

      DisplayScoreAfterRoll(frameScore);

      if (currentFrame.CurrentRoll == null)
      {
        if (_currentFrameIndex == 9)
        {
          DisplayEndGameText();
          Complete = true;
        }
        _currentFrameIndex++;
      };
    }

    public void DisplayScoreAfterRoll(int frameScore)
    {
      Console.WriteLine($"Frame {_currentFrameIndex + 1} /10 | Frame Score: {frameScore} | Total Score: {_totalScore + frameScore}");
    }

    private void DisplayEndGameText()
    {
      Console.WriteLine("----------------------------------");
      Console.WriteLine("Congratulations! Game is finished!");
      Console.WriteLine($"TOTAL SCORE: {_totalScore}");
    }

    private int CountTotalScore(int maxIndex)
    {
      var totalScore = 0;
      for (int i = 0; i < maxIndex; i++)
      {
        int frameScore = _frames[i].Counter.CountScore(i, _frames);
        totalScore += frameScore;
      }
      return totalScore;
    }

    public int GetScore()
    {
      int totalScore = 0;

      Console.WriteLine("SCORE TABLE: ");

      for (int i = 0; i < _frames.Count; i++)
      {
        int frameScore = _frames[i].Counter.CountScore(i, _frames);
        totalScore += frameScore;

        Console.WriteLine($"Frame: {i + 1} / Frame score: {frameScore} / Total score: {totalScore}");
      }

      return totalScore;
    }
  }
}

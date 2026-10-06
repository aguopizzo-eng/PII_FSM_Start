using NUnit.Framework;

namespace Ucu.Poo.StateMachine
{
  [TestFixture]
  public class MusicPlayerTests
  {
    private MusicPlayer player;
    private StoppedState stopped;
    private PausedState paused;
    private PlayingState playing;
    private InputSymbol play;
    private InputSymbol pause;
      
    [SetUp]
    public void SetUp()
    {
      this.stopped = new StoppedState();
      this.paused = new PausedState();
      this.playing = new PlayingState();

      this.play = new Play();
      this.pause = new Pause();

      this.player = new MusicPlayer(stopped);
      
    }

    [Test]
    public void SetUpInitialState_WhenInputGiven_ReturnsTrue()
    {
      // Act
      State input = player.CurrentState;

      // Assert 
      Assert.That(input, Is.SameAs(this.player.CurrentState));
    }

    [Test]
    public void AddingNewState_WhenStateGiven_IncreaseSize()
    {
      this.player.AddState(this.playing);
      int size1 = this.player.States.Count;

      this.player.AddState(this.paused);
      int size2 = this.player.States.Count;

      Assert.That(size1, Is.EqualTo(1));
      Assert.That(size2, Is.EqualTo(2));
    }

    [Test]
    public void AddingExistingState_WhenStateGiven_DoesNotIncreaseSize()
    {
      this.player.AddState(this.playing);
      int size1 = this.player.States.Count;

      this.player.AddState(this.playing);
      int size2 = this.player.States.Count;

      Assert.That(size1, Is.EqualTo(1));
      Assert.That(size1, Is.EqualTo(size2));
    }
    
    [Test]
    public void ProcessInput_WhenInputGiven_ReturnsRightState()
    {
      this.player.AddState(this.playing);
      this.stopped.AddTransition(this.play, this.playing);
      bool result = this.player.ProcessInput(this.play);
      
      State output = this.player.CurrentState;
      
      Assert.That(result, Is.True);
      Assert.That(output, Is.TypeOf<PlayingState>());
    }

    [Test]
    public void ProcessMultipleInputs_WhenTwoInputsGiven_ReturnsRightValue()
    {
      this.player.AddState(this.playing);
      this.player.AddState(this.stopped);

      this.stopped.AddTransition(this.play, this.playing);
      this.player.ProcessInput(this.play);
      State output1 = this.player.CurrentState;

      this.playing.AddTransition(this.pause, this.paused);
      this.player.ProcessInput(this.pause);
      State output2 = this.player.CurrentState;

      Assert.That(output1, Is.TypeOf<PlayingState>());
      Assert.That(output2, Is.TypeOf<PausedState>());
    }

    [Test]
    public void ProcessInvalidInput_WhenInputGiven_ReturnsFalse()
    {
      this.player.AddState(this.playing);
      this.stopped.AddTransition(this.play, this.playing);

      bool result = this.player.ProcessInput(this.pause);

      Assert.That(result, Is.False);
      Assert.That(this.player.CurrentState, Is.TypeOf<StoppedState>());
    }

    [Test]
    public void TransitionIsAdded_WhenTransitionGiven_ReturnRightFunction()
    {
      int transitions = this.stopped.Transitions.Count;
      this.stopped.AddTransition(this.play, this.playing);
      int transitions2 = this.stopped.Transitions.Count;

      Assert.That(transitions, Is.EqualTo(0));
      Assert.That(transitions2, Is.EqualTo(1));
    }

    [Test]
    public void TransitionIsNotAdded_WhenExistingTransitionGiven_DoesNotIncreaseTransitionsListSize()
    {
      this.stopped.AddTransition(this.play, this.playing);
      int transitions = this.stopped.Transitions.Count;

      this.stopped.AddTransition(this.play, this.playing);
      int transitions2 = this.stopped.Transitions.Count;

      Assert.That(transitions, Is.EqualTo(1));
      Assert.That(transitions2, Is.EqualTo(transitions));
    }
  }
}
using System;

namespace Base.Ravel.Games.Planes
{
    public abstract class PlaneGameMode<T>
    {
        public bool GameRunning { get; private set; }
        public ScoreTracker<T> Score { get; protected set; }

        public Action onGameStart;
        public Action onGameEnd;
        public Action<object> onScoreChanged;

        public virtual void StartGame()
        {
            onGameStart?.Invoke();
            GameRunning = true;
        }

        public virtual void EndGame()
        {
            if (!GameRunning)
                return;

            onGameEnd?.Invoke();
            GameRunning = false;
        }

        //for update based games
        public virtual void Update() { }
    }
}
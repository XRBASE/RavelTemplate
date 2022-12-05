using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TweenTransform : MonoBehaviour
{
        public Transform tweenTransform;
        public List<Transform> targets;
        public float tweenTime;
        public Ease positionEase, rotationEase;
        public UnityEvent onTweenComplete;
        public bool looping;
        public bool playOnAwake;
        private Sequence _positionSequence, _rotationSequence;
        private void Awake()
        {
                if (playOnAwake)
                {
                        SetupSequence();
                        Play();
                }
        }

        /// <summary>
        /// Setup tween sequence based on the amount of transforms serialised. translates from a-b and rotates from a-b
        /// </summary>
        public void SetupSequence()
        {
                if (tweenTransform == null)
                        tweenTransform = transform;
                _positionSequence = DOTween.Sequence();
                _rotationSequence = DOTween.Sequence();
                foreach (var trans in targets)
                {
                        var move = tweenTransform.DOMove(trans.position, tweenTime)
                                .SetEase(positionEase);
                        _positionSequence.Append(move);
                        var rotate = tweenTransform.DORotate(trans.rotation.eulerAngles, tweenTime)
                                .SetEase(rotationEase);
                        _rotationSequence.Append(rotate);
                }

                _positionSequence.onComplete += () =>
                {
                        onTweenComplete?.Invoke();
                };
                _positionSequence.SetDelay(-tweenTime);
                _rotationSequence.SetDelay(-tweenTime);
                _positionSequence.SetLoops(looping ? -1 : 0);
                _rotationSequence.SetLoops(looping ? -1 : 0);
        }

        /// <summary>
        /// Start the translate and rotate tween
        /// </summary>
        public void Play()
        {
                _positionSequence.Play();
                _rotationSequence.Play();
        }

        /// <summary>
        /// Stops the translate and rotate tween
        /// </summary>
        public void Stop()
        {
                _positionSequence.Kill(true);
                _rotationSequence.Kill(true);
        }
        
        
        
}

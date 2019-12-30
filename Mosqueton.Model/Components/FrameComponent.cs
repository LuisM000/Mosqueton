using System;
using System.Collections.Generic;
using System.Linq;
using Mosqueton.Infrastructure;

namespace Mosqueton.Model.Components
{
    public class FrameComponent : BaseEntity
    {
        private TimeSpan _accumulatedTime;
        private bool _framesDurationIsDirty = true;
        private TimeSpan _framesDuration;

        TimeSpan FramesDuration
        {
            get
            {
                if (!_framesDurationIsDirty)
                {
                    return _framesDuration;
                }

                _framesDuration = TimeSpan.FromTicks(Frames.Sum(f => f.Duration.Ticks));
                return _framesDuration;
            }
        }

        public IList<Frame> Frames { get; set; }

        public Frame CurrentFrame
        {
            get
            {
                if(_accumulatedTime > FramesDuration)
                {
                    _accumulatedTime = TimeSpan.Zero;
                    return Frames.First();
                }

                var animationTime = TimeSpan.Zero;
                foreach (var frame in Frames)
                {
                    if ((_accumulatedTime >= animationTime) && (_accumulatedTime <= animationTime + frame.Duration))
                    {
                        return frame;
                    }
                    animationTime += frame.Duration;
                }

                return Frames.First();
            }
        }



        public void Update(TimeSpan gameTime)
        {
            _accumulatedTime += gameTime;
        }        
    }
}

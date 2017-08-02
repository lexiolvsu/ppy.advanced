﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.MathUtils;
using osu.Game.Rulesets.Catch.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK;

namespace osu.Game.Rulesets.Catch.Objects.Drawable
{
    internal class DrawableFruit : DrawableHitObject<CatchBaseHit, CatchJudgement>
    {
        public DrawableFruit(CatchBaseHit h) : base(h)
        {
            Origin = Anchor.Centre;
            Size = new Vector2(50);
            RelativePositionAxes = Axes.Both;
            Position = new Vector2(h.Position, -0.1f);
            Rotation = (float)(RNG.NextDouble() - 0.5f) * 40;

            Alpha = 0;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Children = new Framework.Graphics.Drawable[]
            {
                new Circle
                {
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.12f),
                    Y  = 0.08f,
                },
                new Circle
                {
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.32f),
                    Position = new Vector2(-0.16f, 0.3f),
                },
                new Circle
                {
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.32f),
                    Position = new Vector2(0.16f, 0.3f),
                },
                new Circle
                {
                    RelativePositionAxes = Axes.Both,
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(0.32f),
                    Position = new Vector2(0, 0.6f),
                },
            };

            Alpha = 0;
        }

        protected override CatchJudgement CreateJudgement() => new CatchJudgement();

        private const float preempt = 1000;

        protected override void UpdateState(ArmedState state)
        {
            using (BeginAbsoluteSequence(HitObject.StartTime - preempt))
            {
                // default state
                this.MoveToY(-0.1f).FadeOut();

                // animation
                this.FadeIn(200).MoveToY(0.9f, preempt);
            }

            Expire(true);
        }
    }
}

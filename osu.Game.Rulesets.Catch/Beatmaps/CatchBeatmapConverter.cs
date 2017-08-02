﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Catch.Objects;
using System.Collections.Generic;
using System;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.UI;

namespace osu.Game.Rulesets.Catch.Beatmaps
{
    internal class CatchBeatmapConverter : BeatmapConverter<CatchBaseHit>
    {
        protected override IEnumerable<Type> ValidConversionTypes { get; } = new[] { typeof(IHasXPosition) };

        protected override IEnumerable<CatchBaseHit> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            var catchHit = original as CatchBaseHit;

            yield return catchHit ?? new Fruit
            {
                StartTime = original.StartTime,
                Position = ((IHasXPosition)original).X / OsuPlayfield.BASE_SIZE.X
            };
        }
    }
}

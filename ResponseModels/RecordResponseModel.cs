﻿using System;
using System.Linq;
using TNRD.Zeepkist.GTR.DTOs.Internal.Models;

namespace TNRD.Zeepkist.GTR.DTOs.ResponseModels;

public class RecordResponseModel
{
    public int Id { get; set; }
    public float? Time { get; set; }
    public float[]? Splits { get; set; }
    public string? GhostUrl { get; set; }
    public string? ScreenshotUrl { get; set; }
    public bool? IsBest { get; set; }
    public bool? IsValid { get; set; }
    public bool? IsWorldRecord { get; set; }
    public string? GameVersion { get; set; }
    public LevelResponseModel? Level { get; set; }
    public UserResponseModel? User { get; set; }
    public DateTime? DateCreated { get; set; }

    public static implicit operator RecordResponseModel(RecordModel model)
    {
        return new RecordResponseModel()
        {
            Id = model.Id,
            Time = model.Time,
            Splits = ParseSplits(model.Splits),
            GhostUrl = model.GhostUrl,
            ScreenshotUrl = model.ScreenshotUrl,
            IsBest = model.IsBest,
            IsValid = model.IsValid,
            IsWorldRecord = model.IsWorldRecord,
            GameVersion = model.GameVersion,
            Level = model.Level,
            User = model.User,
            DateCreated = model.DateCreated
        };
    }

    public static implicit operator RecordResponseModel(OneOf<int, RecordModel> model)
    {
        return new RecordResponseModel()
        {
            Id = model.Match<int>(i => i, m => m.Id),
            Time = model.Match<float?>(i => null, m => m.Time),
            Splits = model.Match<float[]?>(i => null, m => ParseSplits(m.Splits)),
            GhostUrl = model.Match<string?>(i => null, m => m.GhostUrl),
            ScreenshotUrl = model.Match<string?>(i => null, m => m.ScreenshotUrl),
            IsBest = model.Match<bool?>(i => null, m => m.IsBest),
            IsValid = model.Match<bool?>(i => null, m => m.IsValid),
            IsWorldRecord = model.Match<bool?>(i => null, m => m.IsWorldRecord),
            GameVersion = model.Match<string?>(i => null, m => m.GameVersion),
            Level = model.Match<LevelResponseModel?>(i => null, m => m.Level),
            User = model.Match<UserResponseModel?>(i => null, m => m.User),
            DateCreated = model.Match<DateTime?>(i => null, m => m.DateCreated)
        };
    }

    private static float[]? ParseSplits(string? splits)
    {
        return string.IsNullOrEmpty(splits) ? Array.Empty<float>() : splits?.Split('|').Select(float.Parse).ToArray();
    }
}

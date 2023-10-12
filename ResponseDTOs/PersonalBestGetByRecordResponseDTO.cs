﻿using System.Collections.Generic;
using TNRD.Zeepkist.GTR.DTOs.ResponseModels;

namespace TNRD.Zeepkist.GTR.DTOs.ResponseDTOs;

public class PersonalBestGetByRecordResponseDTO
{
    public int TotalAmount { get; set; }
    public List<PersonalBestResponseModel> Items { get; set; } = null!;
}

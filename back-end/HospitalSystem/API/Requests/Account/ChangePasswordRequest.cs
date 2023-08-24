﻿using Services.Constants;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Account
{
    public class ChangePasswordRequest  
    {
        [DataType(DataType.Password), Required]
        public string NewPassword { get; set; } = null!;

        [DataType(DataType.Password), Required, Compare(nameof(NewPassword), ErrorMessage = Errors.PasswordAreNotTheSame)]
        public string ConfirmNewPassword { get; set; } = null!;

        [DataType(DataType.Password), Required]
        public string OldPassword { get; set; } = null!;
    }
}

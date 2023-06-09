﻿using System;

namespace Library.Constants
{
    public class Constants
    {
        public static class BookCosntants
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AuthorMaxLength = 50;
            public const int AuthorMinLength = 5;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;
        }

        public static class CategoryConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }

        public static class LoginConstants
        {
            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 5;

            public const int PasswordNameMaxLength = 20;
            public const int PasswordMinLength = 5;

            public const int EmailNameMaxLength = 60;
            public const int EmailMinLength = 10;
        }
    }
}

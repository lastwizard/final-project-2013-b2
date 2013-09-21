IF NOT EXISTS (SELECT * FROM [User])
BEGIN
  INSERT [User] ([Username], [Email]) VALUES (N'heinz95729', N'heinz95729@gmail.com')
  INSERT [webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (SCOPE_IDENTITY(), CAST(0x0000A23E003CB001 AS DateTime), NULL, 1, NULL, 0, N'ANd9XvWy8eMnzW5LlmU6kcLUdiEyYsy9yjVGBKe6yZcYGgAMiugXL33U8QbJu4D32g==', CAST(0x0000A23E003CB001 AS DateTime), N'', NULL, NULL)
END
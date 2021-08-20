using System;

namespace Qest.Example.Users
{
  public record UserDetailDto(
    Guid Id,
    UserRole Role,
    string Email,
    string FirstName,
    string LastName,
    string? Notes);

  public record UserPreviewDto(
    Guid Id,
    UserRole Role,
    string FirstName,
    string LastName);

  public record UserQueryDto(
    int Offset,
    int Limit,
    UserRole? Role);

  public record UserCreationDto(
    UserRole Role,
    string Email,
    string FirstName,
    string LastName,
    string? Notes);

  public record UserUpdateDto(
    UserRole Role,
    string FirstName,
    string LastName,
    string? Notes);
}

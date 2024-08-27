using MinimalApi.Dominio.Enuns;

namespace MinimalApi.Dominio.ModelViews;

public record AdmLogado
{
      public string Email { get; set; } = default!;
      public string Perfil { get; set; } = default!;
      public string Token { get; set; } = default!;
}
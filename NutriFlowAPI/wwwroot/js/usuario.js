// Exemplo para trocar foto do usuário após upload (usuário.html)
document.addEventListener('DOMContentLoaded', function() {
  const userPhoto = document.getElementById('user-photo');
  // Exemplo: se quisesse carregar a foto salva, fazer aqui.
  // userPhoto.src = "url-da-foto-do-usuario";
});

// Exemplo: submit dos formulários
document.querySelectorAll('.form-card').forEach(form => {
  form.addEventListener('submit', function(e) {
    e.preventDefault();
    window.location.href = "usuario.html"; // Simula login ou registro indo para perfil
  });
});

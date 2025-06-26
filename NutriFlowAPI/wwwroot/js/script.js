document.addEventListener("DOMContentLoaded", function () {
  // Crie os ícones Lucide
  lucide.createIcons();

  // Adiciona o evento de clique nos links da bottom-nav
  document.querySelectorAll(".bottom-nav .nav-link").forEach(function (link) {
    link.addEventListener("click", function () {
      // Remove o active de todos
      document
        .querySelectorAll(".bottom-nav .nav-link")
        .forEach((l) => l.classList.remove("active"));
      // Adiciona o active no clicado
      this.classList.add("active");
      // Obs: em navegação tradicional, a página vai recarregar e perder o estado!
      // Este JS só é útil para SPAs ou testes.
    });
  });

  // Se preferir definir o ativo por URL, faça assim:
  // (Descomente se quiser automatizar o highlight pela página atual)

  const links = document.querySelectorAll(".bottom-nav .nav-link");
  links.forEach(function (link) {
    if (window.location.pathname.endsWith(link.getAttribute("href"))) {
      links.forEach((l) => l.classList.remove("active"));
      link.classList.add("active");
    }
  });
});

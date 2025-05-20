const API_BASE = "http://localhost:5034/api/categoria"; // Ajuste a porta se necessário

listarCategorias();

async function listarCategorias() {
    const resposta = await fetch(`${API_BASE}/ListarCategorias`);
    const resultado = await resposta.json();

    console.log("Resposta do listarCategorias:", resultado); // 👈 debug aqui

    const tbody = document.querySelector("#tabelaCategorias tbody");
    tbody.innerHTML = "";

    if (!resultado.dados) {
        console.warn("Nenhum dado encontrado.");
        return;
    }

    resultado.dados.forEach(categoria => {
        const tr = document.createElement("tr");
        tr.innerHTML = `<td>${categoria.id}</td><td>${categoria.categoria}</td>`;
        tbody.appendChild(tr);
    });
}

async function criarCategoria() {
    const nome = document.getElementById("nomeCategoria").value;

    const resposta = await fetch(`${API_BASE}/CriarCategoria`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ categoria: nome })
    });

    const resultado = await resposta.json();
    alert(resultado.mensagem || "Categoria criada!");
    listarCategorias();
}

async function editarCategoria() {
    const id = document.getElementById("idEditar").value;
    const nome = document.getElementById("novoNome").value;

    const resposta = await fetch(`${API_BASE}/EditarCategoria`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ id: parseInt(id), categoria: nome })
    });

    const resultado = await resposta.json();
    alert(resultado.mensagem || "Categoria editada!");
    listarCategorias();
}

async function excluirCategoria() {
    const id = document.getElementById("idExcluir").value;

    const resposta = await fetch(`${API_BASE}/ExcluirCategoria?idCategoria=${id}`, {
        method: "DELETE"
    });

    const resultado = await resposta.json();
    alert(resultado.mensagem || "Categoria excluída!");
    listarCategorias();
}

// Carrega categorias ao iniciar



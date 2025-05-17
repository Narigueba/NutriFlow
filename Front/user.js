document.addEventListener('DOMContentLoaded', () => {
    const tableBody = document.querySelector('#user-table tbody');
    const messageDiv = document.getElementById('message');
    const btnNew = document.getElementById('btn-new');
  
    // Função para exibir mensagens
    function showMessage(msg, isError = true) {
      messageDiv.textContent = msg;
      messageDiv.className = isError ? 'form-message error' : 'form-message success';
      setTimeout(() => { messageDiv.textContent = ''; messageDiv.className = 'form-message'; }, 3000);
    }
  
    // Carrega usuários e popula a tabela
    async function loadUsers() {
      try {
        const res = await fetch('https://seu-backend/api/usuarios');
        if (!res.ok) throw new Error(`Status: ${res.status}`);
        const users = await res.json();
        tableBody.innerHTML = '';
        users.forEach(user => {
          const tr = document.createElement('tr');
          tr.innerHTML = `
            <td>${user.id}</td>
            <td>${user.name}</td>
            <td>${user.email}</td>
            <td>
              <button class="btn-edit" data-id="${user.id}"><i data-lucide="edit-2"></i></button>
              <button class="btn-delete" data-id="${user.id}"><i data-lucide="trash-2"></i></button>
            </td>
          `;
          tableBody.appendChild(tr);
        });
        // Atualiza os ícones
        lucide.createIcons();
      } catch (error) {
        console.error('Erro ao carregar usuários:', error);
        showMessage('Falha ao carregar usuários.');
      }
    }
  
    // Excluir usuário
    async function deleteUser(id) {
      if (!confirm('Tem certeza que deseja excluir este usuário?')) return;
      try {
        const res = await fetch(`https://seu-backend/api/usuarios/${id}`, { method: 'DELETE' });
        if (!res.ok) throw new Error(`Status: ${res.status}`);
        showMessage('Usuário excluído com sucesso!', false);
        loadUsers();
      } catch (error) {
        console.error('Erro ao excluir usuário:', error);
        showMessage('Erro ao excluir usuário.');
      }
    }
  
    // Redireciona para criação/edição
    tableBody.addEventListener('click', (e) => {
      const btn = e.target.closest('button');
      if (!btn) return;
      const id = btn.getAttribute('data-id');
      if (btn.classList.contains('btn-edit')) {
        window.location.href = `register.html?id=${id}`;
      } else if (btn.classList.contains('btn-delete')) {
        deleteUser(id);
      }
    });
  
    // Botão Novo Usuário
    btnNew.addEventListener('click', () => {
      window.location.href = 'register.html';
    });
  
    // Inicialização
    loadUsers();
  });
document.addEventListener('DOMContentLoaded', () => {
    const tableBody = document.querySelector('#product-table tbody');
    const messageDiv = document.getElementById('message');
    const btnNew = document.getElementById('btn-new-product');
  
    // Exibe mensagens de feedback
    function showMessage(msg, isError = true) {
      messageDiv.textContent = msg;
      messageDiv.className = isError ? 'form-message error' : 'form-message success';
      setTimeout(() => {
        messageDiv.textContent = '';
        messageDiv.className = 'form-message';
      }, 3000);
    }
  
    // Carrega produtos e popula a tabela
    async function loadProducts() {
      try {
        const res = await fetch('https://seu-backend/api/produtos');
        if (!res.ok) throw new Error(`Status: ${res.status}`);
        const products = await res.json();
        tableBody.innerHTML = '';
        products.forEach(prod => {
          const tr = document.createElement('tr');
          tr.innerHTML = `
            <td>${prod.id}</td>
            <td>${prod.name}</td>
            <td>R$ ${prod.price.toFixed(2)}</td>
            <td>
              <button class="btn-edit" data-id="${prod.id}"><i data-lucide="edit-2"></i></button>
              <button class="btn-delete" data-id="${prod.id}"><i data-lucide="trash-2"></i></button>
            </td>
          `;
          tableBody.appendChild(tr);
        });
        // Atualiza ícones Lucide
        lucide.createIcons();
      } catch (error) {
        console.error('Erro ao carregar produtos:', error);
        showMessage('Falha ao carregar produtos.');
      }
    }
  
    // Excluir produto
    async function deleteProduct(id) {
      if (!confirm('Tem certeza que deseja excluir este produto?')) return;
      try {
        const res = await fetch(`https://seu-backend/api/produtos/${id}`, { method: 'DELETE' });
        if (!res.ok) throw new Error(`Status: ${res.status}`);
        showMessage('Produto excluído com sucesso!', false);
        loadProducts();
      } catch (error) {
        console.error('Erro ao excluir produto:', error);
        showMessage('Erro ao excluir produto.');
      }
    }
  
    // Eventos de edição/exclusão na tabela
    tableBody.addEventListener('click', e => {
      const btn = e.target.closest('button');
      if (!btn) return;
      const id = btn.getAttribute('data-id');
      if (btn.classList.contains('btn-edit')) {
        window.location.href = `product-form.html?id=${id}`;
      } else if (btn.classList.contains('btn-delete')) {
        deleteProduct(id);
      }
    });
  
    // Novo produto
    btnNew.addEventListener('click', () => {
      window.location.href = 'product-form.html';
    });
  
    // Inicializa
    loadProducts();
  });
  
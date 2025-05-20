document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('user-form');
    const messageDiv = document.getElementById('form-message');
  
    // Função para exibir mensagens
    function showMessage(msg, isError = true) {
      messageDiv.textContent = msg;
      messageDiv.className = isError ? 'form-message error' : 'form-message success';
    }
  
    // Validação de email
    function isValidEmail(email) {
      const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return regex.test(email);
    }
  
    form.addEventListener('submit', async (e) => {
      e.preventDefault();
  
      const name = form.name.value.trim();
      const email = form.email.value.trim();
      const password = form.password.value;
      const confirmPassword = form['confirm-password'].value;
  
      // Validações
      if (!name) {
        showMessage('Por favor, insira seu nome completo.');
        return;
      }
      if (!isValidEmail(email)) {
        showMessage('Por favor, insira um email válido.');
        return;
      }
      if (password.length < 6) {
        showMessage('A senha deve ter no mínimo 6 caracteres.');
        return;
      }
      if (password !== confirmPassword) {
        showMessage('As senhas não coincidem.');
        return;
      }
  
      // Preparar payload
      const payload = { name, email, password };
  
      try {
        const response = await fetch('https://seu-backend/api/usuarios', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(payload)
        });
  
        if (!response.ok) {
          throw new Error(`Erro ao cadastrar: ${response.status}`);
        }
  
        // Usuário cadastrado com sucesso
        showMessage('Cadastro realizado com sucesso!', false);
        form.reset();
  
        // Redirecionar para a home após 2 segundos
        setTimeout(() => {
          window.location.href = 'index.html';
        }, 2000);
  
      } catch (error) {
        console.error('Erro no cadastro:', error);
        showMessage('Houve um erro ao cadastrar. Tente novamente.');
      }
    });
  });
  
document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('login-form');
    const messageDiv = document.getElementById('form-message');
  
    // Exibe mensagens de erro ou sucesso
    function showMessage(msg, isError = true) {
      messageDiv.textContent = msg;
      messageDiv.className = isError ? 'form-message error' : 'form-message success';
    }
  
    form.addEventListener('submit', async (e) => {
      e.preventDefault();
  
      const email = form.email.value.trim();
      const password = form.password.value;
  
      // Validações básicas
      if (!email) {
        showMessage('Por favor, insira seu email.');
        return;
      }
      if (!password) {
        showMessage('Por favor, insira sua senha.');
        return;
      }
  
      try {
        const response = await fetch('https://seu-backend/api/auth/login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ email, password })
        });
  
        if (!response.ok) {
          if (response.status === 401) {
            showMessage('Email ou senha inválidos.');
          } else {
            throw new Error(`Status: ${response.status}`);
          }
          return;
        }
  
        const data = await response.json();
        const token = data.token;
  
        // Armazena token no localStorage (ou cookie)
        localStorage.setItem('authToken', token);
  
        showMessage('Login realizado com sucesso!', false);
  
        // Redireciona para dashboard ou página principal
        setTimeout(() => {
          window.location.href = 'index.html';
        }, 1500);
  
      } catch (error) {
        console.error('Erro no login:', error);
        showMessage('Erro ao fazer login. Tente novamente mais tarde.');
      }
    });
  });
  
// Listas para notificação
const receitas = [
  'Strogonoff', 'Pão de queijo', 'Bolo de cenoura', 'Risoto de abóbora', 'Sopa de ervilha'
];
const ingredientes = [
  'Batata', 'Tomate', 'Alface', 'Cebola', 'Alho', 'Cenoura', 'Arroz', 'Feijão'
];
const relatorios = [
  'Relatório do mês', 'Resumo semanal', 'Economias', 'Relatório de receitas'
];

// Versão tipo 1.0.3
function randomVersion() {
  return `${Math.floor(Math.random()*2)}.${Math.floor(Math.random()*10)}.${Math.floor(Math.random()*10)}`;
}

// Probabilidades personalizadas
function sorteiaTipo() {
  const r = Math.random();
  if (r < 0.75) return 'receita';
  if (r < 0.75) return 'vencimento';
  if (r < 0.30) return 'relatorio';
  return 'update';
}

function gerarNotificacao(tipo) {
  switch(tipo) {
    case 'receita':
      return `Receita: ${receitas[Math.floor(Math.random()*receitas.length)]}`;
    case 'vencimento':
      return `Vencimento: ${ingredientes[Math.floor(Math.random()*ingredientes.length)]}`;
    case 'relatorio':
      return relatorios[Math.floor(Math.random()*relatorios.length)];
    case 'update':
      return `Atualização v${randomVersion()} disponível`;
    default:
      return 'Notificação';
  }
}

function gerarNotificacoes(qtd) {
  const rows = [];
  for(let i=0; i<qtd; i++) {
    const tipo = sorteiaTipo();
    rows.push({
      texto: gerarNotificacao(tipo),
      even: i%2 === 1
    });
  }
  return rows;
}

function montarNotificacoes() {
  const container = document.getElementById('notificacoes');
  const notifs = gerarNotificacoes(20);

  container.innerHTML = '';
  notifs.forEach(n => {
    const div = document.createElement('div');
    div.className = 'notificacao-row' + (n.even ? ' even' : '');
    div.innerHTML = `
      <span>${n.texto}</span>
      <span class="dot"></span>
    `;
    container.appendChild(div);
  });

  lucide.createIcons();
}

// Espera DOM pronto
document.addEventListener('DOMContentLoaded', montarNotificacoes);

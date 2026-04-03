# ⚽ KS Scheduler

Sistema para organização de partidas de futebol amador, criado para facilitar o dia a dia de organizadores, jogadores e donos de quadra.

A proposta do projeto é substituir o controle manual feito em grupos de WhatsApp, listas improvisadas e cobranças desorganizadas, centralizando a gestão da partida em um único sistema.

---

## 🚀 Objetivo do produto

O KS Scheduler tem como objetivo tornar mais simples a organização de jogos amadores, permitindo:

- criar partidas com base na disponibilidade da quadra
- controlar confirmações de presença
- organizar lista principal e lista de espera
- aplicar regras de cobrança da partida
- acompanhar pagamentos dos jogadores
- dar mais visibilidade ao organizador e ao dono da quadra

---

## 👥 Perfis do sistema

O sistema foi pensado inicialmente para os seguintes perfis:

- **Organizador da pelada**
- **Jogador**
- **Dono da quadra**
- **Administrador**

---

## ✅ Funcionalidades previstas

### MVP
- autenticação de usuários
- criação de partidas
- visualização da próxima partida
- confirmação de presença
- controle de limite de jogadores
- lista de espera
- regras simples de cobrança
- acompanhamento de pagamento
- compartilhamento da partida via link / WhatsApp

### Futuras evoluções
- login com Google (SSO)
- relatórios por perfil
- integração mais completa com WhatsApp
- gestão de quadras e agenda disponível
- histórico de partidas
- regras avançadas de preço (ex.: goleiro paga metade, convidado não paga, valor fixo por jogador, rateio automático)
- dashboards e métricas

---

## 🧠 Regras de negócio iniciais

Algumas regras de negócio previstas no domínio:

- uma partida possui limite de jogadores
- quando o limite é atingido, novos jogadores entram na lista de espera
- ao desistir um jogador confirmado, o próximo da lista de espera pode assumir a vaga
- a partida pode ter regras diferentes de cobrança
- o valor pode ser fixo ou definido por condições específicas da partida
- alguns tipos de jogadores podem ter tratamento especial no pagamento, como goleiro pagar metade ou ser isento
- apenas usuários autorizados podem criar e gerenciar partidas
- diferentes perfis possuem diferentes níveis de acesso às informações

---

## 🏗️ Arquitetura do projeto

O projeto está organizado em camadas, separando responsabilidades de domínio, aplicação, infraestrutura e interface.

### Estrutura atual
- `KS.Scheduler.Domain`
- `KS.Scheduler.Application`
- `KS.Scheduler.Infrastructure`
- `KS.Scheduler.API`
- `KS.Scheduler.Frontend`

### Abordagem
- separação de responsabilidades
- foco em evolução gradual do domínio
- organização orientada a casos de uso
- base para aplicar boas práticas como Clean Architecture / DDD em nível prático

---

## 🧱 Modelagem inicial do domínio

Entidades já identificadas:

- **Usuário**
- **Jogador**
- **Partida**
- **Presença**

Entidades/objetos que tendem a surgir na evolução do domínio:

- **Quadra**
- **Pagamento**
- **Convite**
- **Regra de cobrança**
- **Lista de espera**

---

## 🛠️ Stack utilizada

### Backend
- .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

### Frontend
- Blazor

---

## 🔌 Integrações previstas

- **WhatsApp** para compartilhamento de convites e partidas
- **Google** para autenticação social (SSO)

---

## 📌 Status do projeto

### Já desenvolvido
- frontend da home pública/comercial
- frontend da tela de login
- frontend da home interna com informações da próxima partida (em andamento)

### Em andamento
- alimentação da home com dados reais da próxima partida

### Próximos passos
- autenticação com usuário e senha
- modelagem do domínio do MVP
- criação de partida
- confirmação de presença
- lista de espera
- controle de pagamento
- relatórios iniciais por perfil

---

## 🎯 Escopo inicial do MVP

O MVP será focado no fluxo principal da organização de uma pelada:

1. organizador cria a partida
2. define limite de jogadores
3. jogadores confirmam presença
4. sistema controla lista principal e lista de espera
5. organizador acompanha quem confirmou e quem pagou
6. partida pode ser compartilhada com os jogadores

Esse escopo foi definido para validar o valor principal do sistema antes de avançar para integrações e regras mais complexas.

---

## 📚 Objetivo técnico do projeto

Além do problema de negócio, o projeto também serve como estudo prático de:

- modelagem de domínio
- arquitetura em camadas
- desenvolvimento full stack com .NET + Blazor
- autenticação e autorização
- persistência com Entity Framework Core
- construção evolutiva de um sistema real

---

## 📖 Nome do projeto

**KS Scheduler** representa a ideia de agendamento, organização e controle de partidas amadoras, com foco em simplicidade e clareza para os usuários.

---

## 🤝 Contribuição

Projeto em desenvolvimento contínuo, evoluindo junto com a definição das regras de negócio e necessidades reais do cenário de futebol amador.

# MVP

## 1. Objetivo do MVP

O objetivo do MVP do **KS Scheduler** é validar a proposta central do produto: facilitar a organização de partidas de futebol amador, substituindo o controle manual feito em grupos de WhatsApp e listas informais.

Nesta primeira versão, o sistema deve permitir que um organizador crie uma partida, convide jogadores, acompanhe confirmações, controle a lista de espera e registre pagamentos de forma simples.

---

## 2. Problema que o MVP resolve

Hoje, a organização de partidas amadoras costuma gerar dificuldades como:

- confirmações desorganizadas
- falta de controle sobre número de jogadores
- lista de espera feita manualmente
- cobrança individual feita pelo organizador
- dificuldade para saber quem pagou e quem ainda está pendente

O MVP deve resolver esse fluxo principal com o menor conjunto de funcionalidades possível.

---

## 3. Usuários contemplados no MVP

O MVP será focado principalmente em:

- **Organizador da pelada**
- **Jogador**

O perfil de **dono da quadra** poderá ser considerado futuramente, mas não será prioridade na primeira versão.

---

## 4. Funcionalidades que entram no MVP

### 4.1 Autenticação
- login com usuário e senha
- possibilidade de evolução futura para login social

### 4.2 Gestão básica de usuários
- cadastro de usuário
- identificação do perfil do usuário
- associação do jogador a uma conta de acesso

### 4.3 Criação de partida
O organizador deve conseguir:
- criar uma nova partida
- definir data e horário
- definir local/quadra
- definir quantidade máxima de jogadores
- definir valor da participação
- informar regras simples de cobrança

### 4.4 Regras simples de cobrança
O MVP pode contemplar regras básicas como:
- valor fixo para todos
- goleiro paga metade
- goleiro não paga

Se necessário, essa parte pode começar apenas com **valor único para todos** e evoluir depois.

### 4.5 Confirmação de presença
O jogador deve conseguir:
- visualizar a próxima partida
- confirmar presença
- cancelar presença

### 4.6 Lista principal e lista de espera
O sistema deve:
- colocar o jogador na lista principal enquanto houver vagas
- colocar automaticamente na lista de espera quando a partida estiver lotada
- promover automaticamente o próximo da espera quando surgir vaga

### 4.7 Controle de pagamento
O organizador deve conseguir:
- marcar quem pagou
- visualizar quem está pendente
- acompanhar a situação de pagamento da partida

### 4.8 Home com próxima partida
O sistema deve exibir:
- próxima partida do usuário
- data, horário e local
- situação da lista
- status de presença
- status de pagamento

---

## 5. Funcionalidades que não entram no MVP

As funcionalidades abaixo são importantes, mas ficam fora da primeira versão:

- integração oficial com WhatsApp
- envio automático de convites
- integração com meios de pagamento
- repasse automático para a quadra
- relatórios avançados
- dashboard gerencial
- múltiplas quadras com agenda completa
- regras financeiras complexas
- mensalidade, pacotes ou créditos
- autenticação com Google
- administração completa da quadra
- histórico detalhado de partidas
- ranking, estatísticas e desempenho de jogadores

---

## 6. Escopo mínimo viável

Se for necessário reduzir ainda mais o escopo inicial, a menor versão funcional possível seria:

- cadastro/login
- criação de partida
- limite de jogadores
- confirmação de presença
- lista de espera
- marcação manual de pagamento
- visualização da próxima partida

---

## 7. Critérios de sucesso do MVP

O MVP será considerado bem-sucedido se conseguir validar os seguintes pontos:

- o organizador consegue criar e gerenciar uma partida sem depender de controle manual externo
- os jogadores conseguem confirmar presença de forma simples
- a lista de espera funciona corretamente
- o organizador consegue acompanhar pagamentos de forma centralizada
- a experiência é mais simples e organizada do que o fluxo atual via WhatsApp

---

## 8. Próximas evoluções após o MVP

Após validar o MVP, o produto poderá evoluir para:

- login com Google
- compartilhamento por WhatsApp
- integração com pagamentos
- visão do dono da quadra
- relatórios por partida e por período
- gestão de grupos fixos de jogadores
- regras de cobrança mais flexíveis
- agenda de quadras
- múltiplos organizadores e permissões mais detalhadas
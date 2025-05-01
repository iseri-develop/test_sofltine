// Proteção contra acesso direto
const user = sessionStorage.getItem("usuarioLogado");
if (!user) {
    window.location.href = "index.html";
}

// Renderiza ícones Lucide
lucide.createIcons();

// URL base da API
const API_URL = "http://localhost:5204/api/cliente";

// Torna a função logout acessível no HTML
document.getElementById("logout").addEventListener("click", () => {
    sessionStorage.clear();
    window.location.href = "index.html";
});

// Evento para abrir o modal
const btnAddCliente = document.getElementById("btnAddCliente");
if (btnAddCliente) {
    btnAddCliente.addEventListener("click", () => {
        document.getElementById("clienteModal").classList.remove("hidden");
        document.getElementById("clienteForm").reset();
        document.getElementById("modalTitle").innerText = "Novo Cliente";
        document.getElementById("id").value = "";
    });
}

// Evento para fechar o modal
const closeModal = document.getElementById("closeModal");
if (closeModal) {
    closeModal.addEventListener("click", () => {
        document.getElementById("clienteModal").classList.add("hidden");
    });
}

// Ao carregar a página
document.addEventListener("DOMContentLoaded", () => {
    carregarClientes();

    // Evento de envio do formulário
    document.getElementById("clienteForm").addEventListener("submit", async (e) => {
        e.preventDefault();

        const id = document.getElementById("id").value;
        const dto = {
            id: parseInt(id || 0),
            nome: document.getElementById("nome").value,
            fantasia: document.getElementById("fantasia").value,
            documento: document.getElementById("documento").value,
            endereco: document.getElementById("endereco").value
        };

        const method = id ? "PUT" : "POST";
        const url = id ? `${API_URL}/${id}` : API_URL;

        const response = await fetch(url, {
            method: method,
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(dto)
        });

        if (response.ok) {
            alert("Cliente salvo com sucesso!");
            document.getElementById("clienteForm").reset();
            document.getElementById("id").value = "";
            document.getElementById("clienteModal").classList.add("hidden");
            carregarClientes();
        } else {
            alert("Erro ao salvar cliente.");
        }
    });
});

// Carrega a tabela de clientes
async function carregarClientes() {
    const tbody = document.getElementById("clientesTableBody");
    tbody.innerHTML = "";

    const res = await fetch(API_URL);
    const clientes = await res.json();

    clientes.forEach(c => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${c.nome}</td>
            <td>${c.fantasia}</td>
            <td>${c.documento}</td>
            <td>${c.endereco}</td>
            <td>
                <button title="Editar" onclick="editarCliente(${c.id})"><i data-lucide='edit'></i></button>
                <button title="Excluir" onclick="deletarCliente(${c.id})"><i data-lucide='trash-2'></i></button>
            </td>
        `;
        tbody.appendChild(tr);
    });

    lucide.createIcons(); // atualiza ícones após renderizar
}

// Edita cliente
window.editarCliente = async function (id) {
    const res = await fetch(`${API_URL}/${id}`);
    const c = await res.json();

    document.getElementById("id").value = c.id;
    document.getElementById("nome").value = c.nome;
    document.getElementById("fantasia").value = c.fantasia;
    document.getElementById("documento").value = c.documento;
    document.getElementById("endereco").value = c.endereco;

    document.getElementById("modalTitle").innerText = "Editar Cliente";
    document.getElementById("clienteModal").classList.remove("hidden");
};

// Deleta cliente
window.deletarCliente = async function (id) {
    if (!confirm("Tem certeza que deseja excluir este cliente?")) return;

    const res = await fetch(`${API_URL}/${id}`, { method: "DELETE" });

    if (res.ok) {
        alert("Cliente excluído.");
        carregarClientes();
    } else {
        alert("Erro ao excluir cliente.");
    }
};

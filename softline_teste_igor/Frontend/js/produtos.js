// Proteção contra acesso direto
const user = sessionStorage.getItem("usuarioLogado");
if (!user) {
    window.location.href = "index.html";
}

// Renderiza ícones Lucide
lucide.createIcons();

// URL base da API
const API_URL = "http://localhost:5204/api/produto";

// Torna a função logout acessível no HTML
document.getElementById("logout").addEventListener("click", () => {
    sessionStorage.clear();
    window.location.href = "index.html";
});

// Evento para abrir o modal
const btnAddProduto = document.getElementById("btnAddProduto");
if (btnAddProduto) {
    btnAddProduto.addEventListener("click", () => {
        document.getElementById("produtoModal").classList.remove("hidden");
        document.getElementById("produtoForm").reset();
        document.getElementById("modalTitle").innerText = "Novo Produto";
        document.getElementById("id").value = "";
    });
}

// Evento para fechar modal
const closeModal = document.getElementById("closeModal");
if (closeModal) {
    closeModal.addEventListener("click", () => {
        document.getElementById("clienteModal").classList.add("hideen");
    });
}

// Ao carregar a página
document.addEventListener("DOMContentLoaded", () => {
    carregarProdutos();

    // Evento de envio do formulário
    document.getElementById("produtoForm").addEventListener("submit", async (e) => {
        e.preventDefault();

        const id = document.getElementById("id").value;
        const dto = {
            id: parseInt(id || 0),
            descricao: document.getElementById("descricao").value,
            codigoDeBarras: document.getElementById("codigo").value,
            valorVenda: parseFloat(document.getElementById("valor").value),
            pesoBruto: parseFloat(document.getElementById("pesoBruto").value || 0),
            pesoLiquido: parseFloat(document.getElementById("pesoLiquido").value || 0)
        };

        const method = id ? "PUT" : "POST";
        const url = id ? `${API_URL}/${id}` : API_URL;

        const response = await fetch(url, {
            method: method,
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(dto)
        });

        if (response.ok) {
            alert("Produto salvo com sucesso!");
            document.getElementById("produtoForm").reset();
            document.getElementById("id").value = "";
            document.getElementById("produtoModal").classList.add("hidden");
            carregarProdutos();
        } else {
            alert("Erro ao salvar produto.");
        }
    });
});

// Carrega tabela de produtos
async function carregarProdutos() {
    const tbody = document.getElementById("produtosTableBody");
    tbody.innerHTML = "";

    const res = await fetch(API_URL);
    const produtos = await res.json();

    produtos.forEach(p => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${p.descricao}</td>
            <td>${p.codigoDeBarras}</td>
            <td>${p.valorVenda.toFixed(2)}</td>
            <td>${p.pesoBruto.toFixed(2)}</td>
            <td>${p.pesoLiquido.toFixed(2)}</td>
            <td>
                <button title="Editar" onclick="editarProduto(${p.id})"><i data-lucide='edit'></i></button>
                <button title="Excluir" onclick="deletarProduto(${p.id})"><i data-lucide='trash-2'></i></button>
            </td>
        `;
        tbody.appendChild(tr);
    });

    lucide.createIcons(); // atualiza ícones após renderizar
}

window.editarProduto = async function (id) {
    const res = await fetch(`${API_URL}/${id}`);
    const p = await res.json();

    document.getElementById("id").value = p.id;
    document.getElementById("descricao").value = p.descricao;
    document.getElementById("codigo").value = p.codigoDeBarras;
    document.getElementById("valor").value = p.valorVenda;
    document.getElementById("pesoBruto").value = p.pesoBruto;
    document.getElementById("pesoLiquido").value = p.pesoLiquido;

    document.getElementById("modalTitle").innerText = "Editar produto";
    document.getElementById("produtoModal").classList.remove("hidden");
};

window.deletarProduto = async function (id) {
    if (!confirm("Tem certeza que deseja excluir este produto?")) return;

    const res = await fetch(`${API_URL}/${id}`, { method: "DELETE" });

    if (res.ok) {
        alert("Produto excluído.");
        carregarProdutos();
    } else {
        alert("Erro ao excluir produto.");
    }
};

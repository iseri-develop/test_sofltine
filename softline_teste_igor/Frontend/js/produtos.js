const API_URL = "http://localhost:5204/api/produto";

document.addEventListener("DOMContentLoaded", () => {
    carregarProdutos();

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
            carregarProdutos();
        } else {
            alert("Erro ao salvar produto.");
        }
    });
});

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
                <button onclick="editarProduto(${p.id})">Editar</button>
                <button onclick="deletarProduto(${p.id})">Excluir</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
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

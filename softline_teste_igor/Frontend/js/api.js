// Caminho base da API (ajuste a porta se necessário)
const API_URL = "http://localhost:5204/api";

export async function postLogin(data) {
    const response = await fetch(`${API_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    if (response.ok) return true;
    return false;
}

import { postLogin } from "./api.js";

document.getElementById("loginForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const login = document.getElementById("login").value;
    const senha = document.getElementById("senha").value;

    const sucesso = await postLogin({ login, senha });

    if (sucesso) {
        // Armazena o login e redireciona
        sessionStorage.setItem("usuarioLogado", login);
        window.location.href = "dashboard.html";
    } else {
        document.getElementById("error").style.display = "block";
    }
});
